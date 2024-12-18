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
import { nodes, setNodesVisible } from './Home.vue'

const { fitView } = useVueFlow()

const homeNode = computed(() => nodes.value.find(node => node.id === 'Home'))
const linkedNodes = computed(() => {
  if (!homeNode.value || !homeNode.value.data.showNodes) return [];

  const uniqueNodes = new Set();
  uniqueNodes.add(homeNode.value);

  homeNode.value.data.showNodes
    .map(id => nodes.value.find(node => node && node.id === id))
    .filter(node => node)
    .forEach(node => uniqueNodes.add(node));

  return Array.from(uniqueNodes);
});

function navigateToNode(id) {
  const node = nodes.value.find(node => node.id === id)
  if (!node) return

  let showNodes = Array.isArray(node.data.showNodes)
                    ? node.data.showNodes
                    : JSON.parse(node.data.showNodes);

  showNodes.push(node.id);
  showNodes.push(node.parent);

  setNodesVisible(showNodes);

  setTimeout(() => {
    fitView({
      nodes: showNodes,
      duration: 500,
      includeHiddenNodes: true,
    })
  }, 50)
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