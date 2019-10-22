<template>
  <div class="home container-fluid">
    <div class="row">
      <h1>Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
    </div>
    <hr />
    <div class="row">
      <keep v-for="keep in keeps" :keepProp="keep" :key="keep._id" />
      <div class="col-12 pt-5">
        <button class="btn btn-primary" data-toggle="modal" data-target>Add</button>
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/Keep";
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  mounted() {
    this.$store.dispatch("getAllKeeps");
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: { keep }
};
</script>