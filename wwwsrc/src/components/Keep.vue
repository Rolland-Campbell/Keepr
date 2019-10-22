<template>
  <div class="Keep">
    <div class="keep col-3 border rounded" @click="viewKeep()">
      <img src="keep.img" />
      <h5>{{keep.name}}</h5>
      <h5>{{keep.description}}</h5>
      <h5>{{keep.isPrivate}}</h5>
    </div>
  </div>
</template>


<script>
export default {
  name: "Keep",
  data() {
    return {};
  },
  computed: {
    keep() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    viewKeep() {}
  },
  components: {}
};
</script>


<style scoped>
</style>