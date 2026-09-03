<template>
  <div class="education-container">
    <!-- Main Content -->
    <div>
      <header class="details-header">
        <img src="https://cdn.brandfetch.io/idZinyBgYc/w/600/h/600/theme/dark/icon.jpeg?c=1dxbfHSJFAPEGdCLU4o5B" class="university-logo" alt="University Logo" />
        <div id="d0">
          <h1 class="name">Swisslog Logistics</h1>
          <div class="detail-info">
            <BadgeCheck class="icon icon-accent" />
            <a class="school-url" href="https://https://www.swisslog.com//">swisslog.com</a>
            <p>|</p>
            <User class="icon" />
            <p>3,290</p>
            <p>|</p>
            <Star class="icon icon-yellow" />
            <Star class="icon icon-yellow" />
            <Star class="icon icon-yellow" />
            <p>(1)</p>
          </div>
          <div class="motto">The human side of automation</div>
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
          <h3>Contributed to ticket tracking solution</h3>
          <p>
            The company used a common website for ticket tracking that another developer and I found to be sluggish and difficult to use.

            Using publicly available APIs and SOAP requests for said website we were able to develop a desktop application that would make changes to the ticket as it was being worked on.
            The application also provided visual indicators of urgency, priority, and other important statistics.
          </p>

          <h3>Developed a package tracking application for automatic status notifications</h3>
          <p>
            My manager became responsible for managing the local part department while I worked for Swisslog.
            One of the issues they faced was tracking of packages due to the volume of packages and the variety of carriers.
            I developed an application that would run daily and provide an email status update for the head of the department to show package statuses.
          </p>

          <h3>Communicated with customers to resolve issues they were facing</h3>
          <p>
            Frequently customers were facing issues with their systems.
            Our team was responsible for rectifying these issues which were usually database related but were occasionally involving PLCs (Programmable Logic Controllers) or hardware.
            When we were not able to resolve the issue it was standard procedure to identify the appropriate system engineer and act as an intermediary to help resolve the issue.
          </p>
        </div>
        <div v-if="activeTab === 'deliverables'">
          <p>
            As this position was not truely a developer role, I do not have any publically available images of software I worked on.
          </p>
          <br>
          <p>
            One of the products I did get to work with was the AutoStore system when I worked as part of the set up for a customer. It was mostly debugging errors, running tests on the system, and guiding others who were applying labels and feeding the boxes into the system. All said though, the system is fascinating to watch run.
          </p>

          <img class="delivery-image" src="https://www.swisslog.com/-/media/swisslog/images/logistics-warehouse-distribution-automation/case-studies/retail--ecom/radwell-arlington/radwell-arlington-1.jpg?rev=6d343fe5e67144e39f3411b70fa67634&w=1400&hash=B859926A9A7B25BCB1AA69942B6EAE91" />
        </div>
        <div v-if="activeTab === 'company'">
          <p>
            Swisslog is a global company with Swiss roots and one of the world's leading logistics automation companies. We are headquartered in Buchs/Aarau, Switzerland and stand for innovation, quality, industry-leading software and robotics technologies developed in-house.
          </p>
          <br>
          <p>
            Swisslog delivers data-driven & robotic solutions for your logistics automation alongside reliable, modular service concepts. Collaborating with forward-thinking companies, we are committed to setting new standards in warehouse automation to provide future-proof products and solutions. As part of the KUKA Group, our customers trust the competence of our passionate employees – more than 15,000 people working across the globe.
          </p>
          <br>
          <p>
            Our range of services includes: consulting, concept studies, project implementation, customer service, cutting-edge technologies and software, all tailored to the specific requirements of your business.
          </p>
        </div>
      </section>

      <!-- Meta-Data Sidebar -->
      <aside class="meta-sidebar">
        <table class="meta-item">
          <th>Roles</th>
          <tr>
            <td>Incident Response Engineer</td>
          </tr>
        </table>
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
              <td>Java</td>
            </tr>
            <tr>
              <td>MySQL</td>
            </tr>
            <tr>
              <td>AutoHotKey</td>
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
                <a class="reference-link" href="https://swisslog.com">Website</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link" href="https://www.linkedin.com/company/swisslog">LinkedIn</a>
              </td>
            </tr>

            <tr>
              <td>
                <a class="reference-link"
                   href="https://www.instagram.com/swisslog.logistics.automation/">Instagram</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link" href="https://www.youtube.com/c/SwisslogLogisticsAutomation/?sub_confirmation=1">Youtube</a>
              </td>
            </tr>
            <tr>
              <td>
                <a class="reference-link"
                   href="https://www.facebook.com/swisslog.logistics.automation">Facebook</a>
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
  height: 100px;
  margin-right: 20px;
  border-radius: 50px;
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

.delivery-image {
  width: 80%;
  padding: 16px 32px;
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
