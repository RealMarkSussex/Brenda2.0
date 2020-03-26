<template>
  <div class="container">
    <form class="mt-5" @submit="addSkill">
      <h1>Add Skill</h1>
      <label>Name</label>
      <input type="text" v-model="serviceSkill.Name" class="form-control" />
      <br />

      <label>Description</label>
      <input type="text" v-model="serviceSkill.Description" class="form-control" />
      <br />

      <button type="submit" value="Add Skill" class="btn btn-primary">Add Skill</button>
    </form>
    <label>{{serviceSkill}}</label>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      serviceSkill: {
        Name: "",
        Description: ""
      }
    };
  },
  methods: {
    addSkill: function() {
      axios
        .post("https://localhost:44304/api/Skill", this.serviceSkill)
        .then(response => {
            console.log(response)
        })
        .catch(err => {
          console.log(err);
        });
    }
  }
};
</script>

<style>
</style>