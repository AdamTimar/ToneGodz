<script setup>
import { computed } from 'vue';
import { usePage } from '@inertiajs/vue3';

import Navigation from '@/components/Navigation.vue';
import Footer from '@/components/Footer.vue';

const page = usePage();

const isPluginPage = computed(() => page.url.startsWith('/plugin'));

const isCliffBurtonSpecialPage = computed(() =>
  page.url.startsWith('/cliff-burton-special')
);
</script>

<template>
  <div
    class="layout font-russo"
    :class="{
      'has-plugin-bg': isPluginPage,
      'has-cliffburton-bg': isCliffBurtonSpecialPage,
    }"
  >
    <Navigation class="font-ubuntu bg-transparent border-0 shadow-none" />

    <main class="flex-1">
      <slot />
    </main>

    <Footer class="bg-transparent" />
  </div>
</template>

<style scoped>
.layout {
  position: relative;
  min-height: 100vh;
  display: flex;
  flex-direction: column;
}

/* Background */
.layout::before {
  content: '';
  position: fixed;
  inset: 0;
  z-index: -1;
  background: transparent;
}

/* Plugin background */
.has-plugin-bg::before {
  background: linear-gradient(rgba(45, 45, 50, 0.5), rgba(30, 30, 35, 0.58)),
    url('/tonegodz-eqf2-aphex-eqf2-plugin.webp');

  background-repeat: no-repeat;
  background-size: cover;
  background-position: center;
}

/* Cliff Burton background */
.has-cliffburton-bg::before {
  background: linear-gradient(rgba(45, 45, 50, 0.5), rgba(30, 30, 35, 0.58)),
    url('/Background Desktop.webp');

  background-repeat: no-repeat;
  background-size: cover;
  background-position: center;
}
</style>
