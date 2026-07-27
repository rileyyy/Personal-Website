<template>
  <div class="editor-tab" :class="{ selectedTab: selected }">
    <img class="icon" :src="getIcon(icon)" />
    <span class="file-name">{{ filename }}</span>
    <X class="icon-small" />
  </div>
</template>

<script setup lang="ts">
import { X } from 'lucide-vue-next';

defineProps<{
  icon: string,
  filename: string,
  selected: boolean,
}>();

const getIcon = (icon: string) =>
  `/node_modules/material-icon-theme/icons/${icon}.svg`;
</script>

<style scoped>
.editor-tab {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: var(--slightly-darker-black);
  border-right: 1px solid var(--line-break);
  font-family: 'Segoe UI', sans-serif;
  gap: 8px;
  height: 100%;
  padding: 0 8px;
  background-color: var(--black-three);
}

.selected-tab {
  border-top: 2px solid var(--accent-primary);
}

.file-name {
  color: var(--text-default);
  font-size: 14px;
}

.tab-right {
  display: flex;
  align-items: center;
  gap: 12px;
  padding-right: 8px;
}

.icon {
  color: #a9a9a9;
  width: 18px;
  height: 18px;
  cursor: pointer;
  transition: color 0.2s;
}

.icon-small {
  color: #a9a9a9;
  width: 14px;
  height: 14px;
  cursor: pointer;
  transition: color 0.2s;
}

.icon:hover {
  color: #ffffff;
}
</style>
