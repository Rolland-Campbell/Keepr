<template>
  <div class="card" style="width: 18rem;">
    <img :src="keepProp.img" class="card-img-top" alt="..." @click="viewKeep()" />
    <div class="card-body">
      <h5 class="card-title">{{keepProp.name}}</h5>
      <p class="card-text">{{keepProp.description}}</p>
      <button type="button" class="btn btn-danger" @click="deleteKeep()">Delete</button>
      <div>
        <select
          class="custom-select col-sm-12 col-md-6 mt-2"
          id="inlineFormCustomSelect"
          @change="addToVault($event)"
        >
          <option selected>Vault</option>
          <option v-for="vault in vaults" :key="vault.id">{{vault.name}}</option>
        </select>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "Keep",
  props: ["keepProp", "vaultProp"],
  data() {
    return {
      keepsToVault: {}
    };
  },
  computed: {
    keep() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
    },
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepProp.id);
    },
    addToVault() {
      this.$store.dispatch("addToVault", this.keepsToVault);
      this.keepsToVault = {
        keepId: this.keepProp.id,
        vaultId: this.vaults.id,
        userId: this.keepProp.userId
      };
    },
    viewKeep() {
      this.$router.push({
        name: "viewKeep",
        params: {
          id: this.keepProp.id,
          img: this.keepProp.img,
          name: this.keepProp.name,
          views: this.keepProp.views
        }
      });
      //this.$store.dispatch("editKeep");
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