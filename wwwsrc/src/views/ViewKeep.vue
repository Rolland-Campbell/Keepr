<template>
  <div class="viewKeep">
    <h1>{{this.activeKeep.name}}</h1>
    <img :src="this.activeKeep.img" alt=".." />
  </div>
</template>


<script>
export default {
  name: "viewKeep",
  data() {
    return {};
  },
  mounted() {
    let payload = {
      id: this.$route.params.id
    };
    this.$store.dispatch("getKeepById", payload);
  },
  computed: {
    activeKeep() {
      return this.$store.state.activekeep;
    }
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
img {
  height: auto;
  width: auto;
}
</style>