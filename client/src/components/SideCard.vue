<script setup>
import { AppState } from '@/AppState.js';
import { Side } from '@/models/Side.js';
import { computed } from 'vue';

const account = computed(() => AppState.account)

defineProps({
  side: { type: Side, required: true }
})


</script>


<template>
  <div v-if="side" class="card-container">
    <div class="side-card">
      <i v-if="account" class="mdi mdi-alpha-x-circle text-danger text-end ms-2" role="button"></i>
      <img :src="side.imgUrl" :alt="`image of ${side.name}`" class="side-img">
      <div class="card-text">
        <span class="ms-3 mb-2">{{ side.name }}</span>
        <span class="me-4 mb-2"> ${{ side.price }}</span>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.side-card {
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

.side-img {
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