<script setup>
import { provide, ref } from 'vue'
import { Position, VueFlow, useVueFlow } from '@vue-flow/core'
import TransitionEdge from './components/TransitionEdge.vue'

const { onInit } = useVueFlow()

const nodes = ref([])
const edges = ref([])


onInit(({ fitView }) => {
  fitView({ nodes: ['1', '2', '3'] })
})

function setHubNode(id) {
  nodes.value.forEach((node) => { node.data.mainHub = node.id === id });
}
provide('setHubNode', setHubNode);
</script>

<template>
  <VueFlow :nodes="nodes" :edges="edges" class="transition-flow">

    <template #edge-custom="props">
      <TransitionEdge v-bind="props" />
    </template>
  </VueFlow>
</template>

<style>
.transition-flow {
  background-color: #1a192b;
}
</style>
