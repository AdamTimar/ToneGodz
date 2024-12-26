<template>
  <div
    class="background-image w-full flex items-center justify-end"
    style="
      background-image: url('C.svg');
      background-repeat: no-repeat;
      background-size: cover;
      min-height: 45rem;
    "
  >
    <div class="text-container p-8 rounded-md max-w-[48%]">
      <h1 class="text-left right-2 text-8xl font-bold mb-4">
        Nail the art of metal production
      </h1>
      <p class="text-left text-4xl text-primary font-extrabold">
        with Flemming Rasmussen
      </p>
    </div>
  </div>
</template>

<script setup></script>

<style scoped>
@media screen and (max-width: 1080px) {
  .background-image {
    background-image: url('C.svg');
    background-repeat: no-repeat;
    /* background-size: 1000px !important; */
    max-width: 100%;
    /* min-height: 45rem; */
    /* padding: 3rem 1rem; */
    align-items: center;
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
