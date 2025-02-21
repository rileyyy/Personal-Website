<template>
  <div class="app-container">
    <Sidebar />
    <div class="main-content">
      <RouterView />
    </div>
    <StatusBar />
  </div>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router';
import Sidebar from './components/Sidebar.vue';
import StatusBar from './components/StatusBar.vue';
</script>

<style scoped>
.app-container {
  display: flex;
  height: 100vh;
  background-color: var(--black-three);
  color: var(--text-default);
}

.main-content {
  flex-grow: 1;
  padding: 16px;
}
</style>
