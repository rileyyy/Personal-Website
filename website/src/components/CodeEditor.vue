<template>
  <div class="wrapper">
    <EditorTab :icon="icon"
               :filename="filename"
               :main-pane="mainPane" />
    <EditorPane :code="code"
                :language="language" />
  </div>
</template>

<script setup lang="ts">
import { LanguageFn } from 'highlight.js';

import EditorTab from './EditorTab.vue';
import EditorPane from './EditorPane.vue';

defineProps<{
  code: string,
  icon: string,
  filename: string,
  mainPane?: boolean,
  language: LanguageFn,
}>();
</script>

<style scoped>
.wrapper {
  display: flex;
  flex-direction: column;
  border-right: 1px solid var(--line-break);
  scrollbar-width: thin;
  scrollbar-color: var(--scroll-bar) transparent;
}
</style>
