<template>
  <div class="home container-fluid">
    <div class="row justify-content-center">
      <h1 class="pr-2">Welcome Home {{user.username}}</h1>
      <button type="button" class="btn btn-secondary p-1 m-2" v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
    </div>
    <hr />
    <div class="row pb-1 justify-content-center">
      <button
        class="btn btn-primary m-1"
        data-toggle="modal"
        data-target="#AddKeepModal"
      >Add a Keepr</button>
      <button
        class="btn btn-primary m-1"
        data-toggle="modal"
        data-target="#AddVaultModal"
      >Add a Vault</button>
      <AddKeepModal />
      <AddVaultModal />
    </div>
    <hr />
    <h2>Your Vaults</h2>
    <div class="row justify-content-center">
      <vault v-for="vault in vaults" :vaultProp="vault" :key="vault._id" class="m-1" />
    </div>
    <hr />
    <h2>Your Creations</h2>
    <div class="row justify-content-center">
      <keep v-for="keep in keeps" :keepProp="keep" :key="keep._id" class="m-1" />
    </div>
  </div>
</template>

<script>
import keep from "../components/Keep";
import vault from "../components/Vault";
import AddKeepModal from "../components/AddKeepModal";
import AddVaultModal from "../components/AddVaultModal";
export default {
  name: "home",
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
    },
    vaultKeeps() {
      return this.$store.state.vaultkeeps;
    }
  },
  mounted() {
    this.$store.dispatch("getAllKeeps");
    this.$store.dispatch("getAllVaults");
    this.$store.dispatch("getVaultKeeps");
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: { keep, vault, AddKeepModal, AddVaultModal }
};
</script>