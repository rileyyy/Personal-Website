<template>
  <div class="main-content">
    <div class="warning">
      <Construction class="construction-icon" />
      <h1>Woah! Watch your step! <br> This is an active construction zone!</h1>
      <Construction class="construction-icon" />
    </div>
    <h2>You're welcome to look around but you might want to wear this: </h2>
    <img class="hardhat" src="@/assets/hardhat.png">
  </div>
</template>

<script setup lang="ts">
import { Construction } from 'lucide-vue-next';
</script>

<style>
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
