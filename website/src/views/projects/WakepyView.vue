<template>
  <div class="editor-wrapper">
    <CodeEditor
                class="editor-child"
                :tabs="pyTab"
                :main-pane="true" />
    <CodeEditor
                class="editor-child"
                :tabs="englishTab"
                :main-pane="false" />
  </div>
</template>

<script setup lang="ts">
import hljs from 'highlight.js/lib/core';
import python from 'highlight.js/lib/languages/python'
import asciidoc from 'highlight.js/lib/languages/asciidoc'

import CodeEditor from '../../components/CodeEditor.vue';
import { Tab } from '@/models/Tab.ts';

hljs.registerLanguage('python', python)
hljs.registerLanguage('asciidoc', asciidoc)


const pyTab = [
  <Tab>{
    icon: 'python',
    filename: 'WakePy.py',
    language: python,
    mainPane: true,
    code: `class WakePy:
  def __description__(self):
    # WakePy is a cross-platform Python package and CLI tool designed to keep a system awake.
    with WakePy():
      keepAwake('CPU', 'forever')
      keepAwake('Screen', 'forever')

  def github_url():
    return 'https://github.com/fohrloop/wakepy'

  availableFor = [
    'Windows',
    'macOS',
    'Unix' + 'GNOME',
    'Unix' + 'KdePlasma',
    'Unix' + 'Freedesktop.org'
  ]

  stack = [
  'Python'
  ]

  def contributions():
    initial_linux_support()
    initial_macOS_support()
    bug_reports()

  def statistics(stat):
    match stat:
      case 'version':
        return "v0.10.1"
      case 'license':
        return "MIT"
      case 'downloads':
        return "20k/month"
      case 'stars':
        return 214
      case 'forks':
        return 14
      `,
  }
];

const englishTab = [
  <Tab>{
    icon: 'document',
    filename: 'WakePy.txt',
    language: asciidoc,
    mainPane: false,
    code: `WakePy
======

Wakepy is a package with an Python API and a CLI tool for keeping a system awake.

* It is a cross-platform package that supports Windows, macOS, and a variety of Linux configurations. The design is such that a computer can be kept awake with only the CPU active or with both the CPU and screen active.

* For my interest this was used for keeping customer computers awake for along running scientific tests for the Lake Shore Cryotronics python driver. This meant customers were able to run tests that were past their IT department's mandatory sleep timer, which can be incredibly valuable. WakePy is a lightweight package with at most 1 dependency but typically none.

* The tech stack for this project is entirely Python.

github: https://github.com/fohrloop/wakepy

Here are some fun statistics:
version:: v0.10.1
license:: MIT (https://www.tldrlegal.com/license/mit-license)
downloads:: 20k/month
stars:: 214
forks:: 14
`,
  }
];

</script>

<style>
.editor-wrapper {
  display: flex;
  flex-direction: row;
}

.editor-child {
  flex: 1;
}
</style>
