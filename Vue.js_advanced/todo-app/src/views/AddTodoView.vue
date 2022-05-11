<template>
  <div>
    <AddTodo v-on:add-todo="addTodo"/>
  </div>
</template>

<script>
import AddTodo from '@/components/AddTodo.vue';
export default {
  name: 'add',
  components: {
    AddTodo
  }
}
</script>


<style scoped>
</style>