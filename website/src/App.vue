<script setup>
import { onBeforeMount, provide, ref } from 'vue'
import { Position, VueFlow, useVueFlow } from '@vue-flow/core'
import TransitionEdge from './components/TransitionEdge.vue'
import { pingAspHost } from './infrastructure/DatabaseService.ts'

const { onInit } = useVueFlow()

const nodes = ref([])
const edges = ref([])

const data = ref(null);

onInit(({ fitView }) => {
  fitView({ nodes: ['1', '2', '3'] })
})

function setHubNode(id) {
  nodes.value.forEach((node) => { node.data.mainHub = node.id === id });
}
provide('setHubNode', setHubNode);

onBeforeMount(async () => {
  try {
    data.value = await pingAspHost();
  } catch (error) {
    console.error('Error fetching data:', error);
  }
});
</script>

<template>
  <VueFlow :nodes="nodes" :edges="edges" class="transition-flow">
    <template #edge-custom="props">
      <TransitionEdge v-bind="props" />
    </template>
    <div v-if="data">
      <h1>Data from ASP.NET Server</h1>
      <pre>{{ data }}</pre>
    </div>
  </VueFlow>
</template>

<style>
.transition-flow {
  background-color: #1a192b;
}
</style>
