<template>
  <div class="text-container rounded-md bg-transparent">
    <div class="content flex flex-row justify-between mt-18 bg-transparent">
      <div
        class="content-first-element p-11 flex flex-col items-end gap-9 max-w-[50%] bg-transparent"
      >
        <p
          class="become-the-master text-right text-4xl font-bold tracking-widest mb-4"
        >
          WHY IS IT SO SPECIAL
        </p>
        <p
          class="elements text-right text-secondary text-xl max-w-[80%] tracking-[0.3em]"
        >
          <span class="font-bold">Because it does what other EQs can’t</span>
          <br />
          It makes every track feel like it was recorded through real analog
          hardware.
          <br />
          <span class="font-bold">✔ Authentic Circuit Modeling</span>
          <br />
          We didn’t model just “an EQF-2.”
          <br />
          We modeled Flemming Rasmussen’s actual units - the same hardware used
          during the recording of Master of Puppets and …And Justice for All by
          Metallica. No shortcuts. No “inspired by” nonsense.
          <br />
          This is a true analog recreation.
          <br />
          <span class="font-bold">✔ Warm, Sweet, Musical Tone</span>
          <br />
          Your highs get silky.
          <br />
          Your mids get punchy.
          <br />
          Your lows get deep and controlled.
          <br />
          Turn one knob and the mix instantly feels more expensive.
          <br />
          <span>✔ For Vocals, Guitars, Drums, Synths, Mix Bus…</span>
          Everything.
        </p>

        <!-- <div class="text-right bg-transparent">
          <PrimaryButton
            @click="redirectToPurchase()"
            class="w-44 h-14 bg-transparent border-2 rounded-none border-secondary hover:border-hoverPrimary hover:bg-hoverPrimary"
          >
            Buy now
          </PrimaryButton>
        </div> -->
      </div>
      <div class="image-container w-1/2 flex justify-end items-center">
        <img
          src="flemming-rasmussen-eqf2-studio-tonegodz.webp"
          class="w-full h-auto object-contain"
          alt="Pass"
        />
      </div>
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
  window.location.href = '/purchase';
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
