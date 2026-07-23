<template>
  <div class="editor-wrapper">
    <div class="wrapper">
      <EditorTab icon="vue"
                 filename="frontend.vue" />
      <div class="editor-pane-wrapper">
        <EditorPane class="adjustme"
                    :code="vue"
                    :language="xml" />
        <EditorPane class="adjustme"
                    :code="scriptCode"
                    :language="xml" />
        <EditorPane class="adjustme"
                    :code="vue"
                    :language="xml" />
      </div>
    </div>
    <div class="editor-wrapper-sub">
      <CodeEditor
                  class="editor-child"
                  :code="cSharp"
                  icon="csharp"
                  :language="csharp"
                  filename="backend.cs" />
      <CodeEditor
                  class="editor-child"
                  :code="english"
                  icon="document"
                  :language="asciidoc"
                  filename="website.txt" />
    </div>
  </div>
</template>

<script setup lang="ts">
import CodeEditor from '../components/CodeEditor.vue';
import EditorTab from '../components/EditorTab.vue';
import EditorPane from '../components/EditorPane.vue';

const vue = `<template>
  <WebsiteTheme name="VS Code">
    <NavigationDrawer />
    <EditorPane />
    <StatusBar />
  </WebsiteTheme>
</template>`;

const scriptCode = `<scrip` + `t setup lang="ts">
// Technologies Used
const framework = "Vue 3";
const styling = ["CSS Variables", "Flexbox", "Custom Components"];
const stateManagement = "Pinia";
const backend = "ASP.NET Core";
const database = "MongoDB";
</scrip` + `t>

<style scoped>
/* Custom styles closely match VS Code */
</style>`;

const cSharp = ``;

const english = `dasdasd`;
</script>

<style scoped>
.editor-wrapper {
  display: flex;
  flex-direction: row;
  height: 100vh;
}

.editor-pane-wrapper {
  overflow-y: auto;
  max-height: 100vh;
  border-right: 1px solid var(--line-break);
  scrollbar-width: thin;
  scrollbar-color: var(--scroll-bar) transparent;
  flex: 1 1 auto;
}

.editor-wrapper-sub {
  display: flex;
  flex-direction: column;
}

.editor-child {
  flex: 1;
}
</style>