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

      <label>Level 1 Description</label>
      <input type="text" v-model="serviceSkill.Level1Description" class="form-control" />
      <br />

      <label>Level 2 Description</label>
      <input type="text" v-model="serviceSkill.Level2Description" class="form-control" />
      <br />

      <label>Level 3 Description</label>
      <input type="text" v-model="serviceSkill.Level3Description" class="form-control" />
      <br />

      <label>Level 4 Description</label>
      <input type="text" v-model="serviceSkill.Level4Description" class="form-control" />
      <br />

      <button type="submit" value="Add Skill" class="btn btn-primary">Add Skill</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      serviceSkill: {
        Name: "",
        Description: "",
        Level1Description: "",
        Level2Description: "",
        Level3Description: "",
        Level4Description: ""
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
        this.text = "";
    }
  }
};
</script>

<style>
</style>