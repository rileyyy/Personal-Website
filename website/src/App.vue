<template>
  <div class="app-container">
    <div class="content-row">
      <Sidebar class="sidebar" />
      <div class="main-content">
        <RouterView />
      </div>
    </div>
    <StatusBar />
  </div>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router';
import Sidebar from '@/components/SideBar.vue';
import StatusBar from '@/components/StatusBar.vue';
</script>

<style>
.app-container {
  display: flex;
  flex-direction: column;
  height: 100vh;
  background-color: var(--black-three);
  color: var(--text-default);
}

.content-row {
  display: flex;
  flex: 1;
  min-height: 0;
}

.sidebar {
  flex: 0 0 auto;
  overflow: hidden;
  min-height: 0;
}

.main-content {
  overflow: hidden;
  display: flex;
  flex-direction: column;
  align-items: center;
  scrollbar-width: thin;
  scrollbar-color: var(--scroll-bar) transparent;
  flex: 1;
  min-height: 0;
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
</style>
