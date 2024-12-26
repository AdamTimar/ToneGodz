<!-- src/App.vue -->
<template>
  <Layout>
    <router-view />  <!-- This renders the current Inertia page -->
  </Layout>
</template>

<script>
import Layout from './components/Layout.vue';

export default {
  components: {
    Layout,
  },
};
</script>
