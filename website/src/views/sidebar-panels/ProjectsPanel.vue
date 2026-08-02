<template>
  <div class="projects-panel">
    <h2 class="panel-title">Projects</h2>
    <RouterLink v-for="project in projects" :key="project.title" class="project-item" :to="project.slug">
      <img :src="project.icon" class="project-icon" />
      <div class="project-info">
        <h3 class="project-title">{{ project.title }}</h3>
        <p class="project-description">{{ project.description }}</p>
        <div class="project-actions">
          <Settings class="settings-icon" />

          <a v-if="project.github" :href="project.github" target="_blank" class="github-link">
            <GitHubIcon class="github-icon" />
            GitHub
          </a>
        </div>
      </div>
    </RouterLink>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { RouterLink } from 'vue-router';
import { Settings } from 'lucide-vue-next';
import { GitHubIcon } from 'vue3-simple-icons';
import homeAssistantIcon from "../../assets/home-assistant-logomark.svg";

const projects = ref([
  {
    icon: "/node_modules/material-icon-theme/icons/vue.svg",
    title: "This Website",
    description: "The very website you're looking at right now.",
    github: "https://github.com/rileyyy/Personal-Website/tree/sandbox/basic-vsc-design",
    slug: "/project/this-site"
  },
  {
    icon: "/node_modules/material-icon-theme/icons/python.svg",
    title: "WakePy",
    description: "Cross-platform wakelock / keep-awake / stay-awake written in Python.",
    github: "https://github.com/fohrloop/wakepy",
    slug: "/project/wakepy"
  },
  {
    icon: "/node_modules/material-icon-theme/icons/godot.svg",
    title: "PokéCraft",
    description: "Pokémon meets World of Warcraft in this fan made project.",
    github: null,
    slug: ""
  },
  {
    icon: homeAssistantIcon,
    title: "Home Assistant",
    description: "This house isn't going to run itself... or is it?",
    github: null,
    slug: ""
  }
]);
</script>

<style scoped>
.projects-panel {
  margin: 4px;
  display: flex;
  flex-direction: column;
}

.panel-title {
  font-size: 13px;
  font-weight: 600;
  margin-bottom: 6px;
  padding-left: 4px;
  text-align: left;
  color: var(--text-default);
}

.project-item {
  display: flex;
  align-items: center;
  gap: 8px;
  color: var(--text-default);
  text-decoration: none;
  padding: 4px 0;
}

.project-item:hover {
  background-color: rgba(255, 255, 255, 0.1);
}

.project-icon {
  width: 40px;
  height: 40px;
}

.project-info {
  display: flex;
  flex-direction: column;
  text-align: left;
  flex-grow: 1;
  min-width: 0;
}

.project-title {
  font-size: 14px;
  font-weight: 600;
  color: var(--text-default);
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  margin: 0;
  padding: 0;
}

.project-description {
  font-size: 12px;
  color: #aaa;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  margin: 0;
  padding: 4px 0;
}

.project-actions {
  display: flex;
  justify-content: space-between;
  flex-direction: row-reverse;
  align-items: center;
  margin-top: 2px;
}

.github-link {
  display: flex;
  align-items: center;
  font-size: 12px;
  color: var(--text-default);
  text-decoration: none;
}

.github-icon {
  width: 14px;
  height: 14px;
  margin-right: 3px;
}

.settings-icon {
  width: 14px;
  height: 14px;
  cursor: pointer;
  opacity: 0.8;
}
</style>
