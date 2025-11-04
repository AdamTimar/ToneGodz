<script setup></script>

<template>
  <div class="container w-full flex gap-7 items-center justify-center mx-auto">
    <div class="item w-[50%]">
      <iframe
        class="w-full"
        height="500"
        src="https://www.youtube.com/embed/Aj3v8Tt7HGA"
      ></iframe>
    </div>
    <div class="item w-[50%]">
      <iframe
        class="w-full"
        height="500"
        src="https://www.youtube.com/embed/NTN5rE77V1w"
      ></iframe>
    </div>
    <div class="item w-[50%]">
      <iframe
        class="w-full"
        height="500"
        src="https://www.youtube.com/embed/n46AXCHVWew"
      ></iframe>
    </div>
  </div>
</template>
<style scoped>
@media screen and (max-width: 860px) {
  .container {
    flex-direction: column;
    margin: 0 !important;
  }

  .container .item {
    width: 90%;
    margin: 0 auto;
  }
}
</style>
