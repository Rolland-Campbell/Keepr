<template>
  <div class="home container-fluid">
    <div class="row justify-content-center">
      <h1 class="pr-2">Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
    </div>
    <hr />
    <div class="row pb-1 justify-content-center">
      <button class="btn btn-primary" data-toggle="modal" data-target>Add a Keepr</button>
    </div>
    <div class="row justify-content-center">
      <keep v-for="keep in keeps" :keepProp="keep" :key="keep._id" class="m-1" />
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