<template>
  <div class="editor-tab">
    <div class="tab-left">
      <img class="icon" :src="getIcon(icon)" />
      <span class="file-name">{{ filename }}</span>
      <X class="icon-small" />
    </div>
    <div class="tab-right">
      <LucideGithub class="icon" v-if="mainPane" />
      <LucideBug class="icon" v-if="mainPane" />
      <LucidePlay class="icon" v-if="mainPane" />
      <LucideColumns2 class="icon" v-if="mainPane" />
      <Ellipsis class="icon" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { X } from 'lucide-vue-next';

defineProps<{
  icon: string,
  filename: string,
  mainPane?: boolean,
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
  border-bottom: 1px solid var(--line-break);
  border-right: 1px solid var(--line-break);
  font-family: 'Segoe UI', sans-serif;
  width: 100%;
  height: 30px;
  background-color: var(--black-three);
}

.tab-left {
  display: flex;
  align-items: center;
  gap: 8px;
  border-top: 2px solid var(--accent-primary);
  border-right: 1px solid var(--line-break);
  height: 100%;
  padding: 0 8px;
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
