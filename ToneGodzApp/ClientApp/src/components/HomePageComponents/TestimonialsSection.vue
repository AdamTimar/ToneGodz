<template>
  <div class="flex items-center justify-between max-w-[90%] mx-auto my-8">
    <div class="flex flex-col items-end justify-start w-1/4 pr-12">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        stroke-width="3"
        stroke="currentColor"
        class="size-14"
        @click="showPreviousTestimonial"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          d="M15.75 19.5 8.25 12l7.5-7.5"
        />
      </svg>
    </div>

    <div
      class="review-container flex flex-col items-start justify-start px-6 py-8 mx-auto w-2/4"
    >
      <div class="flex items-center justify-start w-full mb-7">
        <img
          :src="testimonials[currentIndex].profile"
          alt="backstage-pass"
          class="backstage-pass-section w-20 h-auto mr-7"
        />
        <div>
          <div class="text-2xl text-primary">
            {{ testimonials[currentIndex].name }}
          </div>
          <div class="flex">
            <svg
              v-for="index in testimonials[currentIndex].stars"
              :key="index"
              xmlns="http://www.w3.org/2000/svg"
              fill="#ffc83d"
              viewBox="0 0 24 24"
              stroke-width="0"
              stroke="currentColor"
              class="size-6"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="M11.48 3.499a.562.562 0 0 1 1.04 0l2.125 5.111a.563.563 0 0 0 .475.345l5.518.442c.499.04.701.663.321.988l-4.204 3.602a.563.563 0 0 0-.182.557l1.285 5.385a.562.562 0 0 1-.84.61l-4.725-2.885a.562.562 0 0 0-.586 0L6.982 20.54a.562.562 0 0 1-.84-.61l1.285-5.386a.562.562 0 0 0-.182-.557l-4.204-3.602a.562.562 0 0 1 .321-.988l5.518-.442a.563.563 0 0 0 .475-.345L11.48 3.5Z"
              />
            </svg>
          </div>
        </div>
      </div>

      <div class="break-words text-xl">
        {{ testimonials[currentIndex].text }}
      </div>
    </div>
    <div class="flex flex-col items-start justify-start w-1/4 pl-12">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        stroke-width="3"
        stroke="currentColor"
        class="size-14"
        @click="showNextTestimonial"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          d="m8.25 4.5 7.5 7.5-7.5 7.5"
        />
      </svg>
    </div>
  </div>
</template>
<script setup>
import { ref } from 'vue';
const testimonials = [
  {
    name: 'Vicente T.',
    text: `This really is a great package. Learned so much that I wanted to know from those recordings! The Cliff Burton set up alone is worth the purchase of this package.`,
    profile: 'Vicente_T_ToneGodz.webp',
    stars: 5,
  },
  {
    name: 'Steven R.',
    text: `Love it, it’s everything you could ask for, 10 out of 10 recommend for all other metal engineers and artists period wonderful masterclass with awesome music. Love It!! Also if you are just a fan it’s fun from the fan side as well 10 outa 10 for fans too. As a professional I’m 3k recordings in and it’s giving me ideas. So even eye opening for long time creatives as well`,
    profile: 'Steven_R_ToneGodz.webp',
    stars: 5,
  },
  {
    name: 'Roy P.',
    text: `The knowledge I gained from this masterclass is going to pay dividends in the future. Extremely well worth every penny.`,
    profile: 'Roy_P_ToneGodz.webp',
    stars: 5,
  },
  {
    name: 'Robert A.',
    text: `Worth every cent! It is all that us nerds wanted and more! Thank you for doing this!`,
    profile: 'Robert_A_ToneGodz.webp',
    stars: 5,
  },
  {
    name: 'Aaron R.',
    text: `I love all of what the masterclass has to offer! A special thank you to ToneGodz for taking the time, and helping me to get the IR pack to work on my Line 6 Helix pedal! They sound great! Y’all are awesome! Thank you!”`,
    profile: 'Aaron_R_ToneGodz.webp',
    stars: 5,
  },
  {
    name: 'Damian U',
    text: `I throughly enjoyed the masterclass! Can’t recommend it enough! Thank you so much!`,
    profile: 'Damian_U_ToneGodz.webp',
    stars: 5,
  },
];

const currentIndex = ref(0);

const showPreviousTestimonial = () => {
  const previousIndex =
    currentIndex.value === 0 ? testimonials.length - 1 : currentIndex.value - 1;
  currentIndex.value = previousIndex;
};
const showNextTestimonial = () => {
  const nextIndex =
    currentIndex.value === testimonials.length - 1 ? 0 : currentIndex.value + 1;
  currentIndex.value = nextIndex;
};
</script>

<style scoped>
@media screen and (max-width: 860px) {
  .review-container {
    padding: 0 !important;
  }
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
