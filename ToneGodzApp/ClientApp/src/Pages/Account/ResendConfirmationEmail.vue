<script setup>
import PrimaryButton from '@/Components/PrimaryButton.vue';
import { useForm } from '@inertiajs/vue3';
import axios from 'axios';
import { toast } from 'vue3-toastify';
const form = useForm({
  email: '',
});

const submit = () => {
  const lastTime = sessionStorage.getItem('lastPressTime');
  if (lastTime) {
    console.log(new Date().getTime() - lastTime);
    if (new Date().getTime() - lastTime < 5000) {
      toast.error('Please wait a moment before sending another email', {
        timeout: 5000,
        position: 'top-center',
        closeButton: true,
      });
    } else {
      axios
        .post('/account/ResendConfirmationEmail', {
          email: form.email,
        })
        .then(() => {
          toast.success('Confirmation email sent', {
            timeout: 5000,
            position: 'top-center',
            closeButton: true,
          });
          sessionStorage.setItem('lastPressTime', new Date().getTime());
        })
        .catch((error) => {
          console.log(error);
          toast.error(error.response.data.message, {
            timeout: 5000,
            position: 'top-center',
            closeButton: true,
          });
        });
    }
  } else {
    axios
      .post('/account/ResendConfirmationEmail', {
        email: form.email,
      })
      .then(() => {
        toast.success('Confirmation email sent', {
          timeout: 5000,
          position: 'top-center',
          closeButton: true,
        });
        sessionStorage.setItem('lastPressTime', new Date().getTime());
      })
      .catch((error) => {
        console.log(error);
        toast.error(error.response.data.message, {
          timeout: 5000,
          position: 'top-center',
          closeButton: true,
        });
      });
  }
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
          Resend confirmation email
        </h1>
        <div v-id="form.errors.message" class="text-error">
          {{ form.errors.message }}
        </div>
        <div class="space-y-4 md:space-y-6">
          <div>
            <label for="email" class="block mb-2 text-sm font-medium">
              Email
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

          <!-- <a
              href="/login"
              class="text-sm font-medium text-primary hover:underline dark:text-primary-500"
            >
              Already have an account?
            </a> -->
          <div class="w-full flex flex-col center">
            <PrimaryButton
              class="w-1/2 mx-auto text-white bg-primary-600 hover:bg-primary-700 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800"
              type="submit"
              @click="submit"
            >
              Send email
            </PrimaryButton>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
