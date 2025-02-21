import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import ResumeView from '../views/ResumeView.vue';
import ProjectsView from '../views/ProjectsView.vue';
import SkillsView from '../views/SkillsView.vue';
import ContactView from '../views/ContactView.vue';

const routes: RouteRecordRaw[] = [
  { path: '/resume', component: ResumeView },
  { path: '/projects', component: ProjectsView },
  { path: '/skills', component: SkillsView },
  { path: '/contact', component: ContactView },
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
