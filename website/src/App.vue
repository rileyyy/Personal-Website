<template>
  <div class="app-container">
    <Sidebar />
    <div class="main-content">
      <RouterView />
      <div class="warning">
        <Construction class="construction-icon"/>
        <h1>Woah! Watch your step! <br> This is an active construction zone!</h1>
        <Construction class="construction-icon"/>
    </div>
    <h2>You're welcome to look around but you might want to wear this: </h2>
    <img class="hardhat" src="@/assets/hardhat.png">
    </div>
    <StatusBar />
  </div>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router';
import Sidebar from './components/Sidebar.vue';
import StatusBar from './components/StatusBar.vue';
import { Construction } from 'lucide-vue-next';
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

.construction-icon {
  height: 40px;
  width: 40px;
}

.warning {
  display: flex;
  align-items: center;
  gap: 40px;
}

.hardhat {
  height: 200px;
}
</style>
