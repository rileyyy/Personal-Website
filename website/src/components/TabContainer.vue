<template>
  <div class="editor-tab">
    <div class="tab-container">
      <EditorTab v-for="tab in tabs" :key="tab.filename"
                 :class="{ selectedTab: tab === activeTab }"
                 :icon="tab.icon"
                 :filename="tab.filename"
                 @click="activeTab = tab"
                 :selected="tab === activeTab" />
    </div>
    <div class="tab-right">
      <GitHubIcon class="icon" v-if="mainPane" />
      <LucideBug class="icon" v-if="mainPane" />
      <LucidePlay class="icon" v-if="mainPane" />
      <LucideColumns2 class="icon" v-if="mainPane" />
      <Ellipsis class="icon" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { LucideBug, LucidePlay, LucideColumns2, Ellipsis } from 'lucide-vue-next';
import { GitHubIcon } from 'vue3-simple-icons';
import EditorTab from './EditorTab.vue';
import { Tab } from '../models/Tab.ts';
import { ref } from 'vue';

var props = defineProps<{
  tabs: Tab[],
  mainPane: boolean,
}>();

const activeTab = ref<Tab | null>(
  props.tabs.length > 0 ? props.tabs[0] : null
);
</script>

<style scoped>
.editor-tab {
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-bottom: 1px solid var(--line-break);
  font-family: 'Segoe UI', sans-serif;
  height: 35px;
}

.tab-container {
  display: flex;
  flex: 1;
}

.tab-right {
  display: flex;
  align-items: center;
  gap: 8px;
  padding-right: 8px;
}

.icon {
  color: #a9a9a9;
  width: 16px;
  height: 16px;
  cursor: pointer;
  transition: color 0.2s;
}
</style>
