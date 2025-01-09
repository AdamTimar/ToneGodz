<script setup>
import PrimaryButton from '@/Components/PrimaryButton.vue';
import { useForm } from '@inertiajs/vue3';
const form = useForm({
  email: '',
  password: '',
  remember: false,
});

let url = '/account/login';
const returnUrl = new URLSearchParams(window.location.search).get('ReturnUrl');
if (returnUrl) {
  url = url + `?returnUrl=${returnUrl}`;
  console.log(url);
}

const submit = () => {
  form.post(url, {
    onError: (errors) => {
      // Optionally handle errors
    },
    onSuccess: () => {},
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
          Sign in to your account
        </h1>

        <div v-id="form.errors.message" class="text-error">
          {{ form.errors.message }}
        </div>
        <form @submit.prevent="submit" class="space-y-4 md:space-y-6">
          <div>
            <label for="email" class="block mb-2 text-sm font-medium">
              Your email
            </label>
            <input
              type="email"
              name="email"
              id="email"
              v-model="form.email"
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
          <div class="flex items-center justify-between">
            <div class="flex items-start">
              <div class="flex items-center h-5">
                <input
                  id="remember"
                  v-model="form.remember"
                  aria-describedby="remember"
                  type="checkbox"
                  class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-primary-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-primary-600 dark:ring-offset-gray-800"
                />
              </div>
              <div class="ml-3 text-sm">
                <label for="remember" class="text-secondary">Remember me</label>
              </div>
            </div>
            <a
              href="/account/forgotpassword"
              class="text-sm font-medium text-primary hover:underline dark:text-primary-500"
            >
              Forgot password?
            </a>
          </div>
          <div class="w-full flex flex-col center">
            <PrimaryButton
              type="submit"
              class="w-1/2 mx-auto text-white bg-primary-600 hover:bg-primary-700 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800"
            >
              Sign in
            </PrimaryButton>

            <p class="text-sm mx-auto mt-2 font-light text-secondary">
              Don’t have an account yet?
              <a
                href="/account/register"
                class="font-medium text-primary hover:underline dark:text-primary-500"
              >
                Sign up
              </a>
            </p>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>
