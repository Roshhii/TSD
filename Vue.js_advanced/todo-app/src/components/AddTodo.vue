<template>
  <div>
    <form>
      <input v-model="todo.name" type="text" name="title" />
      <button @click="addTodo">Add</button>
    </form>
  </div>
</template>

<script>
import { v4 as uuidv4 } from 'uuid';
export default {
  name: 'AddTodo',
  data() {
    return {
      title: ''
    }
  },
  methods: {
    addTodo() {
      this.valid = true;
      if (this.todo.name != null) {
        this.$router.push({name:'mainPage', params:{newTodoName: this.todo.name}})
      } else {
        this.valid = false;
        setTimeout(() => {
          this.valid = true;
        }, 3000);
      }
      this.title = ''
    }
  }
}
</script>
<style scoped>
</style>