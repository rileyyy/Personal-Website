import android from 'material-icon-theme/icons/android.svg';
import arduino from 'material-icon-theme/icons/arduino.svg';
import azurePipelines from 'material-icon-theme/icons/azure-pipelines.svg';
import cpp from 'material-icon-theme/icons/cpp.svg';
import css from 'material-icon-theme/icons/css.svg';
import csharp from 'material-icon-theme/icons/csharp.svg';
import dart from 'material-icon-theme/icons/dart.svg';
import database from 'material-icon-theme/icons/database.svg';
import docker from 'material-icon-theme/icons/docker.svg';
import document from 'material-icon-theme/icons/document.svg';
import drone from 'material-icon-theme/icons/drone.svg';
import folderGulp from 'material-icon-theme/icons/folder-gulp.svg';
import folderPipe from 'material-icon-theme/icons/folder-pipe.svg';
import folderResource from 'material-icon-theme/icons/folder-resource.svg';
import folderServer from 'material-icon-theme/icons/folder-server.svg';
import folderTest from 'material-icon-theme/icons/folder-test.svg';
import folderTools from 'material-icon-theme/icons/folder-tools.svg';
import folderYarn from 'material-icon-theme/icons/folder-yarn.svg';
import git from 'material-icon-theme/icons/git.svg';
import godot from 'material-icon-theme/icons/godot.svg';
import graphql from 'material-icon-theme/icons/graphql.svg';
import html from 'material-icon-theme/icons/html.svg';
import java from 'material-icon-theme/icons/java.svg';
import nodejs from 'material-icon-theme/icons/nodejs.svg';
import python from 'material-icon-theme/icons/python.svg';
import pythonMisc from 'material-icon-theme/icons/python-misc.svg';
import robot from 'material-icon-theme/icons/robot.svg';
import rocket from 'material-icon-theme/icons/rocket.svg';
import stylelint from 'material-icon-theme/icons/stylelint.svg';
import testJs from 'material-icon-theme/icons/test-js.svg';
import typescriptDef from 'material-icon-theme/icons/typescript-def.svg'
import virtual from 'material-icon-theme/icons/virtual.svg';
import vue from 'material-icon-theme/icons/vue.svg';

const icons: Record<string, string> = {
  android,
  arduino,
  azurePipelines,
  cpp,
  css,
  csharp,
  dart,
  database,
  docker,
  document,
  drone,
  folderGulp,
  folderPipe,
  folderResource,
  folderServer,
  folderTest,
  folderTools,
  folderYarn,
  git,
  godot,
  graphql,
  html,
  java,
  nodejs,
  python,
  pythonMisc,
  robot,
  rocket,
  stylelint,
  testJs,
  typescriptDef,
  virtual,
  vue,
};

export function materialIcon(name: string): string {
  return icons[name] ?? '';
}
