<script setup>
import { computed, ref, inject } from 'vue'
import { getBezierPath, getStraightPath, useVueFlow } from '@vue-flow/core'
import { setNodesVisible } from './Home.vue'

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
  // TODO: Not sure if this needs to be debounced or if I am doing something wrong
  // but it seems to be called 3 (or 6) times presently for each node click.
  // That doesn't seem to cause any issues, but it seems like it could be optimized/fixed.
  // It also seems to be causing showNodes to have node.parent and node.id be duplicated 3x.

  let showNodes = Array.isArray(node.data.showNodes)
                    ? node.data.showNodes
                    : JSON.parse(node.data.showNodes);

  showNodes.push(node.id);
  showNodes.push(node.parent);

  setNodesVisible(showNodes);

  // Delay briefly to allow nodes to be shown before fitting view
  // since it seems that includeHiddenNodes doesn't work as expected
  setTimeout(() => {
    fitView({
      nodes: showNodes,
      duration: 500,
      includeHiddenNodes: true,
    })
  }, 50)
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
      style="fill: #fdd023" />
  </Transition>
</template>
