<template>
  <div class="editor-wrapper">
    <CodeEditor
                class="editor-child"
                :tabs="devTabs"
                :main-pane="false" />
    <CodeEditor
                class="editor-child"
                :tabs="englishTab"
                :main-pane="true" />
  </div>
</template>

<script setup lang="ts">
import hljs from 'highlight.js/lib/core';
import javascript from 'highlight.js/lib/languages/javascript'
import csharp from 'highlight.js/lib/languages/csharp'
import asciidoc from 'highlight.js/lib/languages/asciidoc'

import CodeEditor from '../../components/CodeEditor.vue';
import { Tab } from '../../models/Tab.ts';

hljs.registerLanguage('javascript', javascript)
hljs.registerLanguage('asciidoc', asciidoc)

const devTabs = [
  <Tab>{
    materialIcon: 'vue',
    filename: 'Frontend.vue',
    language: javascript,
    code: `<template>
  <WebsiteTheme name="VS Code">
    <NavigationDrawer />
    <EditorPane />
    <StatusBar />
  </WebsiteTheme>
</template>`,
  },

  <Tab>{
    materialIcon: 'csharp',
    filename: 'Backend.cs',
    language: csharp,
    code: ``,
  },

  <Tab>{
    simpleIcon: 'mongoDb',
    filename: 'Database.txt',
    language: asciidoc,
    code: ``,
  }
];

const englishTab = [
  <Tab>{
    materialIcon: 'document',
    filename: 'This Website.txt',
    language: asciidoc,
    code: ``,
  }
];
</script>

<style scoped>
.editor-wrapper {
  display: flex;
  flex-direction: row;
  flex: 1;
  width: 100%;
}

.editor-child {
  flex: 1;
}
</style>