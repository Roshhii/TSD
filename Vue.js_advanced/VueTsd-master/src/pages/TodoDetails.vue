<template>
  <div>
    <h2>Todo details:</h2>
     
    <p>Name:<strong>{{$route.params.todo}}</strong></p>
    <button @click="goBack">Go back</button>
  </div>
</template>
<script>
export default {
    props: ["todo"],
  data() {
    return {
     
    };
  },
  methods:{
      goBack(){
          this.$router.push({name:'mainPage'})
      }
  }
};
</script>
