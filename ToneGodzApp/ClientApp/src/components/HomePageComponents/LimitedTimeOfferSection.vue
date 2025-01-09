<template>
  <div class="w-full flex justify-center mt-20">
    <div class="text-container p-8 w-[45%] rounded-md bg-[#383838] text-center">
      <p
        class="title text-center text-6xl text-primary font-extrabold my-8 m-auto"
      >
        Limited Time Offer
      </p>
      <p
        class="content text-center text-3xl leading-relaxed text-secondary font-bolder mb-16 m-auto w-[90%]"
      >
        The Masterclass is coming out this year, but because you are here early,
        you can take advantage of this!
        <br />
        If you order now, you earn a 20% discount, and not only that!
        <br />
        You can gain access to an exclusive, live webinar with Flemming
        Rasmussen himself. Truly a once-in-a-lifetime opportunity!
      </p>
      <LargeButton
        class="mx-auto !bg-[#54ae61] px-9 flex gap-5"
        @click="redirectToPurchase()"
      >
        <p>Purchase</p>
        <img src="shoppingcart.svg" alt="cart" class="size-8 cursor-pointer" />
      </LargeButton>
      <p class="text-center text-2xl text-secondary font-bolder mt-16 m-auto">
        SEATS ARE LIMITED AND THE OFFER ENDS SOON, SO DON'T MISS OUT!
      </p>
    </div>
  </div>
</template>

<script setup>
import LargeButton from '@/components/LargeButton.vue';

const redirectToPurchase = () => {
  window.location.href = '/purchase';
};
</script>

<style scoped>
@media screen and (max-width: 860px) {
  .text-container {
    width: 90%;
  }

  .title {
    font-size: 2.5rem;
  }

  .content {
    font-size: 1.5rem;
    width: 100% !important;
  }
}
</style>
