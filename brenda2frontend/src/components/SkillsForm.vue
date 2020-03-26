<template>
  <div class="container">
    <form class="mt-5" @submit="addSkill">
      <h1>Add Skill</h1>
      <label>Name</label>
      <input type="text" v-model="serviceSkill.name" class="form-control" />
      <br />

      <label>Description</label>
      <input type="text" v-model="serviceSkill.description" class="form-control" />
      <br />

      <label>Level 1 Description</label>
      <input type="text" v-model="serviceSkill.level1Description" class="form-control" />
      <br />

      <label>Level 2 Description</label>
      <input type="text" v-model="serviceSkill.level2Description" class="form-control" />
      <br />

      <label>Level 3 Description</label>
      <input type="text" v-model="serviceSkill.level3Description" class="form-control" />
      <br />

      <label>Level 4 Description</label>
      <input type="text" v-model="serviceSkill.level4Description" class="form-control" />
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
        name: "",
        nescription: "",
        level1Description: "",
        level2Description: "",
        level3Description: "",
        level4Description: ""
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