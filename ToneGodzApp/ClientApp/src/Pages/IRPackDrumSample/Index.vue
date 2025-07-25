<template>
  <div
    class="backstage-pass-section background-image w-full flex justify-center"
  >
    <div class="text-container mx-20 rounded-md max-w-[70%]">
      <p class="text-center text-6xl font-bold mb-4 m-auto text-primary">
        IR Pack & Drum Samples
      </p>
      <div class="thebundle text-center text-2xl mb-8 mt-12 m-auto">
        Thank you for being part of the ToneGodz family! Unleash your tone.
        Download your exclusive ToneGodz packs below and start creating with the
        sound of legends.
      </div>
      <p class="text-3xl text-primary">ToneGodz IR Pack</p>
      <div class="text-xl text-secondary mt-4">
        30 meticulously crafted impulse responses for guitar and bass, including
        both raw and processed versions through legendary analog consoles like
        Neve and Trident A-Range.
      </div>
      <a download="ToneGodz_IR_Pack.zip" href="/The ToneGodz IR Pack.zip">
        <button class="lets-see-button mt-8 mb-4 text-primary">
          Download the IR Pack (.zip)
        </button>
      </a>
      <p class="text-3xl text-primary">Justice Drums Sample Pack</p>
      <div class="text-xl text-secondary mt-4">
        Possibly the heaviest kick and most iconic drum tone, captured with
        authentic vintage gear and produced by Flemming Rasmussen.
      </div>
      <a
        download="The Justice Drums Sample Pack.zip"
        href="/The Justice Drums Sample Pack.zip"
      >
        <button class="lets-see-button mt-8 mb-4 text-primary">
          Download the Drum Sample Pack (.zip)
        </button>
      </a>
    </div>
  </div>
</template>

<script setup></script>

<style scoped>
@media screen and (max-width: 860px) {
  .image-container {
    width: 100%;
    margin: 0 auto;
    padding: 0 !important;
  }

  .thebundle {
    font-size: 2rem !important;
  }

  .textsection {
    width: 100%;
    margin: 0 auto;
    padding: 0 !important;
  }

  .text-container {
    width: 100%;
    margin: 0 auto;
    flex-direction: column;
    align-items: center;
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
