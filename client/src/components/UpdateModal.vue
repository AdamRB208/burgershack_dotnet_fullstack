<script setup>
import { burgerService } from '@/services/BurgerService.js';
import { Pop } from '@/utils/Pop.js';
import { ref } from 'vue';


const selectedType = ref('')

const editableFormData = ref ({
  name: '',
  price: '',
  imgUrl: ''
})

const props = defineProps({
  itemId: {
    type: Number,
    default: null
  }
})

const itemType = ref('')

watch(() => props.itemId, async (newId) => {
  if (newId) {
    await loadItemData()
  }
})

async function loadItemData() {
  try {
    if (itemType.value === 'burger') {
      const burger = await burgerService.getBurgersById(props.itemId)
      editableFormData.value = {
        name: '',
        price: '',
        imgUrl: ''
      }
    }
  }
  catch (error){
    Pop.error(error);
  }
}
</script>


<template>
  <form>

  </form>
</template>


<style lang="scss" scoped>

</style>