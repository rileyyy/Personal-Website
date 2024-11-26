<script setup>
import { onBeforeMount, ref } from 'vue'
import { VueFlow, useVueFlow } from '@vue-flow/core'
import { fetchDataAsync } from '../infrastructure/DatabaseService.ts'
import TransitionEdge from './TransitionEdge.vue'
import NodeOnly from './Nodes/NodeOnly.vue'
import Header from './Header.vue'
import JournalNode from './Nodes/JournalNode.vue'
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
    .then(() => setTimeout(() => {
      nodes.value.forEach((node) => {
        updateChildEdges(node);
      });
    }, 1750))
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

export function updateNodeCollection(nodeId) {
  let parentNode = nodes.value.find((n) => n.id === nodeId);

  if (!parentNode || !parentNode.data.slug) {
    return;
  }

  fetchDataAsync(parentNode.data.slug)
  .then((response) => {
    response.forEach((entry) => {
      if (!parentNode.data.showNodes) {
        parentNode.data.showNodes = [];
      }
      parentNode.data.showNodes.push(entry.name);

      let newNode = {
        id: entry.name ? entry.name : entry.title,
        position: entry.position
          ? { x: entry.position[0], y: entry.position[1] }
          : CalculateSubPosition(parentNode),
        parent: parentNode,
        type: getNodeTypeFromParent(parentNode),
        data: {
          icon: entry.icon,
          showNodes: entry.showNodes ?
          Array.isArray(entry.showNodes) ? entry.showNodes : JSON.parse(entry.showNodes) : null,
        },
      };
      addNodeSpecificData(newNode, entry);
      nodes.value.push(newNode);

      updateChildEdges(parentNode);
    });
  });
}

function updateChildEdges(node) {
  if (!Array.isArray(node.data.showNodes))
    return;

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

function CalculateSubPosition(parentNode) {
  let homeNode = nodes.value.find((n) => n.id === 'Home');
  let parentPosition = parentNode.position;
  let numberOfChildren = parentNode.data.showNodes.length;

  // Calculate the position of the new node based on the parent node and number of children
  return {
    x: parentPosition.x < homeNode.position.x
        ? parentPosition.x - 200
        : parentPosition.x + 200,
    y: parentPosition.y + (numberOfChildren * 200),
  };
}

function getNodeTypeFromParent(parentNode) {
  switch(parentNode.id) {
    case 'Journals':   return 'JournalNode';
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
    :node-types="{NodeOnly: NodeOnly, ProjectNode: ProjectNode, JournalNode: JournalNode}">

    <template #edge-custom="props">
      <TransitionEdge v-bind="props" />
    </template>

    <template #nodeOnly="props">
      <NodeOnly :id="props.id" :data="props.data"/>
    </template>

    <template #journalNode="props">
      <JournalNode :id="props.id" :data="props.data"/>
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
