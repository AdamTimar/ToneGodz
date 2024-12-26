<!-- src/components/Layout.vue -->
<template>
  <!-- Conditionally render Navigation and Footer based on route -->
  <Navigation class="font-ubuntu" />
  <!-- Your navigation component -->

  <div class="min-h-full flex-1">
    <slot />
    <!-- This will render the page content -->
  </div>

  <Footer class="mt-20" />
  <!-- Optional footer -->
</template>

<script setup>
import Navigation from '@/components/Navigation.vue';
import Footer from '@/components/Footer.vue';
import { onMounted, watch, computed } from 'vue';
import { usePage } from '@inertiajs/vue3';

const page = usePage();

const auth = computed(() => page.props.auth);

onMounted(() => {
  console.log('props', page.props);
});

watch(
  () => page.props.auth,
  (oldAuth, newAuth) => {
    if (oldAuth != newAuth) console.log('Auth updated:', oldAuth, newAuth);
    // Handle any UI updates here based on new auth data
  },
  { immediate: true }
);
</script>

<style scoped></style>
