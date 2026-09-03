<template>
  <div class="games-panel">
    <h2 class="panel-title">Games</h2>
    <div v-for="section in sections" :key="section.name" class="folder">
      <div class="folder-header" @click="toggleSection(section.name)">
        <component class="arrow" :class="{ invisible: section.open === null, open: section.open }" :is="ChevronRight"></component>
        <span><img class="icon" :src=materialIcon(section.icon)>
          <p> {{ section.name }}</p>
        </span>
      </div>
      <div v-if="section.open" class="files">
        <RouterLink v-for="entry in section.entries" :key="entry.name" class="file" :to="entry.slug">
          <img class="icon" :src=materialIcon(entry.icon)>
          <p>{{ entry.name }}</p>
        </RouterLink>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { RouterLink } from 'vue-router';
import { ChevronRight } from 'lucide-vue-next';
import { materialIcon } from '@/infrastructure/materialIcons';

interface Game {
  name: string;
  open: boolean | null;
  icon: string;
  slug: string | null;
  entries: Entry[];
}

interface Entry {
  name: string;
  icon: string;
  slug: string;
}

const sections = ref<Game[]>([
  {
    name: 'Old School Runescape',
    open: false,
    icon: 'folderTest',
    slug: '',
    entries: [
      {
        name: 'CptRileyy',
        icon: '',
        slug: '',
      },
      {
        name: 'Pantalaemonl',
        icon: '',
        slug: '',
      },
    ]
  },
  {
    name: 'Old School Runescape (Leagues)',
    open: false,
    icon: 'folderTest',
    slug: '',
    entries: [
      {
        name: 'CptRiley (Twisted)',
        icon: '',
        slug: '',
      },
      {
        name: 'CptRiley (Trailablazer)',
        icon: '',
        slug: '',
      },
      {
        name: 'CptRiley (Shattered Relics)',
        icon: '',
        slug: '',
      },
      {
        name: 'CptRiley (Trailblazed Reloaded)',
        icon: '',
        slug: '',
      },
      {
        name: 'CptRiley (Raging Echoes)',
        icon: '',
        slug: '',
      },
      {
        name: 'CptRiley (Demonic Pacts)',
        icon: '',
        slug: '',
      },
    ]
  },
  {
    name: 'RuneScape 3',
    open: false,
    icon: '',
    slug: '',
    entries: [
      {
        name: 'Sadamantite',
        icon: '',
        slug: '',
      },
    ],
  },
  {
    name: 'RuneScape 3 (Leagues)',
    open: false,
    icon: '',
    slug: '',
    entries: [{
      name: 'Pantalaemonl (Catalyst)',
      icon: '',
      slug: '',
    },
    {
      name: 'Sadamantite (Equilibrium)',
      icon: '',
      slug: '',
    },
    ],
  },

  {
    name: 'Factorio',
    open: false,
    icon: '',
    slug: '',
    entries: [],
  },

]);

const toggleSection = (name: string) => {
  const section = sections.value.find((s) => s.name === name);
  if (section) section.open = !section.open;
};
</script>

<style scoped>
.invisible {
  visibility: hidden;
}

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
