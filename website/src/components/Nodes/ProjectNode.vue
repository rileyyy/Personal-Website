<template>
  <div class="project-node">
    <h1>{{ id }}</h1>
  </div>
</template>

<script setup>
import { Handle, Position } from '@vue-flow/core'

const props = defineProps({
  id: {
    type: String,
    required: true,
  },
  data: {
    type: Object,
    required: true,
  },
})

</script>

<style>
  .project-node {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: 300px;
    height: 100px;
    background-color: var(--charcoal);
    border-radius: 50px;
    color: var(--cadet-gray);
    position: relative;
    transition: box-shadow 1s ease;
  }
</style>