<template>
  <div class="container">
    <h1>Add User</h1>
    <form class="mt-5" @submit="addUser">
      <label for="email">Email Address</label>
      <input type="email" v-model="serviceUser.email" class="form-control" />
      <br />

      <label>First Name</label>
      <input type="text" v-model="serviceUser.firstName" class="form-control" />
      <br />

      <label>Last Name</label>
      <input type="text" v-model="serviceUser.lastName" class="form-control" />
      <br />

      <label>Password</label>
      <input type="password" v-model="serviceUser.password" class="form-control" />
      <br />

      <button type="submit" value="Add User" class="btn btn-primary">Add User</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      serviceUser: {
        email: "",
        firstName: "",
        lastName: "",
        password: "",
        roleId: 1,
        desiredRoleId: 2,
        desiredRole: null,
        role: null,
        userSkills: []
      }
    };
  },
  methods: {
    addUser() {
      axios
        .post("https://localhost:44304/api/User", this.serviceUser)
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