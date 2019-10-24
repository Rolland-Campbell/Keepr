<template>
  <div class="viewKeep">
    <button type="button" class="btn btn-primary" @click="Back()">Back</button>
    <h1>{{this.activeKeep.name}}</h1>
    <img :src="this.activeKeep.img" alt=".." />
  </div>
</template>


<script>
import router from "../router";
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
  methods: {
    Back() {
      router.push({ name: "home" });
    }
  },
  components: {}
};
</script>


<style scoped>
img {
  height: auto;
  width: auto;
}
</style>