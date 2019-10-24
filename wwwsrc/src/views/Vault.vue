<template>
  <div class="vault">
    <h1>Vault name: {{this.activeVaults.name}}</h1>
    <h3>{{this.activeVaults.description}}</h3>
    <button type="button" class="btn btn-primary" @click="Back()">Back</button>
    <hr />
    <div class="row justify-content-center">
      <keep v-for="keep in vaultkeeps" :keepProp="keep" :key="keep._id" class="m-1" />
    </div>
  </div>
</template>


<script>
import keep from "../components/Keep";
import router from "../router";
export default {
  name: "vault",
  data() {
    return {};
  },
  computed: {
    activeVaults() {
      return this.$store.state.activevault;
    },
    vaultkeeps() {
      return this.$store.state.keepsinvault;
    }
  },
  mounted() {
    let payload = {
      id: this.$route.params.vaultId
    };
    this.$store.dispatch("getVaultById", payload);
    this.$store.dispatch("getKeepsByVaultId", payload);
  },
  methods: {
    Back() {
      router.push({ name: "home" });
    }
  },
  components: { keep }
};
</script>


<style scoped>
</style>