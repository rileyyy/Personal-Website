<template>
  <div class="education-container">
    <!-- Main Content -->
    <div>
      <header class="details-header">
        <img src="https://cdn.brandfetch.io/id36yd5Cr6/w/200/h/200/theme/dark/icon.jpeg?c=1dxbfHSJFAPEGdCLU4o5B" class="university-logo" alt="University Logo" />
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
          <h3>Designed and implemented UI/UX for Android application-based products</h3>
          <p>
            As my primary role I worked with a team of developers that designed and implemented the User Interface and User Experience (UI/UX) for several of our scientific instruments.
            These instruments ran a secured version of Android on a specially developed board, effectively making this software an Android application.
            The designs accounted for different criteria than that of AppStore applications due to the use case.
            For example, a typical user is viewing the isntrument at arm's-length while it sits on a workbench, instead of holding a phone close to their phase.
            We also sought to make sure our application complied with contrast requirements for the visually impaired and those using specialized eyeware.
          </p>

          <h3>Communicated with customers, developers, and stakeholders</h3>
          <p>
            Like most agile companies we gathered requirements and implemented them before presenting our changes, at the end of each sprint, to those who are vested in the process.
            This meant being able to communicate changes on a high level to those who are not as technically savy as well as in detail to developers who are looking for optimizations and bugs.
          </p>

          <h3>Resolved issues in the various systems</h3>
          <p>
            Even though Lake Shore is a company of nearly two hundred, the development teams were small.
            Therefore each engineer was responsible for a large part of the stack.
            This meant making changes to our embedded systems, Android OS, Python APIs, .NET applications, and Azure DevOps CI/CD.
          </p>

          <h3>Led engineers and interns in the design and implementation of features.</h3>
          <p>
            Lake Shore had a strong and competitive intern program with applicants from across the country.
            I led the design and implementation of numerous features among several instruments and projects.
            Both interns as well as other engineers were led in the efficient completion of the goals we set out to achieve.
          </p>

          <h3>Wrote technical documentation for engineers and customers</h3>
          <p>
            For both the Python driver and MeasureReady M81-SSM our documentation was written largely in ReStructured text files and kept in version control.
            Then during the Python Driver release process the class and method level comments are inlined before being uploaded to Read The Docs.
            For the M81 the documentation inlined the XML comments and uploaded it to different locations depending on the build type.
            By automating the process of building our manuals, we were able to vary which information was distributed to customers and testers based on the preparedness of the release.
          </p>
        </div>
        <div v-if="activeTab === 'deliverables'">
          <h3>Coming soon!</h3>
          <p>For now I would recommend taking a look at the <a href="https://www.lakeshore.com/products/categories/overview/material-characterization-products/measureready-m81-synchronous-source-measure-system/measureready-m81-synchronous-source-measure-system">MeasureReady M81-SSM</a> and the <a href="https://www.lakeshore.com/products/categories/overview/magnetic-products/gaussmeters-teslameters/f71-and-f41-teslameters">F41 and F71 Teslameters</a> as these were the instruments I worked on most heavily.</p>
        </div>
        <div v-if="activeTab === 'company'">
          <p>
            Lake Shore Cryotronics, Inc. builds and supplies measurement and control systems for the discovery and development of new materials for next-level technologies. Since 1968 Lake Shore has been providing products that are used in physics labs and deep space alike.
          </p>
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
