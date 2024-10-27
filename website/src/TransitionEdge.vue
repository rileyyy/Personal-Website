<script setup>
import { computed, ref, inject } from 'vue'
import { TransitionPresets, useDebounceFn, useTransition, watchDebounced } from '@vueuse/core'
import { getBezierPath, getStraightPath, useVueFlow } from '@vue-flow/core'

const props = defineProps({
  id: {
    type: String,
    required: true,
  },
  source: {
    type: String,
    required: true,
  },
  target: {
    type: String,
    required: true,
  },
  sourceX: {
    type: Number,
    required: true,
  },
  sourceY: {
    type: Number,
    required: true,
  },
  targetX: {
    type: Number,
    required: true,
  },
  targetY: {
    type: Number,
    required: true,
  },
  sourcePosition: {
    type: String,
    required: true,
  },
  targetPosition: {
    type: String,
    required: true,
  },
  data: {
    type: Object,
    required: false,
  },
  markerEnd: {
    type: String,
    required: false,
  },
  style: {
    type: Object,
    required: false,
  },
})

const showDot = ref(false)

const { onNodeClick, fitView } = useVueFlow()

const path = computed(() =>
getStraightPath({
  sourceX: props.sourceX,
  sourceY: props.sourceY,
  targetX: props.targetX,
  targetY: props.targetY,
})
)

onNodeClick(({ node }) => {
   fitView({
          nodes: node.data.showNodes,
          duration: 500,
        })
})
</script>

<script>
export default {
  inheritAttrs: false,
}
</script>

<template>
  <path :id="id" ref="curve" :style="style" class="vue-flow__edge-path" :d="path[0]" :marker-end="markerEnd" />

  <Transition name="fade">
    <circle
      v-if="showDot"
      ref="dot"
      r="5"
      cy="0"
      cx="0"
      :transform="`translate(${transform.x}, ${transform.y})`"
      style="fill: #fdd023"
    />
  </Transition>
</template>
