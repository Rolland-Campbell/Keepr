<template>
  <div class="vault">
    <h1>{{vault.name}}</h1>
  </div>
</template>


<script>
export default {
  name: "vault",
  data() {
    return {};
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>