<template>
  <div class="container">
    <div class="card mt-5">
      <h2 class="card-header">Skills</h2>
      <label>Toggle Dark Mode</label>
      <b-checkbox v-model="darkMode"></b-checkbox>
      <table class="table table-striped" :class="[{'table-dark': darkMode}, 'table-bordered']">
        <thead class="thead-light">
          <th>#</th>
          <th>Name</th>
          <th>Description</th>
          <th>Level Descriptions</th>
          <th>Remove</th>
        </thead>
        <tbody>
          <tr
            v-for="(skill, index) in skills"
            :key="skill.skillId"
            :class="{highlight: getSqlStyle(skill)}"
          >
            <td>{{index + 1}}</td>
            <td>{{skill.name}}</td>
            <td>{{skill.description}}</td>
            <td>
              <ul>
                <li v-for="(skillLevel,index) in skill.skillLevel" :key="skillLevel.skillLevelId" class="alignLeft">Level {{index + 1}}: {{skillLevel.description}}</li>
              </ul>
            </td>
            <td>
              <button @click="removeSkill(skill.skillId)" class="btn btn-warning">Remove Skill</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Skills",
  data() {
    return {
      skills: [],
      darkMode: true
    };
  },
  methods: {
    removeSkill: function(skillId) {
      axios
        .delete("https://localhost:44304/api/Skill/" + skillId)
        .then(res => console.log(res))
        .catch(err => console.log(err));
    },
    getSqlStyle: function(skill) {
      if (skill.name === "SQL") {
        return true;
      } else {
        return false;
      }
    }
  },
  updated() {
    axios
      .get("https://localhost:44304/api/Skill")
      .then(res => (this.skills = res.data.slice(0, 10)))
      .catch(err => console.log(err));
  },
  mounted() {
    axios
      .get("https://localhost:44304/api/Skill")
      .then(res => (this.skills = res.data.slice(0, 10)))
      .catch(err => console.log(err));
  }
};
</script>

<style lang="postcss" scoped>
.highlight {
  border: solid 3px red;
}
.alignLeft {
  text-align: left;
}
</style>
