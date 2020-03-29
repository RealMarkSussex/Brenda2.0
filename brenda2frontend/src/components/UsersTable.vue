<template>
  <div class="container">
    <div class="card mt-5">
      <h2 class="card-header">Users</h2>
      <label>Toggle Dark Mode</label>
      <b-checkbox v-model="darkMode"></b-checkbox>
      <table class="table table-striped" :class="[{'table-dark': darkMode}, 'table-bordered']">
        <thead class="thead-light">
          <th>#</th>
          <th>Name</th>
          <th>Email</th>
          <th>Role</th>
          <th>Desired Role</th>
          <th>User Skills</th>
          <th>Remove</th>
        </thead>
        <tbody>
          <tr v-for="(user, index) in users" :key="user.userId">
            <td>{{index + 1}}</td>
            <td>{{user.firstName}} {{user.lastName}}</td>
            <td>{{user.email}}</td>
            <td>
              <Role :roleId="user.roleId"></Role>
            </td>
            <td>
              <Role :roleId="user.desiredRoleId"></Role>
            </td>
            <td>
                <li v-for="userSkill in user.userSkills" :key="userSkill.userSkillId"></li> //rather than a list use the user skill component
            </td>
            <td>
              <button @click="removeUser(user.userId)" class="btn btn-warning">Remove User</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import Role from "./Role";
import axios from "axios";

export default {
  components: {
    Role
  },
  data() {
    return {
      users: [],
      darkMode: true
    };
  },
  methods: {
    removeUser: function(userId) {
      axios
        .delete("https://localhost:44304/api/User/" + userId)
        .then(res => console.log(res))
        .catch(err => console.log(err));
    }
  },
  updated() {
    axios
      .get("https://localhost:44304/api/User")
      .then(res => (this.users = res.data.slice(0, 10)))
      .catch(err => console.log(err));
  },
  mounted() {
    axios
      .get("https://localhost:44304/api/User")
      .then(res => (this.users = res.data.slice(0, 10)))
      .catch(err => console.log(err));
  }
};
</script>

<style>
</style>