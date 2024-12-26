<script setup>
import Primarybutton from '@/Components/PrimaryButton.vue';
import { router } from '@inertiajs/vue3';

const redirectToLogin = () => {
  router.visit('/account/login');
};

defineProps({
  message: {
    type: String,
    default: null,
  },
});
</script>

<template>
  <div class="flex flex-col items-center justify-start px-6 py-8 mx-auto">
    <div
      class="w-full bg-[#525151] rounded-lg shadow md:mt-0 sm:max-w-md xl:p-0 text-secondary"
    >
      <div class="p-6 space-y-4 md:space-y-6 sm:p-8">
        <h2
          class="mb-1 text-xl font-bold leading-tight tracking-tight md:text-2xl dark:text-white"
        >
          {{ message }}
        </h2>
        <div
          class="mt-4 space-y-4 lg:mt-5 md:space-y-5 text-tertiary"
          action="#"
        >
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
</template>
