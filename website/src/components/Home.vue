<script setup>
import { onBeforeMount, ref } from 'vue'
import { VueFlow, useVueFlow } from '@vue-flow/core'
import { fetchNodesAsync } from '../infrastructure/DatabaseService.ts'
import TransitionEdge from './TransitionEdge.vue'
import NodeOnly from './Nodes/NodeOnly.vue'
import Header from './Header.vue'

const { fitView } = useVueFlow()

const edges = ref([])

function parseNodes(data) {
  data.forEach((node) => {
    nodes.value.push({
      id: node.name,
      position: { x: node.position[0], y: node.position[1] },
      parent: node.parentNode,
      hidden: node.name !== 'Home',
      type: node.nodeType,
      data: {
        icon: node.icon,
        label: node.name,
        showNodes: Array.isArray(node.showNodes) ? node.showNodes : JSON.parse(node.showNodes),
      },
    });
  });
}

function renderStartingNodes() {
  let homeNode = nodes.value.find((node) => node.id === 'Home');

  setTimeout(() => fitView({
    nodes: homeNode.data.showNodes,
    duration: 1000,
  }));

  homeNode.data.showNodes.forEach((node) => {
    nodes.value.find((n) => n.id === node).hidden = false;
  });
}

function calculateEdges() {
  nodes.value.forEach((node) => {
    if (Array.isArray(node.data.showNodes)) {
      node.data.showNodes.forEach((showNode) => {
        edges.value.push({
          source: node.id,
          target: showNode,
          type: 'custom',
          style: {
            stroke: '#fff',
            strokeWidth: 2,
          },
        });
      });
    }
  });
}

onBeforeMount(async () => {
  fetchNodesAsync()
    .then((response) => parseNodes(response))
    .then(() => setTimeout(renderStartingNodes, 1000))
    .then(() => setTimeout(calculateEdges, 1750))
});
</script>

<script>
export const nodes = ref([]);

export function setNodesVisible(showNodes) {
  let nodesArr = Array.isArray(showNodes)
                  ? showNodes
                  : JSON.parse(showNodes);

  nodesArr.forEach((node) => {
    if (node === null)
      return;

    let n = nodes.value.find((n) => n.id === node);
    if (n.hidden)
      n.hidden = false;
  });
}
</script>

<template>
  <Header />
  <VueFlow
    v-model:nodes="nodes"
    v-model:edges="edges"
    class="transition-flow"
    :fit-view-on-init="true"
    :node-types="{NodeOnly: NodeOnly}">

    <template #edge-custom="props">
      <TransitionEdge v-bind="props" />
    </template>

    <template #nodeOnly="props">
      <NodeOnly :id="props.id" :data="props.data"/>
    </template>
  </VueFlow>
</template>

<style>
.transition-flow {
  background-color: var(--eerie-black);
}
</style>
