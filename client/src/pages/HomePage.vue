<script setup>
import BurgerCard from '@/components/BurgerCard.vue';
import HeaderSection from '@/components/HeaderSection.vue';



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
        <BurgerCard />
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
