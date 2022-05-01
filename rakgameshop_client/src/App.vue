<script>

  export default {
    name: "App",
    components: {
    },
  };
</script>

<template>
  <div id="app">
   <router-view :key="$route.fullPath"></router-view>
  </div>
</template>


<style>
  
</style>