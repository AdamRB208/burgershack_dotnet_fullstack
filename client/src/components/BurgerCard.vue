<script setup>
import { Burger } from '@/models/Burger.js';


defineProps({
  burger: { type: Burger, required: true }
})

</script>


<template>
  <div>{{ burger }}</div>
</template>


<style lang="scss" scoped>

</style>