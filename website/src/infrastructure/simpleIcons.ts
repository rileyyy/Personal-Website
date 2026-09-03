import type { Component } from 'vue';
import { GitHubIcon, MongoDbIcon } from 'vue3-simple-icons';

export interface SimpleIcon {
  component: Component;
  color: string;
}

const icons: Record<string, SimpleIcon> = {
  gitHub: { component: GitHubIcon, color: '#181717' },
  mongoDb: { component: MongoDbIcon, color: '#47A248' },
};

export function simpleIcon(name: string): SimpleIcon | undefined {
  return icons[name];
}
