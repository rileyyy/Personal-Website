<template>
  <div class="education-container">
    <!-- Main Content -->
    <div>
      <header class="details-header">
        <img src="@/assets/cnu-sails.png" class="university-logo" alt="University Logo" />
        <div id="d0">
          <h1 class="name">Christopher Newport University</h1>
          <div class="detail-info">
            <BadgeCheck class="icon icon-accent" />
            <a class="school-url" href="https://cnu.edu/">cnu.edu</a>
            <p>|</p>
            <User class="icon" />
            <p>4,454</p>
            <p>|</p>
            <Star class="icon icon-yellow" />
            <Star class="icon icon-yellow" />
            <Star class="icon icon-yellow" />
            <Star class="icon icon-yellow" />
            <StarHalf class="icon icon-yellow" />
            <p>(1)</p>
          </div>
          <div class="motto">Anchored in excellence</div>
        </div>
      </header>

      <!-- Tabs -->
      <nav class="tabs">
        <button @click="activeTab = 'overview'" :class="{ active: activeTab === 'overview' }">
          Overview
        </button>
      </nav>
    </div>

    <div class="education-info">
      <!-- Tab Content -->
      <section class="tab-content">
        <div v-if="activeTab === 'overview'">
          <h2>Who We Are</h2>
          <p>At Christopher Newport University we care about minds and hearts.
            Our primary purpose is to form good citizens and leaders.
            We believe real success is a life well lived.
            We want our students to choose to live lives of meaning and consequence and purpose.
            We call that a life of significance.</p>

          <p>Because we care about minds, our curriculum is based on the liberal arts and sciences.
            We emphasize the study of leadership and have developed a nationally respected President's Leadership
            Program.
            Our core curriculum is rigorous, cited by the American Council of Trustees and Alumni as the strongest core
            curriculum of any public college or university in America.</p>

          <p>Because we care about hearts, our students perform thousands of hours of community service.
            We built a chapel and celebrate our speaking tradition and honor code.</p>

          <p>We want our students to lead, serve, engage and set the world on fire.
            That’s what makes Christopher Newport special.</p>
        </div>
      </section>

      <!-- Meta-Data Sidebar -->
      <aside class="meta-sidebar">
        <table class="meta-item">
          <th>Degree</th>
          <tr>
            <td>B.S. Computer Science</td>
            <td>2014</td>
          </tr>
          <tr>
            <td>B.S. Computer Engineering</td>
            <td>2014</td>
          </tr>
        </table>
        <table class="meta-item">
          <th>Resources</th>
          <tr>
            <td>
              <a class="reference-link" href="https://cnu.edu">Website</a>
            </td>
          </tr>
          <tr>
            <td>
              <a class="reference-link"
                 href="https://www.linkedin.com/edu/christopher-newport-university-19570">LinkedIn</a>
            </td>
          </tr>
          <tr>
            <td>
              <a class="reference-link" href="https://www.facebook.com/christophernewportuniversity">Facebook</a>
            </td>
          </tr>
          <tr>
            <td>
              <a class="reference-link" href="http://instagram.com/christophernewportu">Instagram</a>
            </td>
          </tr>
          <tr>
            <td>
              <a class="reference-link" href="https://www.threads.net/@christophernewportu">Threads</a>
            </td>
          </tr>
          <tr>
            <td>
              <a class="reference-link" href="http://www.youtube.com/christophernewportu">Youtube</a>
            </td>
          </tr>
        </table>
      </aside>
    </div>
  </div>
</template>

<script setup lang="ts">
import { BadgeCheck, Star, StarHalf, User } from "lucide-vue-next";
import { ref } from "vue";

const activeTab = ref("overview");
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
  height: 100px;
  padding-right: 20px;
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
  width: 75%;
  text-align: left;
  font-family: Verdana, Geneva, Tahoma, sans-serif;
  flex: 1 1 auto;
  max-height: 100vh;
  overflow-y: auto;
  scrollbar-width: thin;
  scrollbar-color: var(--scroll-bar) transparent;
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
