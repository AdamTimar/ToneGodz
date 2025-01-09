<template>
  <div id="exclusiveBundle" class="w-full mt-20">
    <div class="text-container p-8 mx-28 text-center border-b-4">
      <p
        class="title text-left text-5xl text-primary font-extrabold my-10 m-auto"
      >
        EXCLUSIVE BUNDLE
      </p>
      <p class="title text-left text-4xl text-secondary font-extrabold m-auto">
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
            <p class="text-3xl text-secondary ml-4 mt-1">
              Full 15+ Hour Masterclass ($479)
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
            <p class="text-3xl text-secondary ml-4 mt-1">
              Impulse Response (IR) Pack For Guitar And Bass ($99)
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
            <p class="text-3xl text-secondary ml-4 mt-1">
              Webinar Access ($129)
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
            <p class="text-3xl text-secondary ml-4 mt-1">
              Lifetime Access To Content
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
            <p class="text-3xl text-secondary ml-4 mt-1">20% Discount</p>
          </div>
        </div>
      </div>
    </div>
    <div class="calculations">
      <p class="mt-8 ml-28 px-8 py-4 text-left text-4xl text-secondary m-auto">
        Stacked Value: $707
      </p>
      <p class="ml-28 px-8 py-4 text-left text-4xl text-secondary m-auto">
        Bundle Price After Release: $189.99 (No Webinar Included)
      </p>
      <p class="ml-28 px-8 py-4 text-left text-4xl text-secondary m-auto">
        Pre-Order Offer: $149
      </p>
    </div>
    <div class="button-container flex gap-8 mt-8 mx-28">
      <LargeButton
        class="buttons w-[30%] flex gap-5 justify-center"
        @click="redirectToPurchase()"
      >
        <img src="shoppingcart.svg" alt="cart" class="size-8 cursor-pointer" />
        <p>Pre-order now for $149</p>
      </LargeButton>
      <LargeButton
        v-if="!$page.props.auth"
        class="buttons w-[30%] flex gap-5 justify-center"
        @click="redirectToRegister()"
      >
        <img src="accounticon.svg" alt="cart" class="size-8 cursor-pointer" />
        Create my account for now
      </LargeButton>
    </div>
  </div>
</template>

<script setup>
import LargeButton from '@/components/LargeButton.vue';

import { router } from '@inertiajs/vue3';

const redirectToRegister = () => {
  router.visit('account/register');
};

const redirectToPurchase = () => {
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
    font-size: 2.5rem;
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
    font-size: 2rem;
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
}
</style>
