<template>
  <div class="w-full flex justify-center mt-20">
    <div class="p-8 rounded-md">
      <p
        class="title text-center text-6xl font-bold mb-4 w-[100%] m-auto text-primary"
      >
        Always looking for "the tone"?
      </p>
      <p
        class="subtitle text-center text-4xl font-bold mb-4 w-[60%] m-auto text-neutral-500"
      >
        Let's face it, finding the perfect sound can drive you mad!
      </p>
      <div class="content-container flex">
        <div class="content-image absolute left-0">
          <img src="singleFlemming.svg" alt="Flemming" />
        </div>

        <div class="text-container absolute right-20 mx-60 my-32 max-w-[30%]">
          <!-- <p class="text-center text-5xl text-primary font-bold mb-4 m-auto">You start tweaking buttons for 12 hours straight until you find the sweet spot, only to realize the day after, that it doesn't sound alright.</p> -->
          <p class="text-left text-2xl text-neutral-500 font-bolder mb-9 mt-9">
            You start tweaking buttons for 12 hours straight until you find the
            sweet spot, only to realize the day after, that it doesn't sound
            alright.
          </p>
          <p class="text-left text-2xl text-neutral-500 font-bolder mb-9">
            You’ve scoured the internet for tutorials, but they never quite
            reveal the real secrets behind the epic sounds of legendary albums.
            And there was a lack of authentic resources...
          </p>
          <img
            class="max-w-[50%] absolute right-0"
            src="up-until-now.svg"
            alt="until-now"
          />
          <LargeButton
            class="meet-flemming-button max-w-[50%] mt-48 flex mx-auto"
            @click="scrollToSection('aboutFlemming')"
          >
            Meet Flemming Rasmussen
          </LargeButton>
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
  .title {
    font-size: 2.5rem;
  }

  .subtitle {
    font-size: 1.5rem;
    width: 100% !important;
  }

  .content-container {
    position: relative !important;
  }

  .text-container {
    max-width: 90% !important;
    right: 0;
    left: 0;
    margin: 0 auto;
  }

  .content-image {
    display: none;
  }

  .meet-flemming-button {
    width: 60% !important;
    margin-top: 8rem !important;
    padding: 1rem !important;
  }
}
</style>
