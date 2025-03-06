<template>
  <div class="education-container">
    <!-- Main Content -->
    <div>
      <header class="details-header">
        <img src="@/assets/lake-shore-logo.jpeg" class="university-logo" alt="University Logo" />
        <div id="d0">
          <h1 class="name">Lake Shore Cryotronics, Inc</h1>
          <div class="detail-info">
            <BadgeCheck class="icon icon-accent" />
            <a class="school-url" href="https://lakeshore.com/">lakeshore.com</a>
            <p>|</p>
            <User class="icon" />
            <p>193</p>
          </div>
          <div class="motto">Advancing Science</div>
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
          <p>Designed and implemented UI/UX for Android application-based products.</p>
          <p>Communicated with customers, developers, and stakeholders to gather and implement requirements.</p>
          <p>Resolved issues in embedded systems, Android OS, Python APIs, .NET applications, and AzureDevOps CI/CD.</p>
          <p>Led engineers and interns in the design and implementation of features using agile best practices.</p>
          <p>Wrote technical documentation for engineers and customers.</p>
        </div>
        <div v-if="activeTab === 'deliverables'">
          <p></p>
        </div>
        <div v-if="activeTab === 'company'">
          <p></p>
        </div>
      </section>

      <!-- Meta-Data Sidebar -->
      <aside class="meta-sidebar">
        <table class="meta-item">
          <th>Dates</th>
          <tr>
            <td>April 2019 to May 2024</td>
          </tr>
        </table>
        <table class="meta-item">
          <thead>
            <th>Tech Stack</th>
          </thead>
          <tbody>
            <tr>
              <td>C#/.NET</td>
            </tr>
            <tr>
              <td>Embedded C++</td>
            </tr>
            <tr>
              <td>Python</td>
            </tr>
            <tr>
              <td>Azure DevOps</td>
            </tr>
            <tr>
              <td>Git</td>
            </tr>
            <tr>
              <td>Agile Kanban + Scrum</td>
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
                <a class="reference-link" href="https://lakeshore.com">Website</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link" href="https://github.com/lakeshorecryotronics">Github</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link" href="https://www.linkedin.com/company/lake-shore-cryotronics">LinkedIn</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link"
                   href="https://twitter.com/intent/follow?original_referer=http%3A%2F%2Fwww.lakeshore.com%2FPages%2FHome.aspx&region=follow_link&screen_name=lakeshorecryo&source=followbutton&variant=2.0">Twitter</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link" href="https://www.youtube.com/user/LakeShoreCryo">Youtube</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link" href="">+01 614 891 2243</a>
              </td>
            </tr>
          </tbody>
        </table>
      </aside>
    </div>
  </div>
</template>

<script setup lang="ts">
import { BadgeCheck, User } from "lucide-vue-next";
import { ref } from "vue";

const activeTab = ref("responsibilities");
</script>

<style scoped>
.education-container {
  background-color: var(--black-three);
  width: 100vw;
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
}

/* Meta-Data Sidebar */
.meta-sidebar {
  flex: 1;
  padding: 16px;
  border-radius: 6px;
  display: flex;
  flex-direction: column;
  gap: 10px;
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
