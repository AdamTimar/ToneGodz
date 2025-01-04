<script setup>
import PrimaryButton from '@/Components/PrimaryButton.vue';
import { useForm } from '@inertiajs/vue3';
const form = useForm({
  id: new URLSearchParams(window.location.search).get('userId'),
  password: '',
  confirmPassword: '',
  code: new URLSearchParams(window.location.search).get('code'),
});

const props = defineProps({
  message: {
    type: String,
    default: null,
  },
});

const submit = () => {
  form.post('/account/resetpassword', {
    onError: (errors) => {
    },
    onSuccess: () => {
    },
  });
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
          Reset your password
        </h1>
        <div v-if="props.message" class="text-error">
          {{ props.message }}
        </div>
        <div v-id="form.errors.message" class="text-error">
          {{ form.errors.message }}
        </div>
        <form @submit.prevent="submit" class="space-y-4 md:space-y-6">
          <div>
            <input
              type="hidden"
              name="email"
              id="email"
              v-model="form.userId"
              class="bg-transparent border border-tertiary-300 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
              placeholder="name@company.com"
              required=""
            />
            <div v-id="form.errors.email" class="text-error">
              {{ form.errors.email }}
            </div>
          </div>
          <div>
            <label
              for="password"
              class="block mb-2 text-sm font-medium dark:text-white"
            >
              Password
            </label>
            <input
              type="password"
              name="password"
              id="password"
              v-model="form.password"
              placeholder="••••••••"
              class="bg-transparent border border-tertiary-300 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
              required
            />
          </div>
          <div v-id="form.errors.password" class="text-error">
            {{ form.errors.password }}
          </div>
          <div>
            <label
              for="confirm-password"
              class="block mb-2 text-sm font-medium dark:text-white"
            >
              Confirm Password
            </label>
            <input
              type="password"
              name="confirm-password"
              id="confirm-password"
              v-model="form.confirmPassword"
              placeholder="••••••••"
              class="bg-transparent border border-tertiary-300 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
              required
            />
          </div>
          <div v-id="form.errors.confirmPassword" class="text-error">
            {{ form.errors.confirmPassword }}
          </div>

          <div class="w-full flex flex-col center">
            <PrimaryButton
              type="submit"
              class="w-1/2 mx-auto text-white bg-primary-600 hover:bg-primary-700 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800"
            >
              Reset password
            </PrimaryButton>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>
