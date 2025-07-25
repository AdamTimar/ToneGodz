<template>
  <div id="exclusiveBundle" class="w-full mt-20">
    <div class="text-container p-8 mx-28 text-center border-b-4">
      <p
        class="title text-left text-5xl text-primary font-extrabold my-10 m-auto"
      >
        EXCLUSIVE BUNDLE
      </p>
      <p class="title text-left text-3xl text-secondary font-extrabold m-auto">
        The limited time offer will give you access to:
      </p>

      <div class="items-container">
        <div class="item mt-5">
          <div class="flex">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
              class="size-12"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="m18.75 4.5-7.5 7.5 7.5 7.5m-6-15L5.25 12l7.5 7.5"
              />
            </svg>
            <p class="text-2xl text-secondary ml-4 mt-1">
              Full 15+ Hour Masterclass
              <span class="line-through decoration-primary">($380)</span>
            </p>
          </div>
        </div>
        <div class="item mt-5">
          <div class="flex">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
              class="size-12"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="m18.75 4.5-7.5 7.5 7.5 7.5m-6-15L5.25 12l7.5 7.5"
              />
            </svg>
            <p class="text-2xl text-secondary ml-4 mt-1">
              The ToneGodz IR Pack For Guitar And Bass
              <span class="line-through decoration-primary">($99)</span>
            </p>
          </div>
        </div>
        <div class="item mt-5">
          <div class="flex">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
              class="size-12"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="m18.75 4.5-7.5 7.5 7.5 7.5m-6-15L5.25 12l7.5 7.5"
              />
            </svg>
            <p class="text-2xl text-secondary ml-4 mt-1">
              ...The Justice Drums Sample Pack
              <span class="line-through decoration-primary">($99)</span>
            </p>
          </div>
        </div>
        <div class="item mt-5">
          <div class="flex">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
              class="size-12"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="m18.75 4.5-7.5 7.5 7.5 7.5m-6-15L5.25 12l7.5 7.5"
              />
            </svg>
            <p class="text-2xl text-secondary ml-4 mt-1">
              Access To Live Webinars
              <span class="line-through decoration-primary">($129)</span>
            </p>
          </div>
        </div>
        <div class="item mt-5">
          <div class="flex">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
              class="size-12"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="m18.75 4.5-7.5 7.5 7.5 7.5m-6-15L5.25 12l7.5 7.5"
              />
            </svg>
            <p class="text-2xl text-secondary ml-4 mt-1">Lifetime Access</p>
          </div>
        </div>
      </div>
    </div>
    <div class="calculations">
      <p
        class="total-values mt-8 ml-28 px-8 pt-4 pb-2 text-left text-3xl text-secondary m-auto"
      >
        Total Value:
        <span class="line-through decoration-primary">$707</span>
      </p>
      <p
        class="total-values mt-2 ml-28 px-8 pt-4 pb-2 text-left text-3xl text-secondary m-auto"
      >
        Now Only For:
        <span class="text-primary font-extrabold">$149</span>
      </p>
      <!-- <p class="ml-28 px-8 py-4 text-left text-4xl text-secondary m-auto">
        Bundle Price After Release: $189.99 (No Webinar Included)
      </p> -->
      <!-- <p class="ml-28 px-8 py-4 text-left text-4xl text-secondary m-auto">
        Pre-Order Offer: $149
      </p> -->
    </div>
    <div class="button-container flex gap-8 mt-8 mx-28">
      <!-- <LargeButton
        class="buttons w-[30%] flex gap-5 justify-center"
        @click="redirectToPurchase()"
      >
        <img src="shoppingcart.svg" alt="cart" class="size-8 cursor-pointer" />
        <p>Buy Now</p>
      </LargeButton> -->

      <LargeButton
        class="buttons w-[30%] justify-center bg-[#54ae61] flex gap-5 hover:bg-[#3b7b45] border-none lets-see-button"
        @click="redirectToPurchase()"
      >
        <p class="!text-2xl">Buy Now</p>
        <img src="shoppingcart.svg" alt="cart" class="size-8 cursor-pointer" />
      </LargeButton>
    </div>
  </div>
</template>

<script setup>
import LargeButton from '@/components/LargeButton.vue';

import { router, usePage } from '@inertiajs/vue3';

const page = usePage();

const redirectToPurchase = () => {
  if (window.location.hostname !== 'localhost') {
    if (window.fbq) {
      const hasAccess = page.props.auth?.hasAccess;
      if (hasAccess === undefined) {
        fbq('track', 'Purchase button clicked by user without access');
      } else if (!hasAccess) {
        fbq('track', 'Purchase button clicked by ' + page.props.auth.email);
      }
    } else {
      console.error('fbq is not loaded yet.');
    }
  }
  window.location.href = '/purchase';
};
</script>

<style scoped>
.item {
  text-align: center;
  margin-left: auto;
  margin-right: auto;
  width: 60%;
  /* margin-right: 3rem; */
}

@media screen and (max-width: 860px) {
  #exclusiveBundle {
    margin-top: 0 !important;
  }

  .items-container {
    width: 100%;
  }

  .item {
    width: 100%;
    margin-right: 0rem;
  }

  .text-container {
    width: 90%;
    margin: 15px auto;
  }

  .title {
    font-size: 2.25rem;
    text-align: center;
  }

  .content {
    font-size: 1.5rem;
    width: 100% !important;
  }

  .item {
    width: 100% !important;
    margin-right: 0rem;
    margin-bottom: 2rem;
    font-size: 1.5rem;
  }

  .item p {
    text-align: left;
    /* font-size: 2rem; */
    font-size: 1.25rem;
    /* line-height: 50px; */
  }

  .item svg {
    margin-top: 0.5rem;
    width: 2.5rem; /* Adjust as needed */
    height: 2.5rem; /* Match the width */
    flex-shrink: 0; /* Prevent shrinking */
  }

  .button-container {
    flex-direction: column;
    align-items: center;
    margin: 10px 0px;
  }

  .button-container.buttons {
    width: 100%;
    margin-left: 0px;
    margin-right: 0px;
  }

  .calculations {
    width: 90%;
    margin: 15px auto;
  }

  .calculations p {
    margin: 5px;
    font-size: 2rem;
  }

  .size-12 {
    width: 2.5rem; /* Adjust as needed */
    height: 2.5rem; /* Match the width */
    flex-shrink: 0; /* Prevent shrinking */
  }

  .total-values {
    font-size: 1.75rem !important;
  }
}
</style>
