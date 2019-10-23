<template>
  <div class="card" style="width: 18rem;">
    <img :src="keepProp.img" class="card-img-top" alt="..." />
    <div class="card-body">
      <h5 class="card-title">{{keepProp.name}}</h5>
      <p class="card-text">{{keepProp.description}}</p>
      <a href="#" class="btn btn-primary">Go somewhere</a>
    </div>
    <button type="button" class="btn btn-danger" @click="deleteKeep()">Delete</button>
  </div>
</template>


<script>
export default {
  name: "Keep",
  props: ["keepProp"],
  data() {
    return {};
  },
  computed: {
    keep() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    viewKeep() {},
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepProp.id);
    }
  },
  components: {}
};
</script>


<style scoped>
img {
  height: 200px;
  width: auto;
}
</style>