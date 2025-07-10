<script setup>

</script>


<template>
  <div class="modal" tabindex="-1" id="CreateModal">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Create a Burger or Side</h5>
        </div>
        <div class="modal-body">
          <form action="">
            <div>
              <div class="form-check">
                <input class="form-check-input" type="radio" name="burger" id="radioDefault1">
                <label class="form-check-label" for="radioDefault1">
                  Burger
                </label>
              </div>
              <div class="form-check mb-3">
                <input class="form-check-input" type="radio" name="side" id="radioDefault2">
                <label class="form-check-label" for="radioDefault2">
                  Side
                </label>
              </div>
              <label for="text" class="form-label">Name</label>
              <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon1">@</span>
                <input type="text" class="form-control" placeholder="Name" aria-label="Name"
                  aria-describedby="basic-addon1">
              </div>
              <div class="mb-3">
                <label for="basic-url" class="form-label">Picture</label>
                <div class="input-group">
                  <span class="input-group-text" id="basic-addon3">URL here</span>
                  <input type="text" class="form-control" id="basic-url" aria-describedby="basic-addon3 basic-addon4">
                </div>
              </div>
              <label for="text" class="form-label">Price</label>
              <div class="input-group mb-3">
                <span class="input-group-text">$</span>
                <input type="text" class="form-control" aria-label="Amount (to the nearest dollar)">
                <span class="input-group-text">.00</span>
              </div>
            </div>
          </form>
        </div>
        <div class="modal-footer">
          <button type="submit" class="btn btn-bs-orange">Submit</button>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>

</style>