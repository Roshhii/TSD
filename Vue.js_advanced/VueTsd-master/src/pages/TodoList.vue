<template>
  <!-- <div>
    <h1>Todo List</h1>
    <router-link to="add">Add new task</router-link>

    <div v-for="todo in $store.state.todoList" :key="todo.id">
      <router-link
        :to="{ name: 'details', params: { id: todo.id, todo: todo.name } }"
        >{{ todo.name }} -></router-link
      >
    </div>
  </div> -->
  <div>
    <h2>My todolist</h2>
    <router-link to="add">Add new task</router-link>

    <div v-for="todo in $store.state.todoList" :key="todo.id">
      <router-link
        :to="{ name: 'details', params: { id: todo.id, todo: todo.name } }"
        >{{ todo.name }} -></router-link
      >
    </div>
    <ul>
      <li v-bind:key="todo.id" v-for="todo in todos">
        <div v-bind:class="{ completed: todo.completed }">
          <p v-on:click="markComplete">{{ todo.title }}</p>
        </div>
      </li>
    </ul>
  </div>
</template>
<script>
import todoList from "../data/todoList.js";
export default {
  data() {
    return {};
  },
  mounted() {
    console.log(todoList);
  },
  beforeRouteEnter(to, from, next) {
    next((vm) => {
      if (to.params.newTodoName) {
        console.log(vm);
        vm.$store.commit("addTodo", to.params.newTodoName);
      }
    });
  },
};
</script>

