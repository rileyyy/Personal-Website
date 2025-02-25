<template>
  <div class="app-container">
    <Sidebar />
    <RouterView />
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
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>
