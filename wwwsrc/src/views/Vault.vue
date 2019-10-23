<template>
  <div class="vault">
    <h1>Vault name: {{this.activeVaults.name}}</h1>
    <h3>{{this.activeVaults.description}}</h3>
    <hr />
    <div class="row justify-content-center">
      <vaultkeep v-for="keep in vaultkeeps" :keepProp="keep" :key="keep._id" class="m-1" />
    </div>
  </div>
</template>


<script>
import keep from "../components/Keep";
export default {
  name: "vault",
  data() {
    return {};
  },
  computed: {
    vaultkeeps() {
      return this.$store.state.vaultkeeps;
    },
    activeVaults() {
      return this.$store.state.activevault;
    }
  },
  mounted() {
    let payload = {
      id: this.$route.params.vaultId
    };
    this.$store.dispatch("getVaultById", payload);
  },
  methods: {},
  components: { keep }
};
</script>


<style scoped>
</style>