<script setup>
import { AppState } from '@/AppState.js';
import { Burger } from '@/models/Burger.js';
import { burgerService } from '@/services/BurgerService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed } from 'vue';

const account = computed(() => AppState.account)

defineProps({
  burger: { type: Burger, required: true }
})

async function deleteBurger(burgerId) {
  try {
    const confirmed = await Pop.confirm("Are you sure you want to delete this Burger?")
    if (!confirmed) {
      return
    }
    await burgerService.deleteBurger(burgerId)
  }
  catch (error) {
    Pop.error(error, 'COULD NOT DELETE BURGER!');
    logger.error('Could not delete burger!', error)
  }
}

</script>


<template>
  <div v-if="burger" class="card-container">
    <div class="burger-card">
      <i v-if="account" @click="deleteBurger(burger.id)" class="mdi mdi-alpha-x-circle text-danger text-end ms-2"
        role="button"></i>
      <img :src="burger.imgUrl" :alt="`image of ${burger.name}`" class="burger-img">
      <div class="card-text">
        <span class="ms-3 mb-2">{{ burger.name }}</span>
        <span class="me-4 mb-2"> ${{ burger.price }}</span>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.burger-card {
  position: relative;
  max-width: 330px;
  min-width: 100%;
  display: flex;
  justify-content: center;
  margin-left: none;
  margin-right: none;
}

i {
  position: absolute;
  background-position: top;
  font-size: 1.25em;
  width: 100%;
  margin-bottom: 2rem;
  margin-right: 2em;
}
.burger-img {
  object-fit: cover;
  width: 40dvh;
  max-width: 100%;
  height: 30dvh;
    max-height: 100%;
  border-radius: 25px;
  background-position: bottom;
}

.card-text {
  position: absolute;
  bottom: 0;
  display: flex;
  justify-content: space-between;
  width: 100%;
  color: white;
  text-shadow: 0 0 3px #242222;
  background: linear-gradient(0deg, #1716167b 20%, transparent);
  border-radius: 0 0 25px 25px;
}

</style>