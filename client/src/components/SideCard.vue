<script setup>
import { Side } from '@/models/Side.js';


defineProps({
  sides: { type: Side, required: true }
})


</script>


<template>
  <div>{{ sides }}</div>
</template>


<style lang="scss" scoped>

</style>