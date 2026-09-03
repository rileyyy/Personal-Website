import type { Component } from 'vue';
import { ClaudeIcon, DotNetIcon, FlutterIcon, GitHubActionsIcon, GitHubIcon, HomeAssistantIcon, MongoDbIcon, MySqlIcon, NuGetIcon, VirtualBoxIcon, VMwareIcon } from 'vue3-simple-icons';

export interface SimpleIcon {
  component: Component;
  color: string;
}

const icons: Record<string, SimpleIcon> = {
  claude: { component: ClaudeIcon, color: '#D97757' },
  dotnet: { component: DotNetIcon, color: '#512BD4' },
  flutter: { component: FlutterIcon, color: '#02569B' },
  gitHub: { component: GitHubIcon, color: '#181717' },
  gitHubActions: { component: GitHubActionsIcon, color: '#2088FF' },
  homeAssistant: { component: HomeAssistantIcon, color: '#18BCF2' },
  mongoDb: { component: MongoDbIcon, color: '#47A248' },
  mysql: { component: MySqlIcon, color: '#4479A1' },
  nuget: { component: NuGetIcon, color: '#004880' },
  virtualBox: { component: VirtualBoxIcon, color: '#2F61B4' },
  vmWare: { component: VMwareIcon, color: '#607078' },
};

export function simpleIcon(name: string): SimpleIcon | undefined {
  return icons[name];
}
