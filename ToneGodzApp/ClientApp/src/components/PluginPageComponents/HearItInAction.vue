<template>
  <div class="text-container rounded-md bg-transparent pl-24">
    <div
      class="content-first-element pt-8 flex flex-col gap-9 m-auto w-full bg-transparent"
    >
      <p class="become-the-master text-4xl font-bold tracking-widest mb-4">
        Hear it in action
      </p>
      <p class="elements text-left text-secondary text-base tracking-[0.3em]">
        Valami szoveg cuccot ide meg irhatnank hogy toltsuk a helyet vagy
        ilyesmi...
      </p>

      <!-- <div class="text-left">
        <PrimaryButton
          @click="redirectToPurchase()"
          class="w-44 text-base tracking-[0.3em] font-normal h-14 border-2 rounded-none bg-transparent border-secondary hover:border-hoverPrimary hover:bg-hoverPrimary"
        >
          Buy now
        </PrimaryButton>
      </div> -->
    </div>
  </div>
</template>

<script setup>
import LargeButton from '@/components/LargeButton.vue';
import PrimaryButton from '@/components/PrimaryButton.vue';

const scrollToSection = (sectionId) => {
  const element = document.getElementById(sectionId);
  if (element) {
    element.scrollIntoView({ behavior: 'smooth' });
  }
};

const redirectToPurchase = () => {
  window.location.href = 'flemming-rasmussen/purchase';
};
</script>

<style scoped>
@media screen and (max-width: 860px) {
  .backstage-pass-section {
    /* background-image: url('src/assets/backstagePass.svg'); */
    /* background-repeat: no-repeat; */
    /* background-size: cover; */
    max-width: 100%;
    display: block !important;
    /* min-height: 365px; */
    /* padding: 3rem 1rem; */
    align-items: center;
    font-size: 1rem;
    margin-top: 2rem !important;
  }
  .backstage-pass-section .text-container {
    width: 100%;
    /* padding: 1rem; */
  }
  .backstage-pass-section .text-container .content {
    display: block;
    width: 100%;
    align-items: center;
  }

  .content-first-element {
    max-width: 100% !important;
    display: block !important;
    text-align: center;
  }

  .backstage-pass-section .text-container .become-the-master {
    font-size: 1.5rem;
    text-align: center;
    width: 100%;
  }

  .backstage-pass-section .text-container p {
    font-size: 2.5rem;
    width: 100%;
    text-align: center;
  }

  .backstage-pass-section .image-container {
    max-width: 100%;
    padding: 1rem;
  }

  .backstage-pass-section .image-container img {
    width: 100%;
  }

  .backstage-pass-section .text-container .elements {
    font-size: 1.5rem;
    margin: 1.5rem 0;
    text-align: left;
    width: 100%;
  }

  .lets-see-button {
    width: 70% !important;
    padding: 0.8rem 1rem;
  }

  .text-container {
    padding: 0 2rem !important;
  }
}
</style>
