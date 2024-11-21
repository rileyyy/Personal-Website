<template>
  <header class="header">
    <nav>
      <ul class="nodes">
        <li class="nodeElements" v-for="node in linkedNodes" :key="node.id">
          <a class="nodeLink" @click="navigateToNode(node.id)">// {{ node.id }}</a>
        </li>
      </ul>
    </nav>
  </header>
</template>

<script setup>
import { computed } from 'vue'
import { useVueFlow } from '@vue-flow/core'
import { setNodesVisible } from './Home.vue'

const { fitView, nodes } = useVueFlow()

const homeNode = computed(() => nodes.value.find(node => node.id === 'Home'))
const linkedNodes = computed(() => {
  if (!homeNode.value || !homeNode.value.data.showNodes)
   return []

   return [homeNode.value,
    ...homeNode.value.data.showNodes
        .map(id => nodes.value.find(node => node && node.id === id))
        .filter(node => node)]
})

function navigateToNode(id) {
  console.log('navigateToNode', id)
}
</script>

<style>
.header {
  position: fixed;
  top: 0;
  width: 100%;
  background-color: var(--eerie-black);
  padding: 10px 0;
  z-index: 1000;
}

.nodes {
  list-style: none;
  display: flex;
  justify-content: center;
  margin: 0;
  padding: 0;
}

.nodeLink {
  color: var(--air-force-blue);
  transition: opacity 0.25s;
  padding: 4px 16px;
  margin: 4px;
}

.nodes:hover .nodeLink:not(:hover) {
  opacity: 0.4;
}
</style>