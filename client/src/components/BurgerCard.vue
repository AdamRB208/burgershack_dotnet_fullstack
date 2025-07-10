<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';

const burger = computed(() => AppState.burgers)


</script>


<template>
  <div>{{ burger }}</div>
</template>


<style lang="scss" scoped>

</style>