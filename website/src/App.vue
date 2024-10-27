<script setup>
import { provide, ref } from 'vue'
import { Position, VueFlow, useVueFlow } from '@vue-flow/core'
import TransitionEdge from './components/TransitionEdge.vue'

const { onInit } = useVueFlow()

const nodes = ref([
  {
    id: '1',
    data: { 
      label: 'DblClick me',
      showNodes: ['1', '2', '3'],
      mainHub: true,
     },
    position: { x: 0, y: 0 },
  },
  {
    id: '2',
    type: 'output',
    data: { 
      label: 'DblClick me',
      showNodes: ['1', '2'],
    },
    position: { x: 300, y: 300 },
    targetPosition: Position.Left,
  },
  {
    id: '3',
    data: { 
      label: 'DblClick me',
      showNodes: ['1', '3', '4'],
     },
    position: { x: -300, y: -300 },
  },
  {
    id: '4',
    type: 'output',
    data: { 
      label: 'DblClick me',
      showNodes: ['3', '4'],
    },
    position: { x: -600, y: -600 },
    targetPosition: Position.Right,
  },
])

const edges = ref([
  { id: 'e1-2', type: 'custom', source: '1', target: '2', style: { stroke: '#fff' } },
  { id: 'e1-3', type: 'custom', source: '1', target: '3', style: { stroke: '#fff' } },
  { id: 'e3-4', type: 'custom', source: '3', target: '4', style: { stroke: '#fff' } },
])

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
