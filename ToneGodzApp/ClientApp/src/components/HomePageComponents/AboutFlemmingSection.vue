<template>
  <div
    id="aboutFlemming"
    class="background-image w-full flex flex-row justify-end mt-[54rem]"
    style="
      background-image: url('AboutFlemmingBackground.webp');
      background-repeat: no-repeat;
      background-size: cover;
      min-height: 59rem;
    "
  >
    <div class="text-container p-8 mt-28 rounded-md max-w-[45%] self-end">
      <p
        class="quote text-left text-2xl text-secondary font-extralight italic mt-8 ml-20 max-w-[80%]"
      >
        "Working with Metallica was a groundbreaking experience. My mission
        always was to help the artist achieve his vision. Today, my goal is the
        same, to help you achieve the sound. I’m opening the vault of techniques
        and secrets that shaped those iconic albums."
        <br />
          - Flemming Rasmussen -
      </p>
    </div>
    <div class="text-container p-8 mt-28 rounded-md max-w-[70%]">
      <h1 class="text-left right-2 text-8xl font-bold mb-4">
        Flemming Rasmussen
      </h1>
      <p
        class="text-left text-2xl text-secondary font-extralight italic my-8 max-w-[80%]"
      >
        ...a name that resonates powerfully in the world of metal music.
      </p>
      <p
        class="text-left text-2xl text-secondary font-light my-8 max-w-[90%] leading-[3rem]"
      >
        With an illustrious career spanning over decades, Rasmussen's expertise
        and innovative techniques have cemented his reputation as a master
        producer.
      </p>

      <div class="">
        <iframe
          class="w-[75%]"
          height="345"
          src="https://www.youtube.com/embed/I9EFB5JU-S0"
        ></iframe>
      </div>
    </div>
  </div>
</template>

<script setup></script>

<style scoped>
@media screen and (max-width: 1080px) {
  .background-image {
    flex-direction: column;
    background-image: url('AboutFlemmingBackground.webp');
    background-repeat: no-repeat;
    background-position: 20% 0%;
    /* background-size: 1000px !important; */
    max-width: 100%;
    /* min-height: 45rem; */
    /* padding: 3rem 1rem; */
    align-items: center;
  }

  .text-container {
    max-width: 100%;
    /* padding: 1rem; */
  }

  .quote {
    /* font-size: 1.5rem;
        text-align: center; */
    margin-top: 20px !important;
    margin-left: 0px !important;
    max-width: 100% !important;
  }

  .text-container h1 {
    font-size: 3.5rem;
    /* text-align: center; */
  }

  .text-container {
    margin-top: 0px !important;
    max-width: 100% !important;
  }

  .text-container p {
    max-width: 100% !important;
  }
}
</style>
