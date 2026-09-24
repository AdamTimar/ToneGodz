<template>
  <div
    class="w-full items-center flex justify-center mt-auto"
    style="min-height: 45rem"
  >
    <div class="text-container p-8 rounded-md max-w-[60%]">
      <h1 class="text-left tracking-[0.2em] text-5xl font-bold mb-8">
        TONEGODZ EQF-2
      </h1>
      <p
        class="text-left font-bold tracking-[0.2em] text-3xl text-secondary leading-[2] mb-8"
      >
        THE LEGENDARY EQ - REBORN. READY. AT YOUR FINGERTIPS.
      </p>
      <div class="text-left">
        <PrimaryButton
          @click="redirectToPurchase()"
          class="w-44 text-base tracking-[0.3em] font-normal h-14 border-2 rounded-none bg-transparent border-secondary hover:border-hoverPrimary hover:bg-hoverPrimary"
        >
          Buy now
        </PrimaryButton>
      </div>
    </div>
  </div>
</template>

<script setup>
import PrimaryButton from '@/components/PrimaryButton.vue';
import { usePage } from '@inertiajs/vue3';
import TheSilentHero from './TheSilentHero.vue';
const page = usePage();

const redirectToPurchase = () => {
  window.location.href = 'flemming-rasmussen/purchase';
};
</script>

<style scoped>
@media screen and (max-width: 1080px) {
  .background-image {
    background-image: url('bg.jpg');
    background-repeat: no-repeat;
    /* background-size: 1000px !important; */
    max-width: 100%;
    /* min-height: 45rem; */
    /* padding: 3rem 1rem; */
    /*align-items: center;*/
  }

  .text-container {
    max-width: 100%;
    padding: 1rem;
  }

  .text-container h1 {
    font-size: 3rem;
    text-align: center;
  }

  .text-container p {
    font-size: 2rem;
    text-align: center;
  }
}
</style>
