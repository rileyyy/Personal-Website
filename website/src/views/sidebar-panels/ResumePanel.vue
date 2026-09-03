<template>
  <div class="resume-panel">
    <h2 class="panel-title">Resume</h2>
    <div v-for="section in resumeSections" :key="section.name" class="folder">
      <div class="folder-header" @click="toggle(section)">
        <component class="arrow" :class="{ open: section.open }" :is="ChevronRight"></component>
        <span>
          <img v-if="section.materialIcon" class="icon" :src="getIcon(section.materialIcon)">
          <component v-else-if="section.simpleIcon" :is="getSimpleIcon(section.simpleIcon)?.component"
                     :style="{ color: getSimpleIcon(section.simpleIcon)?.color }" class="icon" />
          <p> {{ section.name }}</p>
        </span>
      </div>
      <div v-if="section.open" class="files">
        <template v-for="entry in section.entries" :key="entry.info">
          <RouterLink class="file" :to="entry.slug">
            <img v-if="entry.materialIcon" class="icon" :src="getIcon(entry.materialIcon)">
            <component v-else-if="entry.simpleIcon" :is="getSimpleIcon(entry.simpleIcon)?.component"
                       :style="{ color: getSimpleIcon(entry.simpleIcon)?.color }" class="icon" />
            <p>{{ entry.info }}</p>
          </RouterLink>
          <div v-if="entry.entries" class="files">
            <RouterLink v-for="sub in entry.entries" :key="sub.info" class="file" :to="sub.slug">
              <img v-if="sub.materialIcon" class="icon" :src="getIcon(sub.materialIcon)">
              <component v-else-if="sub.simpleIcon" :is="getSimpleIcon(sub.simpleIcon)?.component"
                         :style="{ color: getSimpleIcon(sub.simpleIcon)?.color }" class="icon" />
              <p>{{ sub.info }}</p>
            </RouterLink>
          </div>
        </template>
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
  entries?: ResumeEntry[];
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
    name: 'Languages',
    open: false,
    materialIcon: 'virtual',
    entries: [
      {
        materialIcon: 'csharp',
        slug: '',
        info: 'C#',
        entries: [
          {
            simpleIcon: 'dotnet',
            slug: '',
            info: 'MAUI'
          },
          {
            simpleIcon: 'nuget',
            slug: '',
            info: 'NuGet'
          },
          {
            materialIcon: 'android',
            slug: '',
            info: 'Xamarin'
          },
        ],
      },
      {
        materialIcon: 'cpp',
        slug: '',
        info: 'C++'
      },
      {
        materialIcon: 'dart',
        slug: '',
        info: 'Dart',
        entries: [
          {
            simpleIcon: 'flutter',
            slug: '',
            info: 'Flutter'
          },
        ],
      },
      {
        materialIcon: 'java',
        slug: '',
        info: 'Java SE'
      },
      {
        materialIcon: 'python',
        slug: '',
        info: 'Python'
      },
      {
        materialIcon: 'vue',
        slug: '',
        info: 'Vue.js',
        entries: [
          {
            materialIcon: 'html',
            slug: '',
            info: 'HTML'
          },
          {
            materialIcon: 'css',
            slug: '',
            info: 'CSS'
          },
          {
            materialIcon: 'typescriptDef',
            slug: '',
            info: 'TypeScript'
          },
        ]
      },
    ],
  },
  {
    name: 'Databases',
    open: false,
    materialIcon: 'database',
    entries: [
      {
        simpleIcon: 'mysql',
        slug: '',
        info: 'MySQL'
      },
      {
        simpleIcon: 'mongoDb',
        slug: '',
        info: 'MongoDB'
      },
    ],
  },
  {
    name: 'Tools',
    open: false,
    materialIcon: 'folderTools',
    entries: [
      {
        materialIcon: 'stylelint',
        slug: '',
        info: 'Agile'
      },
      {
        materialIcon: 'folderPipe',
        slug: '',
        info: 'CI/CD',
        entries: [
          {
            materialIcon: 'azurePipelines',
            slug: '',
            info: 'Azure DevOps'
          },
          {
            simpleIcon: 'gitHubActions',
            slug: '',
            info: 'GitHub Actions'
          },
        ]
      },
      {
        materialIcon: 'folderServer',
        slug: '',
        info: 'Virtualization',
        entries: [
          {
            materialIcon: 'docker',
            slug: '',
            info: 'Docker + Compose'
          },
          {
            simpleIcon: 'virtualBox',
            slug: '',
            info: 'VirtualBox'
          },
          {
            simpleIcon: 'vmWare',
            slug: '',
            info: 'VMware'
          },
        ]
      },
      {
        simpleIcon: 'claude',
        slug: '',
        info: 'Claude'
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
    ]
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

const toggle = (item: { open?: boolean }) => {
  item.open = !item.open;
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
  padding: 4px 0;
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
