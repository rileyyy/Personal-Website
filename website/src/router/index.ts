import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import ResumeView from '../views/ResumeView.vue';
import ProjectsView from '../views/ProjectsView.vue';
import SkillsView from '../views/SkillsView.vue';
import ContactView from '../views/ContactView.vue';
import CNUView from '../views/CNUView.vue';

const routes: RouteRecordRaw[] = [
  { path: '/', component: HomeView },
  { path: '/resume', component: ResumeView },
  { path: '/projects', component: ProjectsView },
  { path: '/skills', component: SkillsView },
  { path: '/contact', component: ContactView },
  { path: '/education/cnu', component: CNUView },
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
