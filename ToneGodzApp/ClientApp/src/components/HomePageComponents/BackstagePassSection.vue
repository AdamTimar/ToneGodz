<template>
  <div
    class="backstage-pass-section background-image w-full flex justify-center mt-20"
  >
    <div class="text-container p-8 rounded-md">
      <p class="text-center text-7xl font-bold mb-4 w-[60%] m-auto">
        Your backstage pass to iconic sounds!
      </p>
      <div class="content flex flex-row gap-16 justify-between mt-18">
        <div
          class="content-first-element flex flex-col gap-9 m-auto max-w-[30%]"
        >
          <p
            class="become-the-master text-center text-5xl text-primary font-bold mb-4 m-auto"
          >
            Become the master:
          </p>
          <p class="elements text-left text-xl text-secondary font-bolder">
            Unlock the secrets behind legendary albums (Ride the Lightning,
            Master of Puppets, ...and Justice for All by Metallica), covering
            every single detail.
          </p>
          <p class="elements text-left text-xl text-secondary font-bolder">
            Get exclusive access to Flemming Rasmussen's techniques and
            knowledge in this comprehensive 15+ hour masterclass.
          </p>
          <p class="elements text-left text-xl text-secondary font-bolder">
            Expand your sonic arsenal with industry-leading Impulse Responses
            for guitar and bass.
          </p>
          <LargeButton
            @click="scrollToSection('exclusiveBundle')"
            class="lets-see-button w-[50%] font-extrabold"
          >
            Let's see
          </LargeButton>
        </div>

        <div
          class="image-container max-w-[35%] flex justify-items-start m-auto"
        >
          <img src="backstagePass.svg" alt="Pass" />
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import LargeButton from '@/components/LargeButton.vue';

const scrollToSection = (sectionId) => {
  const element = document.getElementById(sectionId);
  if (element) {
    element.scrollIntoView({ behavior: 'smooth' });
  }
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
}
</style>
