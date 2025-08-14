<script setup>
import { AppState } from '@/AppState.js';
import BurgerCard from '@/components/BurgerCard.vue';
import CreateModal from '@/components/CreateModal.vue';
import HeaderSection from '@/components/HeaderSection.vue';
import SideCard from '@/components/SideCard.vue';
import UpdateModal from '@/components/UpdateModal.vue';
import { burgerService } from '@/services/BurgerService.js';
import { sideService } from '@/services/SideService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted, ref } from 'vue';

const burgers = computed(() => AppState.burgers)

const sides = computed(() => AppState.sides)

const selectedItemId = ref(null)

const selectedItemType = ref('')

onMounted(() => {
  getBurgers()
  getSides()
})
// TODO make an update button and create an edit form for burgers and sides. 

async function getBurgers() {
  try {
    await burgerService.getBurgers()
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET BURGERS!');
    logger.log('Could not get Burgers!', error)
  }
}

async function getSides() {
  try {
    await sideService.getSides()
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET SIDES!');
    logger.error('Could not get Sides!', error)
  }
}

function updateItem(id, type) {
  selectedItemId.value = id
  selectedItemType.value = type
  logger.log(`Updating ${type} with id ${id}`)
}

</script>

<template>
  <section class="container-fluid">
    <div class="row d-flex justify-content-center">
      <div class="col p-0">
        <HeaderSection />
      </div>
    </div>
    <div class="row d-flex g-0">
      <div class="d-flex justify-content-between mt-2">
        <span>
          <h1 class="ms-4">Burgers</h1>
        </span>
        <span class="mt-2">
          <button class="btn btn-outline-bs-orange rounded-pill me-2" type="button" data-bs-toggle="modal"
            data-bs-target="#CreateModal">Create Burger</button>
          <!-- <button class="btn btn-outline-bs-orange rounded-pill me-5" type="button" data-bs-toggle="modal"
            data-bs-target="#UpdateModal">Update Burger</button> -->
        </span>
      </div>
      <div class="col-md-4" v-for="burger in burgers" :key="burger.id" @click="updateItem(burger.id, 'burger')"
        data-bs-toggle="modal" data-bs-target="#UpdateModal" type="button">
        <BurgerCard :burger="burger" />
      </div>
    </div>
    <div class="row d-flex g-0">
      <span class="d-inline-flex justify-content-between mt-2">
        <h1 class="ms-4">Sides</h1>
        <button class="btn btn-outline-bs-orange rounded-pill me-5" type="button" data-bs-toggle="modal"
          data-bs-target="#CreateModal">Create Side</button>
      </span>
      <div class="col-md-4" v-for="side in sides" :key="side.id">
        <SideCard :side="side" />
      </div>
    </div>
  </section>
  <CreateModal />
  <UpdateModal :itemId="selectedItemId" />
</template>

<style scoped lang="scss">
.col-md-4 {
  padding-left: 0;
  padding-right: 0;
  margin-top: 1rem;
  margin-bottom: 1rem;
  display: flex;
  justify-content: center;
}

h1 {
  color: #ed9153;
}
</style>

