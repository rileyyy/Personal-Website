<template>
  <div class="wrapper">
    <TabContainer
                  :tabs="tabs"
                  :main-pane="mainPane" />
    <EditorPane v-if="activeTab"
                :code="activeTab.code"
                :language="activeTab.language" />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';

import TabContainer from './TabContainer.vue';
import EditorPane from './EditorPane.vue';
import { Tab } from '@/models/Tab.ts';

var props = defineProps<{
  tabs: Tab[],
  mainPane: boolean,
}>();

const activeTab = ref<Tab | null>(
  props.tabs.length > 0 ? props.tabs[0] : null
);
</script>

<style scoped>
.wrapper {
  display: flex;
  flex-direction: column;
  border-right: 1px solid var(--line-break);
  scrollbar-width: thin;
  scrollbar-color: var(--scroll-bar) transparent;
}

.tab-container {
  display: flex;
  flex-direction: row;
}
</style>
