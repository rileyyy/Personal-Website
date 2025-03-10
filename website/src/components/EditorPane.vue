<template>
  <div class="wrapper">
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

    <pre class="editor-container">
      <code ref="codeBlock" :class="'language-' + language.name">{{ code }}</code>
    </pre>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import hljs from 'highlight.js/lib/core';
import 'highlight.js/styles/atom-one-dark.css';
import { LucideGithub, LucideBug, LucidePlay, LucideColumns2, Ellipsis, X } from 'lucide-vue-next';
import { LanguageFn } from 'highlight.js';

defineProps<{
  code: string,
  icon: string,
  filename: string,
  mainPane?: boolean,
  language: LanguageFn,
}>();

const codeBlock = ref<HTMLElement | null>(null);

const getIcon = (icon: string) =>
  `/node_modules/material-icon-theme/icons/${icon}.svg`;

onMounted(() => {
  if (codeBlock.value) {
    hljs.highlightElement(codeBlock.value);
  }
});
</script>

<style scoped>
.wrapper {
  border-right: 1px solid var(--line-break);
  scrollbar-width: thin;
  scrollbar-color: var(--scroll-bar) transparent;
}

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
}

.tab-left {
  display: flex;
  align-items: center;
  gap: 8px;
  border-top: 2px solid var(--accent-primary);
  border-right: 1px solid var(--line-break);
  background-color: var(--black-three);
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

/* Editor Background */
.editor-container {
  max-height: 100vh;
  font-size: 14px;
  line-height: 1.5;
  white-space: pre-wrap;
  overflow-y: auto;
  text-align: left;
  width: 100%;
  flex: 1 1 auto;
  overflow-y: auto;
  scrollbar-width: thin;
  scrollbar-color: var(--scroll-bar) transparent;
}

.main-content::-webkit-scrollbar {
  width: 8px;
}

.main-content::-webkit-scrollbar-track {
  background: #2e2e2e;
}

.main-content::-webkit-scrollbar-thumb {
  background: var(--scroll-bar);
  border-radius: 4px;
}

/* Highlight.js theme overwrites */
.hljs {
  background: var(--black-three);
  color: var(--text-default);
}
</style>
