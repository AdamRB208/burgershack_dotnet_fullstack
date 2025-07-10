<script setup>
import { burgerService } from '@/services/BurgerService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { ref } from 'vue';


const selectedType = ref('')

const editableFormData = ref({
  name: '',
  price: '',
  imgUrl: '',
})


async function createBurger() {
  try {
    const burgerData = editableFormData.value
    await burgerService.createBurger(burgerData)
    editableFormData.value = {
      name: '',
      price: '',
      imgUrl: ''
    }
  }
  catch (error) {
    Pop.error(error, 'COULD NOT CREATE BURGER!!!');
    logger.error('Could not create Burger!!', error)
  }
}

function submitForm() {
  if (selectedType.value === 'burger') {
    createBurger();
    logger.log('Creating a burger!')
  } else if (selectedType.value === 'side') {
    return
  }
}
</script>


<template>
  <div class="modal" tabindex="-1" id="CreateModal">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Create a Burger or Side</h5>
        </div>
        <div class="modal-body">
          <form @submit.prevent="submitForm()">
            <div>
              <div class="radio-section">
                <div class="form-check">
                  <input class="form-check-input" type="radio" v-model="selectedType" value="burger" id="radioBurger">
                  <label class="form-check-label" for="radioBurger">Burger</label>
                </div>
                <div class="form-check mb-3">
                  <input class="form-check-input" type="radio" v-model="selectedType" value="side" id="radioSide">
                  <label class="form-check-label" for="radioSide">Side</label>
                </div>
              </div>
              <label for="text" class="form-label">Name</label>
              <div class="input-group mb-3">
                <span class="input-group-text" id="Name">Name</span>
                <input v-model="editableFormData.name" type="text" class="form-control" placeholder="..."
                  aria-label="Name" id="Name" maxlength="255" required>
              </div>
              <div class="mb-3">
                <label for="basic-url" class="form-label">Picture</label>
                <div class="input-group">
                  <span class="input-group-text" id="basic-addon3">URL</span>
                  <input v-model="editableFormData.imgUrl" type="text" class="form-control" id="ImgUrl"
                    placeholder="..." maxlength="255" required>
                </div>
              </div>
              <label for="text" class="form-label">Price</label>
              <div class="input-group mb-3">
                <span class="input-group-text">$</span>
                <input v-model="editableFormData.price" type="text" class="form-control" id="Price" placeholder="..."
                  maxlength="255" required>
              </div>
            </div>
            <div class="modal-footer">
              <button type="submit" class="btn btn-bs-orange">Submit</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>

</style>