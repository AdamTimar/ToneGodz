<script setup>
import { computed } from 'vue';
import { usePage } from '@inertiajs/vue3';
import Navigation from '@/components/Navigation.vue';
import Footer from '@/components/Footer.vue';

const page = usePage();

// safest check in Inertia
const isPluginPage = computed(() => page.component.startsWith('Plugin'));
</script>

<template>
  <div
    class="layout font-russo min-h-screen"
    :class="{ 'has-plugin-bg': isPluginPage }"
  >
    <Navigation class="font-ubuntu bg-transparent border-0 shadow-none" />

    <main>
      <slot />
    </main>

    <Footer class="mt-5 bg-transparent" />
  </div>
</template>

<style scoped>
.layout {
  position: relative;
  min-height: 100vh;
}

/* default = no background */
.layout::before {
  content: '';
  position: fixed;
  inset: 0;
  z-index: -1;
  background: transparent;
}

/* only plugin page shows background */
.has-plugin-bg::before {
  background: linear-gradient(rgba(45, 45, 50, 0.5), rgba(30, 30, 35, 0.58)),
    url('/tonegodz-eqf2-aphex-eqf2-plugin.webp');

  background-repeat: no-repeat;
  background-size: cover;
  background-position: center;
}
</style>
