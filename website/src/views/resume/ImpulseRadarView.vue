<template>
  <div class="education-container">
    <!-- Main Content -->
    <div>
      <header class="details-header">
        <img class="university-logo" src="https://cdn.brandfetch.io/id7x0XGKGg/w/600/h/300/theme/dark/logo.png?c=1dxbfHSJFAPEGdCLU4o5B" alt="Company Logo" />
        <div id="d0">
          <h1 class="name">ImpulseRadar Sweden AB</h1>
          <div class="detail-info">
            <BadgeCheck class="icon icon-accent" />
            <a class="school-url" href="https://https://impulseradargpr.com/">https://impulseradargpr.com</a>
            <p>|</p>
            <User class="icon" />
            <p>35</p>
            <p>|</p>
            <Star class="icon icon-yellow" />
            <Star class="icon icon-yellow" />
            <p>(1)</p>
          </div>
          <div class="motto">To visualize the subsurface for everyone</div>
        </div>
      </header>

      <!-- Tabs -->
      <nav class="tabs">
        <button @click="activeTab = 'responsibilities'" :class="{ active: activeTab === 'responsibilities' }">
          Responsibilities
        </button>
        <button @click="activeTab = 'deliverables'" :class="{ active: activeTab === 'deliverables' }">
          Deliverables
        </button>
        <button @click="activeTab = 'company'" :class="{ active: activeTab === 'company' }">
          Company
        </button>
      </nav>
    </div>

    <div class="education-info">
      <!-- Tab Content -->
      <section class="tab-content">
        <div v-if="activeTab === 'responsibilities'">
          <h3>Designed and implemented UI/UX for Android application-based products</h3>
          <p>
            As my primary role I worked on and implemented the User Interface, User Experience (UI/UX), and communication layer for the ViewPoint2 software.
            This software was responsible for collecting, storing, processing, and displaying ground penetrating radar data from our instruments.
            It was also necessary to communicate with the other developer that worked on the data processing and image generation to seamlessly communicate between the dart and C libraries.
          </p>

          <h3>Championed development best practices</h3>
          <p>
            Best development practices include unit testing, clean coding standards, SOLID programming ideals, and correct usage of git version control.
            As almost all previous projects were undertaken by single developers, it was necessary to try and implement these practices to support teams of multiple developers.
          </p>
        </div>
        <div v-if="activeTab === 'deliverables'">
          <p>
            The product I worked on is <a href="https://play.google.com/store/apps/details?id=com.impulseradar.viewpoint2&hl=en">ViewPoint2</a>. It was legacy software when I inherited it, and was intended to be a replacement for the original <a href="https://play.google.com/store/apps/details?id=se.impulseradar.viewpoint&hl=en">ViewPoint</a> software, with added features from other company software.
          </p>
        </div>
        <div v-if="activeTab === 'company'">
          <p>
            ImpulseRadar is focused on bringing the latest technology to market, packaged in robust and user-friendly ways. As industry professionals, our staff have been influential in bringing to market innovative GPR solutions that have often driven paradigm shifts in the application of this effective non-destructive technology.

            ImpulseRadar is Triple-A (AAA) rated by Dun & Bradstreet, in recognition of our high creditworthiness and capacity for meeting payment liabilities.
          </p>
          <p>
            Founded in 2015
            Headquartered in Malå, Sweden
            Office in Umeå, Sweden
            Office in Charleston, SC, USA
            Office in Kuala Lumpur, Malaysia
          </p>
        </div>
      </section>

      <!-- Meta-Data Sidebar -->
      <aside class="meta-sidebar">
        <table class="meta-item">
          <th>Roles</th>
          <tr>
            <td>Software Development Engineer</td>
          </tr>
        </table>
        <table class="meta-item">
          <th>Dates</th>
          <tr>
            <td>August 2025 to Present</td>
          </tr>
        </table>
        <table class="meta-item">
          <thead>
            <th>Tech Stack</th>
          </thead>
          <tbody>
            <tr>
              <td>Dart</td>
            </tr>
            <tr>
              <td>Flutter</td>
            </tr>
            <tr>
              <td>Git</td>
            </tr>
            <tr>
              <td>GitHub Actions</td>
            </tr>
          </tbody>
        </table>
        <table class="meta-item">
          <thead>
            <th>Resources</th>
          </thead>
          <tbody>
            <tr>
              <td>
                <a class="reference-link" href="https://impulseradargpr.com">Website</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link" href="https://www.facebook.com/impulseradargpr">Facebook</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link" href="https://instagram.com/impulseradar">Instagram</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link"
                   href="https://www.linkedin.com/company/impulseradar/">LinkedIn</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link" href="https://www.youtube.com/channel/UCNxTceA1g9rRbrGa6JlLoQg">YouTube</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link" href="">+46 953 100 08</a>
              </td>
            </tr>
          </tbody>
        </table>
      </aside>
    </div>
  </div>
