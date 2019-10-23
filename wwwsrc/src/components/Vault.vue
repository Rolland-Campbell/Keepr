<template>
  <div class="Vault d-flex m-3">
    <h5>{{vaultProp.name}} : {{vaultProp.description}}</h5>
    <button type="button" class="btn btn-success ml-3 p-1" @click="viewVault()">Go</button>
    <button type="button" class="btn btn-danger ml-3 p-1" @click="deleteVault()">Delete</button>
  </div>
</template>


<script>
export default {
  name: "Vault",
  props: ["vaultProp"],
  data() {
    return {};
  },
  computed: {
    keep() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    viewVault() {
      this.$router.push({
        name: "vault",
        params: { vaultId: this.vaultProp.id }
      });
    },
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vaultProp.id);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>