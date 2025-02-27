<template>
  <div class="sidebar-container">
    <div class="icon-bar">
      <button v-for="item in sidebarItems" :key="item.name" @click="changeSidebarOrNavigate(item)">

        <div class="active-indicator" v-if="activeView === item.name"></div>
        <component :is="item.icon" :class="{ active: activeView === item.name }" />
      </button>
    </div>

    <div class="details-panel" v-if="activeView && activeComponent">
      <component :is="activeComponent" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed, DefineComponent } from 'vue';
import { useRouter } from 'vue-router';
import { BriefcaseBusiness, House, Folder, Contact } from 'lucide-vue-next';

import ResumePanel from "../views/sidebar-panels/ResumePanel.vue";
import ProjectsPanel from '../views/sidebar-panels/ProjectsPanel.vue';

interface SidebarItem {
  name: string;
  icon: any;
  view: string;
  component: DefineComponent | null;
  slug: string | null;
}

const router = useRouter();
const activeView = ref<string | null>('Home');

const sidebarItems: SidebarItem[] = [
  {
    name: 'Home',
    icon: House,
    view: '',
    component: null,
    slug: '/',
  },
  {
    name: 'Resume',
    icon: BriefcaseBusiness,
    view: 'resume',
    component: ResumePanel as DefineComponent,
    slug: null,
  },
  {
    name: 'Projects',
    icon: Folder,
    view: 'projects',
    component: ProjectsPanel as DefineComponent,
    slug: null,
  },
  {
    name: 'Contact',
    icon: Contact,
    view: 'contact',
    component: null,
    slug: '/contact',
  },
];

const changeSidebarOrNavigate = (item: SidebarItem) => {
  activeView.value = item.name;
  if (item.slug) {
    router.push(item.slug ?? '/');
  }
};

const activeComponent = computed(() => {
  if (activeView.value === null) {
    return null;
  } else {
    return sidebarItems.find(item => item.name === activeView.value)?.component;
  }
});
</script>

<style scoped>
.sidebar-container {
  display: flex;
  height: 100vh;
  background-color: var(--slightly-darker-black);
}

.icon-bar {
  display: flex;
  flex-direction: column;
  padding: 8px 0;
  width: 50px;
  align-items: center;
  border-right: 1px solid var(--line-break);
}

.icon-bar button {
  all: unset;
  width: 48px;
  height: 48px;
  display: flex;
  align-items: center;
  justify-content: center;
  position: relative;
  cursor: pointer;
  transition: background 0.2s;
  color: #b3b3b3;
}

.active {
  color: var(--text-default);
}

.icon-bar button:hover {
  color: white;
}

.icon {
  width: 24px;
  height: 24px;
}

.details-panel {
  width: 275px;
  background-color: var(--slightly-darker-black);
  padding: 0 8px;
}

.active-indicator {
  position: absolute;
  left: 0;
  top: 50%;
  transform: translateY(-50%);
  width: 2px;
  height: 85%;
  background-color: var(--accent-primary);
}
</style>
