<script setup>
import { burgerService } from '@/services/BurgerService.js';
import { sideService } from '@/services/SideService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted, ref, watch } from 'vue';


const selectedType = ref('')

const editableFormData = ref({
  name: '',
  price: '',
  imgUrl: ''
})

const props = defineProps({
  itemId: {
    type: Number,
    default: null
  }
})

const itemType = ref('')

watch(() => props.itemId, async (newId) => {
  if (newId) {
    await loadItemData()
  }
})

onMounted(async () => {
  if (props.itemId) {
    await loadItemData()
  }
})

async function loadItemData() {
  try {
    if (itemType.value === 'burger') {
      const burger = await burgerService.getBurgersById(props.itemId)
      editableFormData.value = {
        name: burger.name,
        price: burger.price,
        imgUrl: burger.imgUrl
      }
    } else if (itemType.value === 'side') {
      const side = await sideService.getSideById(props.itemId)
      editableFormData.value = {
        name: side.name,
        price: side.price,
        imgUrl: side.imgUrl
      }
    }
  }
  catch (error) {
    Pop.error(error, 'COULD NOT LOAD ITEM DATA!');
    logger.error('Could not Load Item Data!', error)
  }
}

async function updateItem() {
  logger.log('Submitting form')
  try {
    if (itemType.value === 'burger') {
      await burgerService.updateBurger(props.itemId, editableFormData.value)
    } else if (itemType.value === 'side') {
      await sideService.updateSide(props.itemId, editableFormData.value)
    }
  }
  catch (error){
    Pop.error(error, 'COULD NOT UPDATE ITEM!');
    logger.log('Could not Update Item!', error)
  }
}
</script>


<template>
  <div class="modal" tabindex="-1" id="UpdateModal">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Update a Burger or Side</h5>
        </div>
        <div class="modal-body">
          <form @submit.prevent="updateItem()">
            <div>
              <div class="radio-section">
                <div class="form-check">
                  <input class="form-check-input" type="radio" v-model="itemType" value="burger" id="radioBurger">
                  <label class="form-check-label" for="radioBurger">Burger</label>
                </div>
                <div class="form-check mb-3">
                  <input class="form-check-input" type="radio" v-model="itemType" value="side" id="radioSide">
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
                  <span class="input-group-text">URL</span>
                  <input v-model="editableFormData.imgUrl" type="text" class="form-control" id="ImgUrl"
                    placeholder="..." maxlength="255">
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
              <button type="submit" class="btn btn-bs-orange" @click="logger.log('button clicked!')">Submit</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped></style>