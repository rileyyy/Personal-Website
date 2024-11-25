<script setup>
import { onBeforeMount, ref } from 'vue'
import { VueFlow, useVueFlow } from '@vue-flow/core'
import { fetchDataAsync } from '../infrastructure/DatabaseService.ts'
import TransitionEdge from './TransitionEdge.vue'
import NodeOnly from './Nodes/NodeOnly.vue'
import Header from './Header.vue'
import ProjectNode from './Nodes/ProjectNode.vue'

const { fitView } = useVueFlow()


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

onBeforeMount(async () => {
  fetchDataAsync('nodes')
    .then((response) => parseNodes(response))
    .then(() => setTimeout(renderStartingNodes, 1000))
    .then(() => setTimeout(calculateEdges, 1750))
});
</script>

<script>
export const nodes = ref([]);
export const edges = ref([])

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

export function parseNodes(data) {
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
        slug: node.slug,
        showNodes: Array.isArray(node.showNodes) ? node.showNodes : JSON.parse(node.showNodes),
      },
    });
  });
}

export function calculateEdges() {
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

export function updateNodeCollection(nodeId) {
  let node = nodes.value.find((n) => n.id === nodeId);

  if (!node || !node.data.slug) {
    return;
  }

  fetchDataAsync(node.data.slug)
  .then((response) => {
    console.log(response);

    response.forEach((entry) => {
      let parentNode = nodes.value.find((n) => n.id === entry.parentNode);
      parentNode.data.showNodes.push(entry.name);

      let newNode = {
        id: entry.name,
        position: { x: entry.position[0], y: entry.position[1] },
        parent: entry.parentNode,
        type: getNodeTypeFromParent(parentNode),
        data: {
          icon: entry.icon,
          showNodes: entry.showNodes ?
          Array.isArray(entry.showNodes) ? entry.showNodes : JSON.parse(entry.showNodes) : null,
        },
      };
      addNodeSpecificData(newNode, entry);
      nodes.value.push(newNode);
    });
  });
}


function getNodeTypeFromParent(parentNode) {
  switch(parentNode.id) {
    case 'Journal':   return 'JournalNode';
    case 'Projects':  return 'ProjectNode';
    default:          return 'NodeOnly';

  }
}

function addNodeSpecificData(newNode, entry) {
  switch(newNode.type) {
    case 'JournalNode':
      newNode.data.id = entry.id;
      newNode.data.title = entry.title;
      newNode.data.tags = entry.tags;
      newNode.data.listDate = entry.listDate;
      newNode.data.content = entry.content;
      break;

    case 'ProjectNode':
      newNode.data.description = entry.description;
      newNode.data.link = entry.link;
      newNode.data.technologies = entry.technologies;
      newNode.data.images = entry.images;
      break;

    default:
      break;
  }
}
</script>

<template>
  <Header />
  <VueFlow
    v-model:nodes="nodes"
    v-model:edges="edges"
    class="transition-flow"
    :fit-view-on-init="true"
    :node-types="{NodeOnly: NodeOnly, ProjectNode: ProjectNode}">

    <template #edge-custom="props">
      <TransitionEdge v-bind="props" />
    </template>

    <template #nodeOnly="props">
      <NodeOnly :id="props.id" :data="props.data"/>
    </template>

    <template #projectNode="props">
      <ProjectNode :id="props.id" :data="props.data"/>
    </template>
  </VueFlow>
</template>

<style>
.transition-flow {
  background-color: var(--eerie-black);
}
</style>
