<template>
  <div class="AddVaultModal">
    <div
      class="modal fade"
      id="AddVaultModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Add a Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form>
              <div class="form-group">
                <label for="exampleInputName">Name it</label>
                <input
                  type="text"
                  class="form-control"
                  id="name"
                  placeholder="Name your Keepr"
                  v-model="newVault.name"
                />
              </div>
              <div class="form-group">
                <label for="exampleInputDescription">Describe it</label>
                <input
                  type="text"
                  class="form-control"
                  id="description"
                  placeholder="Description"
                  v-model="newVault.description"
                />
              </div>
              <button type="submit" class="btn btn-primary" @click="addVault()">Submit</button>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "AddVaultModal",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {},
  methods: {
    addVault() {
      this.$store.dispatch("addVault", this.newVault);
      this.newVault = {};
    }
  },
  components: {}
};
</script>


<style scoped>
</style>