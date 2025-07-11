<script setup>
import { Side } from '@/models/Side.js';


defineProps({
  side: { type: Side, required: true }
})


</script>


<template>
  <div v-if="side">{{ side }}</div>
</template>


<style lang="scss" scoped>

</style>