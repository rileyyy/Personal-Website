<template>
  <div class="journal-node">
    <h3>{{ id }}</h3>
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
  .journal-node {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 320px;
    height: 60px;
    background-color: var(--charcoal);
    border-radius: 25px;
    color: var(--cadet-gray);
    position: relative;
    transition: box-shadow 1s ease;
  }
</style>