<script setup>
import { AppState } from '@/AppState.js';
import BurgerCard from '@/components/BurgerCard.vue';
import HeaderSection from '@/components/HeaderSection.vue';
import { burgerService } from '@/services/BurgerService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const burgers = computed(() => AppState.burgers)

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
    <div class="row d-flex g-0">
      <div class="col-md-4" v-for="burger in burgers" :key="burger.id">
        <BurgerCard :burger="burger" />
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
.col-md-4 {
  padding-left: 0;
  padding-right: 0;
  margin-top: 1rem;
  margin-bottom: 1rem;
  display: flex;
  justify-content: center;
}
</style>

<!-- #f0833b -->
