import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import ResumeView from '../views/resume/ResumeView.vue';
import ProjectsView from '../views/projects/ProjectsView.vue';
import SkillsView from '../views/resume/SkillsView.vue';
import ContactView from '../views/ContactView.vue';
import CNUView from '../views/resume/CNUView.vue';
import LakeShoreView from '../views/resume/LakeShoreView.vue';
import TaurusTeleSysView from '../views/resume/TaurusTeleSysView.vue';
import SwisslogView from '../views/resume/SwisslogView.vue';
import WakepyView from '../views/projects/WakepyView.vue';
import PersonalWebsiteView from '../views/projects/PersonalWebsiteView.vue';

const routes: RouteRecordRaw[] = [
  { path: '/', component: HomeView },

  { path: '/resume', component: ResumeView },
  { path: '/education/cnu', component: CNUView },
  { path: '/work/lake-shore', component: LakeShoreView },
  { path: '/work/taurus', component: TaurusTeleSysView },
  { path: '/work/swisslog', component: SwisslogView },

  { path: '/projects', component: ProjectsView },
  { path: '/project/wakepy', component: WakepyView },
  { path: '/project/this-site', component: PersonalWebsiteView },

  { path: '/skills', component: SkillsView },

  // { path: '/games', component: GamesView },

  { path: '/contact', component: ContactView },
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