</template>

<script setup lang="ts">
import { BadgeCheck, User, Star } from "lucide-vue-next";
import { ref } from "vue";

const activeTab = ref("responsibilities");
</script>

<style scoped>
.education-container {
  background-color: var(--black-three);
  display: flex;
  padding: 60px;
  color: #ccc;
  flex-direction: column;
}

.education-info {
  display: flex;
  width: 100%;
}

/* Header */
.details-header {
  display: flex;
  padding: 20px;
}

.details-header #d0 {
  display: flex;
  flex-direction: column;
  gap: 8px;
}

.university-logo {
  width: 100px;
  height: 50px;
  margin-right: 20px;
  margin-top: 25px;
}

.name {
  color: var(--text-default);
  margin: 0;
  text-align: left;
}

.detail-info {
  display: flex;
  align-items: center;
  gap: 8px;
}

.icon {
  width: 14px;
  height: 14px;
  color: var(--text-default);
}

.icon-accent {
  fill: var(--accent-primary);
  color: var(--black-three);
  margin-right: -2px;
}

.icon-yellow {
  color: var(--rating-stars);
  fill: var(--rating-stars);
  margin-right: -4px;
}

.school-url {
  font-size: 14px;
  color: var(--accent-primary);
}

.detail-info p {
  margin: 0;
}

.motto {
  text-align: left;
}

/* Tabs */
.tabs {
  display: flex;
  gap: 10px;
  margin-bottom: 12px;
  border-bottom: 1px solid var(--line-break);
}

.tabs button {
  background: none;
  border: none;
  color: var(--text-default);
  cursor: pointer;
  padding: 6px 12px;
  display: flex;
  align-items: center;
  gap: 5px;
  font-size: 14px;
  border-bottom: 2px solid transparent;
}

.tabs button.active {
  color: #fff;
  border-bottom: 2px solid var(--accent-primary);
}

.tab-content {
  font-size: 14px;
  padding: 0 16px;
  max-width: 75%;
  text-align: left;
  font-family: Verdana, Geneva, Tahoma, sans-serif;
  flex: 1 1 auto;
  max-height: 100vh;
  overflow-y: auto;
  scrollbar-width: thin;
  scrollbar-color: var(--scroll-bar) transparent;
}

.tab-content h3 {
  width: 100%;
  padding-top: 8px;
}

.tab-content p {
  margin: 4px 0 0 16px;
}

.tab-content p a {
  color: var(--accent-primary);
}

/* Meta-Data Sidebar */
.meta-sidebar {
  flex: 1;
  padding: 16px;
  border-radius: 6px;
  display: flex;
  flex-direction: column;
  gap: 10px;
  flex: 1 1 auto;
  max-height: 100vh;
  overflow-y: auto;
  scrollbar-width: thin;
  scrollbar-color: var(--scroll-bar) transparent;
}

.meta-item {
  text-align: left;
  border-bottom: 1px solid var(--line-break);
}

.label {
  font-size: 12px;
  color: #aaa;
  text-transform: uppercase;
  margin-bottom: 4px;
}

a {
  color: inherit;
  text-decoration: none;
  font-size: 14px;
}

th {
  font-size: 14px;
  padding-bottom: 8px;
}

td {
  font-size: 12px;
  padding: 2px;
}

.reference-link {
  font-size: 12px;
  color: var(--accent-primary);
}
</style>
