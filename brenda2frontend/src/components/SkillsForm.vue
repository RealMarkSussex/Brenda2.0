<template>
  <div class="card mt-5">
    <div class="container">
      <h2 class="card-header">Add Skill</h2>
      <form class="mt-5" @submit="addSkill">
        <label>Name</label>
        <input type="text" v-model="serviceSkill.name" class="form-control" />
        <br />

        <label>Description</label>
        <input type="text" v-model="serviceSkill.description" class="form-control" />
        <br />

        <button type="submit" value="Add Skill" class="btn btn-primary">Add Skill</button>
      </form>
    </div>
    <label>{{serviceSkill}}</label>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      serviceSkill: {
        name: "",
        description: ""
      }
    };
  },
  methods: {
    addSkill: function() {
      axios
        .post("https://localhost:44304/api/Skill", {
          body: JSON.stringify(this.serviceSkill)
        })
        .then(response => {
          console.clear();
          console.log(response.data);
        })
        .catch(err => {
          console.clear();
          console.log(err);
        });
    }
  }
};
</script>

<style>
</style>