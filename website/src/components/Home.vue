<script setup>
import { onBeforeMount, ref } from 'vue'
import { VueFlow, useVueFlow } from '@vue-flow/core'
import { fetchNodesAsync } from '../infrastructure/DatabaseService.ts'
import TransitionEdge from './TransitionEdge.vue'

const { fitView } = useVueFlow()

const nodes = ref([])
const edges = ref([])

function parseNodes(data) {
  data.forEach((node) => {
    nodes.value.push({
      id: node.name,
      position: { x: node.position[0], y: node.position[1] },
      parent: node.parentNode,
      hidden: node.name !== 'Home',
      data: {
        label: node.name,
        showNodes: Array.isArray(node.showNodes) ? node.showNodes : JSON.parse(node.showNodes),
        nodeType: node.nodeType,
      },
    });
  });
}

function renderStartingNodes() {
}

onBeforeMount(async () => {
  fetchNodesAsync()
    .then((response) => parseNodes(response))
    .then(() => renderStartingNodes());
});
</script>

<template>
  <VueFlow :nodes="nodes" :edges="edges" class="transition-flow" :fit-view-on-init="true">
    <template #edge-custom="props">
      <TransitionEdge v-bind="props" />
    </template>
  </VueFlow>
</template>

<style></style>
