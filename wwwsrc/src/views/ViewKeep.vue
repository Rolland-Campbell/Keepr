<template>
  <div class="viewKeep">
    <button type="button" class="btn btn-primary" @click="Back()">Back</button>
    <h1>{{this.activeKeep.name}}</h1>
    <img :src="this.activeKeep.img" alt=".." />
    <h5>Views : {{this.activeKeep.views}}</h5>
    <h5>Keeps : {{this.activeKeep.keeps}}</h5>
    <br />
  </div>
</template>


<script>
import router from "../router";
export default {
  name: "viewKeep",
  data() {
    return {};
  },
  mounted() {},
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