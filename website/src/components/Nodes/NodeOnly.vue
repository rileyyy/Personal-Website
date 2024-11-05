<template>
  <div class="node-only">
    <span class="material-symbols-outlined">
      {{ props.data.icon }}
    </span>
    <span class="node-name">
      {{ props.id }}
    </span>
  </div>
</template>

<script setup>
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
.node-only {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 150px;
  height: 150px;
  background-color: var(--charcoal);
  border-radius: 75px;
  color: var(--cadet-gray);
  position: relative;
  transition: box-shadow 1s ease;
}

.material-symbols-outlined, .node-name {
  position: absolute;
  transition: opacity 1s;
}

.material-symbols-outlined {
  padding: 0;
  margin: 0;
  font-size: 56px !important;
  opacity: 1;
}

.node-name {
  opacity: 0;
  font-size: 24px;
}

.node-only:hover {
  box-shadow: 0 0 25px 10px rgba(255, 255, 255, 0.5);
}

.node-only:hover .material-symbols-outlined {
  opacity: 0;
}

.node-only:hover .node-name {
  opacity: 1;
}
</style>