<template>
  <div class="card" style="width: 18rem;">
    <img :src="keepProp.img" class="card-img-top" alt="..." @click="viewKeep()" />
    <div class="card-body">
      <h5 class="card-title">{{keepProp.name}}</h5>
      <p class="card-text">{{keepProp.description}}</p>
      <p>Views : {{keepProp.views}}</p>
      <p>Keeps : {{keepProp.keeps}}</p>
      <p>Private : {{keepProp.isPrivate}}</p>
      <button type="button" class="btn btn-danger" @click="deleteKeep()">Delete</button>
      <div>
        <select
          class="custom-select col-sm-12 col-md-6 mt-2"
          id="inlineFormCustomSelect"
          @change="addToVault($event)"
          v-model="vaultId"
        >
          <option selected>Vault</option>
          <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
        </select>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "Keep",
  props: ["keepProp"],
  data() {
    return {
      vaultId: ""
      //keepToVault: { vaultId: this.vaultId, keepId: this.keepProp.id }
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
    },
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepProp.id);
    },
    addToVault() {
      let keepToVault = { vaultId: this.vaultId, keepId: this.keepProp.id };
      this.$store.dispatch("addToVault", keepToVault);
      this.$store.dispatch("getAllKeeps");
    },
    viewKeep() {
      this.$store.dispatch("getKeepById", this.keepProp.id);
      this.$router.push({
        name: "viewKeep",
        params: {
          id: this.keepProp.id,
          img: this.keepProp.img,
          name: this.keepProp.name,
          views: this.keepProp.views
        }
      });
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