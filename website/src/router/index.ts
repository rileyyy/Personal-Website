import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import ResumeView from '../views/ResumeView.vue';
import ProjectsView from '../views/ProjectsView.vue';
import SkillsView from '../views/SkillsView.vue';
import ContactView from '../views/ContactView.vue';
import CNUView from '../views/CNUView.vue';
import LakeShoreView from '../views/LakeShoreView.vue';
import TaurusTeleSysView from '../views/TaurusTeleSysView.vue';
import SwisslogView from '../views/SwisslogView.vue';

const routes: RouteRecordRaw[] = [
  { path: '/', component: HomeView },

  { path: '/resume', component: ResumeView },
  { path: '/education/cnu', component: CNUView },
  { path: '/work/lake-shore', component: LakeShoreView },
  { path: '/work/taurus', component: TaurusTeleSysView },
  { path: '/work/swisslog', component: SwisslogView },

  { path: '/projects', component: ProjectsView },

  { path: '/skills', component: SkillsView },

  { path: '/contact', component: ContactView },
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
