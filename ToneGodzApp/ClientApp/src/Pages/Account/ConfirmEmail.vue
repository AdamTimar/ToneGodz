<script setup>
import Primarybutton from '@/Components/PrimaryButton.vue';
import { router } from '@inertiajs/vue3';

const redirectToLogin = () => {
  router.visit('/account/login');
};
</script>

<template>
  <div class="flex flex-col items-center justify-start px-6 py-8 mx-auto">
    <div
      class="w-full bg-[#525151] rounded-lg shadow md:mt-0 sm:max-w-md xl:p-0 text-secondary"
    >
      <div class="p-6 space-y-4 md:space-y-6 sm:p-8">
        <h1
          class="text-xl font-bold leading-tight tracking-tight text-secondary md:text-2xl"
        >
          Confirm your account
        </h1>

        <div @submit.prevent="submit" class="space-y-4 md:space-y-6">
          <div>Check your inbox to confirm your account</div>
          <div class="w-full flex flex-col center">
            <Primarybutton
              @click="redirectToLogin()"
              type="button"
              class="w-full text-white bg-primary-600 hover:bg-primary-700 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800"
            >
              Back to login
            </Primarybutton>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
