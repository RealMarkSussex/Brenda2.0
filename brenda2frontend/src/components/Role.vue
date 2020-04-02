<template>
  <div class="container">
    <label>{{role.name}}</label>
    <br/>
    <label class="departmentStyle">{{role.department}}</label>
    <br/>
    <img
      v-if="role.department === 'Tech'"
      src="https://static.thenounproject.com/png/530826-200.png"
      class="img-fluid"
      alt="Responsive image"
      height="200px"
      width="200px"
    />
    <img
      v-if="role.department === 'HR'"
      src="https://lh3.googleusercontent.com/proxy/yPD_N62evZSshOrFAPUkugjgYQCONzRtzhGpiilexnd1Jfk9l9Zr-7ZQZJjvlXT2wbj8YJq5X-9buO00Tb2uHM5ilPyKuSQ9wgztXP4"
      class="img-fluid"
      alt="Responsive image"
      height="200px"
      width="200px"
    />
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: {
    roleId: {
      type: Number,
      default: 1
    }
  },
  data() {
    return {
      role: {},
      image: ""
    };
  },
  created() {
    axios
      .get("https://localhost:44304/api/Role/" + this.roleId)
      .then(res => (this.role = res.data))
      .catch(err => console.log(err));
  }
};
</script>

<style>

</style>