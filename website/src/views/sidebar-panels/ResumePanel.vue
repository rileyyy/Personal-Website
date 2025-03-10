<template>
  <div class="resume-panel">
    <h2 class="panel-title">Resume</h2>
    <div v-for="section in resumeSections" :key="section.name" class="folder">
      <div class="folder-header" @click="toggleSection(section.name)">
        <component class="arrow" :class="{ open: section.open }" :is="ChevronRight"></component>
        <span><img class="icon" :src=getIcon(section.icon)>
          <p> {{ section.name }}</p>
        </span>
      </div>
      <div v-if="section.open" class="files">
        <RouterLink v-for="entry in section.entries" :key="entry.info" class="file" :to="entry.slug">
          <img class="icon" :src=getIcon(entry.icon)>
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

const resumeSections = ref([
  {
    name: 'Education',
    open: false,
    icon: 'folder-test',
    entries: [
      {
        icon: 'graphql',
        slug: '/education/cnu',
        info: 'B.S. Computer Science'
      },
      {
        icon: 'graphql',
        slug: '/education/cnu',
        info: 'B.S. Computer Engineering'
      }]
  },
  {
    name: 'Employment',
    open: false,
    icon: 'folder-resource',
    entries: [
      {
        icon: 'test-js',
        slug: '/work/lake-shore',
        info: 'Lake Shore Cryotronics'
      },
      {
        icon: 'rocket',
        slug: '/work/taurus',
        info: 'Taurus TeleSys',
      },
      {
        icon: 'robot',
        slug: '/work/swisslog',
        info: 'Swisslog Logistics'
      }]
  },
  {
    name: 'Skills',
    open: false,
    icon: 'folder-gulp',
    entries: [
      {
        icon: 'csharp',
        slug: '',
        info: 'C#'
      },
      {
        icon: 'android',
        slug: '',
        info: 'Xamarin (Android)'
      },
      {
        icon: 'cpp',
        slug: '',
        info: 'C++'
      },
      {
        icon: 'python',
        slug: '',
        info: 'Python'
      },
      {
        icon: 'database',
        slug: '',
        info: 'MySQL'
      },
      {
        icon: 'database',
        slug: '',
        info: 'MongoDB'
      },
      {
        icon: 'azure-pipelines',
        slug: '',
        info: 'Azure DevOps'
      },
      {
        icon: 'stylelint',
        slug: '',
        info: 'Agile'
      },
      {
        icon: 'git',
        slug: '',
        info: 'Git'
      },
      {
        icon: 'godot',
        slug: '',
        info: 'Godot'
      },
      {
        icon: 'java',
        slug: '',
        info: 'Java SE'
      },
      {
        icon: 'docker',
        slug: '',
        info: 'Docker'
      },
      {
        icon: 'vue',
        slug: '',
        info: 'Vue.js'
      },
      {
        icon: 'html',
        slug: '',
        info: 'HTML/CSS'
      }]
  },
  {
    name: 'Projects',
    open: false,
    icon: 'folder-yarn',
    entries: [
      {
        icon: 'nodejs',
        slug: 'project/this-site',
        info: 'This Website'
      },
      {
        icon: 'python-misc',
        slug: '/project/wakepy',
        info: 'WakePy'
      },
      {
        icon: 'drone',
        slug: '',
        info: 'PokeCraft'
      },
      {
        icon: 'arduino',
        slug: '',
        info: 'Home Assistant'
      }]
  },
]);

const getIcon = (name: string) =>
  `/node_modules/material-icon-theme/icons/${name}.svg`;

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
