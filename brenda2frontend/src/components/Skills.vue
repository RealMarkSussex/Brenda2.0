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
        <th>Remove</th>
      </thead>
      <tbody>
        <tr v-for="(skill, index) in skills" :key="skill.skillId" :class="{highlight: getSqlStyle(skill)}">
          <td>{{index + 1}}</td>
          <td>{{skill.name}}</td>
          <td>{{skill.description}}</td>
          <td>
            <button @click="removeSkill(index)" class="btn btn-warning">Remove Skill</button>
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
      darkMode: false
    };
  },
  methods: {
    removeSkill: function(index) {
      this.skills.splice(index, 1)
    },
    getSqlStyle: function(skill) {
      if(skill.name === 'C#') {
        return true;
      } else {
        return false;
      }
    },
  },
  created() {
    axios
      .get("https://localhost:44304/api/Skill")
      .then(res => (this.skills = res.data.slice(0, 10)))
      .catch(err => console.log(err));
  }
};
</script>

<style lang="postcss" scoped>
  .highlight {
    border: solid 3px red
  }
</style>
