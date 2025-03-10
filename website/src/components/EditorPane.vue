<template>
  <pre class="editor-container"><code ref="codeBlock" :class="'language-' + language.name">{{ code }}</code>
  </pre>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import hljs from 'highlight.js/lib/core';
import 'highlight.js/styles/atom-one-dark.css';
import { LanguageFn } from 'highlight.js';

defineProps<{
  code: string,
  language: LanguageFn,
}>();

const codeBlock = ref<HTMLElement | null>(null);

onMounted(() => {
  if (codeBlock.value) {
    hljs.highlightElement(codeBlock.value);
  }
});
</script>

<style scoped>
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
  margin: 0;
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
