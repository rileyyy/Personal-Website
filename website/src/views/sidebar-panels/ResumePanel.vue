<template>
  <div class="resume-panel">
    <h2 class="panel-title">Resume</h2>
    <div v-for="section in resumeSections" :key="section.name" class="folder">
      <div class="folder-header" @click="toggleSection(section.name)">
        <component class="arrow" :class="{ open: section.open }" :is="ChevronRight"></component>
        <span>
          <img v-if="section.materialIcon" class="icon" :src="getIcon(section.materialIcon)">
          <component v-else-if="section.simpleIcon" :is="getSimpleIcon(section.simpleIcon)?.component"
                     :style="{ color: getSimpleIcon(section.simpleIcon)?.color }" class="icon" />
          <p> {{ section.name }}</p>
        </span>
      </div>
      <div v-if="section.open" class="files">
        <RouterLink v-for="entry in section.entries" :key="entry.info" class="file" :to="entry.slug">
          <img v-if="entry.materialIcon" class="icon" :src="getIcon(entry.materialIcon)">
          <component v-else-if="entry.simpleIcon" :is="getSimpleIcon(entry.simpleIcon)?.component"
                     :style="{ color: getSimpleIcon(entry.simpleIcon)?.color }" class="icon" />
          <p>{{ entry.info }}</p>
        </RouterLink>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { RouterLink } from 'vue-router';
import { ChevronRight } from 'lucide-vue-next';
import { materialIcon as getIcon } from '@/infrastructure/materialIcons';
import { simpleIcon as getSimpleIcon } from '@/infrastructure/simpleIcons';

interface ResumeEntry {
  materialIcon?: string;
  simpleIcon?: string;
  slug: string;
  info: string;
}

interface ResumeSection {
  name: string;
  open: boolean;
  materialIcon?: string;
  simpleIcon?: string;
  entries: ResumeEntry[];
}

const resumeSections = ref<ResumeSection[]>([
  {
    name: 'Education',
    open: false,
    materialIcon: 'folderTest',
    entries: [
      {
        materialIcon: 'graphql',
        slug: '/education/cnu',
        info: 'B.S. Computer Science'
      },
      {
        materialIcon: 'graphql',
        slug: '/education/cnu',
        info: 'B.S. Computer Engineering'
      }]
  },
  {
    name: 'Employment',
    open: false,
    materialIcon: 'folderResource',
    entries: [
      {
        materialIcon: 'testJs',
        slug: '/work/lake-shore',
        info: 'Lake Shore Cryotronics'
      },
      {
        materialIcon: 'rocket',
        slug: '/work/taurus',
        info: 'Taurus TeleSys',
      },
      {
        materialIcon: 'robot',
        slug: '/work/swisslog',
        info: 'Swisslog Logistics'
      }]
  },
  {
    name: 'Skills',
    open: false,
    materialIcon: 'folderGulp',
    entries: [
      {
        materialIcon: 'csharp',
        slug: '',
        info: 'C#'
      },
      {
        materialIcon: 'android',
        slug: '',
        info: 'Xamarin (Android)'
      },
      {
        materialIcon: 'cpp',
        slug: '',
        info: 'C++'
      },
      {
        materialIcon: 'python',
        slug: '',
        info: 'Python'
      },
      {
        materialIcon: 'database',
        slug: '',
        info: 'MySQL'
      },
      {
        simpleIcon: 'mongoDb',
        slug: '',
        info: 'MongoDB'
      },
      {
        materialIcon: 'azurePipelines',
        slug: '',
        info: 'Azure DevOps'
      },
      {
        materialIcon: 'stylelint',
        slug: '',
        info: 'Agile'
      },
      {
        materialIcon: 'git',
        slug: '',
        info: 'Git'
      },
      {
        materialIcon: 'godot',
        slug: '',
        info: 'Godot'
      },
      {
        materialIcon: 'java',
        slug: '',
        info: 'Java SE'
      },
      {
        materialIcon: 'docker',
        slug: '',
        info: 'Docker'
      },
      {
        materialIcon: 'vue',
        slug: '',
        info: 'Vue.js'
      },
      {
        materialIcon: 'html',
        slug: '',
        info: 'HTML/CSS'
      }]
  },
  {
    name: 'Projects',
    open: false,
    materialIcon: 'folderYarn',
    entries: [
      {
        materialIcon: 'nodejs',
        slug: '/project/this-site',
        info: 'This Website'
      },
      {
        materialIcon: 'pythonMisc',
        slug: '/project/wakepy',
        info: 'WakePy'
      },
      {
        materialIcon: 'drone',
        slug: '',
        info: 'PokeCraft'
      },
      {
        materialIcon: 'arduino',
        slug: '',
        info: 'Home Assistant'
      }]
  },
]);

const toggleSection = (name: string) => {
  const section = resumeSections.value.find((s) => s.name === name);
  if (section) section.open = !section.open;
};
</script>

<style scoped>
.resume-panel {
  color: var(--text-default);
  font-size: 14px;
  width: 100%;
  height: 95%;
}

.panel-title {
  font-size: 16px;
  margin-bottom: 4px;
  text-align: left;
  text-transform: uppercase;
}

.folder-header {
  display: flex;
  align-items: center;
  cursor: pointer;
  margin: 4px 0;
}

.folder-header:hover {
  background-color: rgba(255, 255, 255, 0.1);
}

.folder-header span {
  display: flex;
}

p {
  margin: 0;
  /* Desenders cause text to float high of center, bump it down */
  padding-top: 2px;
}

.arrow {
  transition: transform 0.3s ease;
  height: 20px;
}

.arrow.open {
  transform: rotate(90deg);
}

.files {
  margin-left: 32px;
}

.file {
  cursor: pointer;
  text-align: left;
  display: flex;
  align-items: center;
  padding: 4px 0;
  text-decoration: inherit;
  color: inherit;
}

.file:hover {
  background-color: rgba(255, 255, 255, 0.1);
}

.icon {
  height: 20px;
  width: 20px;
  margin-right: 4px;
}
</style>
