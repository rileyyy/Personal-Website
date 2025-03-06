<template>
  <div class="education-container">
    <!-- Main Content -->
    <div>
      <header class="details-header">
        <img src="https://cdn.brandfetch.io/idw0gJQjK5/w/400/h/400/theme/dark/icon.jpeg?c=1dxbfHSJFAPEGdCLU4o5B" class="university-logo" alt="University Logo" />
        <div id="d0">
          <h1 class="name">Taurus TeleSys, Inc</h1>
          <div class="detail-info">
            <Frown class="icon icon-accent" />
            <a class="school-url">no website</a>
            <p>|</p>
            <User class="icon" />
            <p>9</p>
            <p>|</p>
            <Star class="icon icon-yellow" />
            <Star class="icon icon-yellow" />
            <Star class="icon icon-yellow" />
            <Star class="icon icon-yellow" />
            <p>(1)</p>
          </div>
          <div class="motto">Real-Time Simulation and Global Telecommunication Systems</div>
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
          <h3>Improved simulator software</h3>
          <p>
            Adding features such as multi-threading, database management, and configurable user interface. Originally the control application was written entirely on the UI thread which led to poor performance.
            After numerous improvements the control application was split across many threads, which reduced command execution time to near instant and no longer froze the application while commands and queries were being executed.
          </p>
          <br>

          <h3>Reverse engineered hardware communications protocols</h3>
          <p>
            A major portion of simulation is to understand how the thing that is being simulated works.
            In this case there were over 100 unique devices to be replicated.
            Through various means, we were able to connect to the devices and analyze their inputs and outputs in order to build an accurate replica entirely in software.
          </p>
          <br>

          <h3>Designed and built network layouts</h3>
          <p>
            When I first started, there was exactly one fully configured simulator that needed to be shared with the Navy for actual training on certain days.
            As the team grew and started to include more testing and documentation I designed and built 5 more simulators utilizing different combinations of virtual machines and real hardware.
            This meant that there were systems for testing, development, documentation, training, and network experiments simultaniously.
          </p>

          <p>
            Included in the work of designing and building these systems was reconfiguration of network layouts.
            This allowed me to compress many streams of network traffic on multiple endpoints into single physical connections while maintaining network security.
          </p>
          <br>

          <h3>Applied modern coding standards</h3>
          <p>
            In a solution of over 80 projects, half a dozen databases, and racks of hardware things can get a bit sloppy.
            When that is compounded by a team of under ten, its easy to understand exactly how far coding standards can fall. We worked to apply modern coding standards such as reduced nesting, appropriate formatting, and better naming conventions.
          </p>
          <br>

          <h3>Designed and modified database configuration</h3>
          <p>
            Simulators, especially ones of this size and complexity, are comprised hundres of thousands of unique data elements.
            Each of these elements live on multiple hosts which need to be coordinated and allocated.
            Given the quantity of configuration to control, databases were redesigned with regularity.
          </p>
          <br>

          <h3>Implemented unit, integration, and end-to-end testing</h3>
          <p>
            When I started at Taurus there were exactly zero automated tests.
            In fact, all validation was done by examining certain known data points in a "plug it in, and hope it works" mindset.
            While there was room for tens of thousands of tests, we were able to get a few hundred of both unit and integration tests created within my time.
          </p>
          <br>

          <h3>Updated version control systems and created CI/CD pipelines</h3>
          <p>
            At this point, if you aren't using git you're probably doing something wrong; and well, we were doing something very wrong.
            Our version control was a rusty host sitting in the corner under a stack of random papers, boxes, and computers.
            It would only stay powered on for about 8 hours at a time, and was BIOS locked with only one person knowing the password for years.
            So instead when I started the other developer and I would keep a "deliverable" folder on our computer and work in a "working" folder.
            Then when the changes were finished, we were each responsible to diff those changes into the "deliverable" folder, and them sync that to the other person's "deliverable" folder.
            Then once a month or so when the SVN server was working someone would sync all of those changes into it.
          </p>
          <p>
            This was clearly wrought with issues.
            So I took on the hefty task of converting our SVN repositories into git repositories while preserving the history.
            That was over a decade of commit history and some of the commands took over an hour to run.
          </p>
          <p>
            Along with that upgrade and the implementation of testing layers, we started to add official CI/CD pipelines.
            Initially our delivery process was to run a series of batch files and burn a single read-only disc to hand deliver.
            Every time there was a change to be made, it was another disc to be burned; which means that we could be burning up to 20 discs each day.
          </p>

          <h3>Interfaced simulator with models and hardware</h3>
          <p>
            Similar to API integrations, a simulator needs to communicate to several other systems.
            Hardware interfaces are important for giving end-users the same physical controls the will use in the real system.
            Interfacing with models is even more important as the model is what drives the real world data such as storage levels, temperatures, or pressures.
          </p>
          <br>

        </div>
        <div v-if="activeTab === 'deliverables'">
          <h3>
            Unfortunately this work was classified and heavily secure so I cannot provide examples at this time.
          </h3>
        </div>
        <div v-if="activeTab === 'company'">
          <p>
            Taurus teleSYS Inc (Taurus) has 40 years’ experience in the real-time simulation industry and in project engineering and management of real-time computer and communications projects for the energy and telecommunications industry.
            Taurus has successfully executed multi-million-dollar projects and marketed its products in the national and international marketplaces.
          </p>
          <p>
            Since 1980, Taurus is an Original Equipment Manufacturer (OEM) and US government subcontractor that designs, builds and installs thermal and nuclear power plant training simulators.
            The US Department of Energy contracted Taurus to implement a digital computer-based system to test—using a closed-loop, deterministic and real-time method—Instrumentation and Control (I&C) equipment for Pressurized Water Reactors (PWRs).
            The hardware devices (detector emulators) convert the computer output signals into actual plant detector signals, which drive the seamlessly redundant Ethernet network that connects I&C equipment under test.
            The scope of work involves dynamic modeling of actual plant systems and physical phenomena (such as two-phase flow and reactor kinetics) which must be calculated explicitly in real-time at 100 Hz.
            The scope of effort consists of development, assembly and acceptance testing of all hardware and software, including training of customer engineers within 24 to 36 months, using the digital twin technology for I&C implementation.
          </p>
          <br>
          <p>
            <i>* Exert taken from <a
                 href="https://www.microchip.com/en-us/products/high-speed-networking-and-video/network-processors/ecosystem">microchip.com</a></i>
          </p>
          <p>
            <i>* Logo property of <a
                 href="https://hii.com/">Huntington Ingalls Industries</a>
              and used as tangentially relevant</i>
          </p>
        </div>
      </section>

      <!-- Meta-Data Sidebar -->
      <aside class="meta-sidebar">
        <table class="meta-item">
          <th>Roles</th>
          <tr>
            <td>Applications Engineer</td>
          </tr>
          <tr>
            <td>System Software Engineer</td>
          </tr>
        </table>
        <table class="meta-item">
          <th>Dates</th>
          <tr>
            <td>April 2019 to May 2024</td>
          </tr>
        </table>
        <table class="meta-item">
          <th>Tech Stack</th>
          <tr>
            <td>C#/.NET</td>
          </tr>
          <tr>
            <td>C++</td>
          </tr>
          <tr>
            <td>Bash</td>
          </tr>
          <tr>
            <td>Java SE</td>
          </tr>
          <tr>
            <td>MySql</td>
          </tr>
          <tr>
            <td>Microsoft Access</td>
          </tr>
          <tr>
            <td>MongoDB</td>
          </tr>
          <tr>
            <td>Jenkins</td>
          </tr>
          <tr>
            <td>Git</td>
          </tr>
          <tr>
            <td>Microservices</td>
          </tr>
        </table>
        <table class="meta-item">
          <th>Resources</th>
          <tr>
            <td>
              <a class="reference-link" href="mailto:apatel@tgate.com">Email</a>
            </td>
          </tr>
          <tr>
            <td>
              <a class="reference-link" href="https://www.linkedin.com/in/arvind-patel-2167436">LinkedIn</a>
            </td>
          </tr>
        </table>
      </aside>
    </div>
  </div>
</template>

<script setup lang="ts">
import { Frown, User, Star } from "lucide-vue-next";
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
  border-radius: 20px;
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
  padding-top: 8px;
}

.tab-content p {
  margin: 4px 0 0 16px;
}

.tab-content a {
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
