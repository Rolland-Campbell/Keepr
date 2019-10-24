<template>
  <div class="card" style="width: 18rem;">
    <img :src="keepProp.img" class="card-img-top" alt="..." />
    <p>Views : {{keepProp.views}}</p>
    <p>Keeps : {{keepProp.keeps}}</p>
  </div>
</template>


<script>
export default {
  name: "PreViewKeep",
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
    viewKeep() {}
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