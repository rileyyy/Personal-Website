<script setup>
import { onBeforeMount, provide, ref } from 'vue'
import { Position, VueFlow, useVueFlow } from '@vue-flow/core'
import TransitionEdge from './TransitionEdge.vue'
import { fetchNodesAsync } from '../infrastructure/DatabaseService.ts'

const { onInit } = useVueFlow()

const nodes = ref([])
const edges = ref([])

function parseNodes(data) {
  data.forEach((node) => {
    nodes.value.push({
      id: node.name,
      position: { x: node.position[0], y: node.position[1] },
      data: {
        label: node.name,
        showNodes: node.showNodes,
        nodeType: node.nodeType,
      },
    });
  });
}

onBeforeMount(async () => {
  fetchNodesAsync().then((response) => {
    parseNodes(response);
  });
});

onInit(({ fitView }) => {
  fitView({ nodes: ['1', '2', '3'] })
});
</script>

<template>
  <VueFlow :nodes="nodes" :edges="edges" class="transition-flow">
    <template #edge-custom="props">
      <TransitionEdge v-bind="props" />
    </template>
  </VueFlow>
</template>

<style>
</style>
