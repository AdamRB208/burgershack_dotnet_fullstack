<script setup>
import { AppState } from '@/AppState.js';
import BurgerCard from '@/components/BurgerCard.vue';
import HeaderSection from '@/components/HeaderSection.vue';
import { burgerService } from '@/services/BurgerService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const burger = computed(() => AppState.burgers)

onMounted(() => {
  getBurgers()
})

async function getBurgers() {
  try {
    await burgerService.getBurgers()
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET BURGERS!');
    logger.log('Could not get Burgers!', error)
  }
}

</script>

<template>
  <section class="container-fluid">
    <div class="row d-flex justify-content-center">
      <div class="col p-0">
        <HeaderSection />
      </div>
    </div>
    <div class="row d-flex justify-content-center">
      <div class="col-md-6">
        <div v-for="burgers in burger" :key="burgers.id">
          <BurgerCard :burgers="burger" />
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-6">
        <div>Sides Here</div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">

</style>

<!-- #f0833b -->
