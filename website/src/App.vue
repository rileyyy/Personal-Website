<template>
  <div class="app-container">
    <Sidebar class="sidebar" />
    <div class="main-content">
      <RouterView />
    </div>
    <StatusBar />
  </div>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router';
import Sidebar from './components/SideBar.vue';
import StatusBar from './components/StatusBar.vue';
</script>

<style>
.app-container {
  display: flex;
  height: 100vh;
  background-color: var(--black-three);
  color: var(--text-default);
}

.sidebar {
  flex: 0 0 auto;
  overflow: auto;
}

.main-content {
  overflow: hidden;
  display: flex;
  flex-direction: column;
  align-items: center;
  scrollbar-width: thin;
  scrollbar-color: var(--scroll-bar) transparent;
  flex: 1;
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
