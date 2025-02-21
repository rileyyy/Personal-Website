<template>
  <div class="status-bar">
    <div class="left-section">
    <span>Vue 3 Portfolio</span>
    </div>
    <div class="right-section">
      <span>Riley Schroeder 2025</span>
    </div>
  </div>
</template>

<style scoped>
.status-bar {
  position: fixed;
  bottom: 0;
  left: 0;
  width: 100vw;
  background-color: var(--slightly-darker-black);
  padding: 4px;
  display: flex;
  justify-content: space-between;
  font-size: 12px;
  color: var(--text-default);
  border-top: 1px solid var(--line-break);
}

.left-section {
  display: flex;
  gap: 8px;
}

.right-section {
  display: flex;
  gap: 8px;
}
</style>
