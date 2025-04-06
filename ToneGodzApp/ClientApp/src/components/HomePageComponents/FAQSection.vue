<template>
  <div
    class="backstage-pass-section background-image w-full flex justify-center mt-20"
  >
    <div class="text-container rounded-md">
      <p
        class="text-center text-primary text-5xl font-bold mb-4 w-[60%] m-auto"
      >
        FAQ
      </p>
      <div class="questions-container flex flex-col gap-12 px-28">
        <div class="question flex flex-col gap-6 max-w-[90%]">
          <p
            class="question-title text-left text-2xl text-secondary font-extrabold"
          >
            Why buy it now?
          </p>
          <p
            class="question-answer pl-24 text-left text-xl text-neutral-500 font-bolder"
          >
            For a limited time, you can get the full ToneGodz Masterclass Bundle
            for just 149$. This bundle includes the ToneGodz IR Pack and the
            Justice Drums Sample Pack. You also gain exclusive access to live
            webinars with Flemming Rasmussen. Don’t miss out!
          </p>
        </div>
        <div class="question flex flex-col gap-6 max-w-[90%]">
          <p
            class="question-title text-left text-xl text-secondary font-extrabold"
          >
            How can I access the masterclass?
          </p>
          <p
            class="question-answer pl-24 text-left text-xl text-neutral-500 font-bolder"
          >
          To access the masterclass, follow these simple steps:
          <!-- list that is numbered -->
            <ol class="list-decimal question-answer pl-24 text-left text-xl text-neutral-500 font-bolder">
                <li>Click the "Buy Now" button.</li>
                <li>
                Create an account or log in to your existing account.
                </li>
                <li>
                Complete the purchase process.
                </li>
                <li>
                Once your purchase is confirmed, you will receive an email with
                instructions on how to access the masterclass.
                </li>
            </ol>
 
          </p>
        </div>
        <div class="question flex flex-col gap-6 max-w-[90%]">
          <p
            class="question-title text-left text-xl text-secondary font-extrabold"
          >
            Will I have lifetime access to the masterclass?
          </p>
          <p
            class="question-answer pl-24 text-left text-xl text-neutral-500 font-bolder"
          >
            Yes! Once you purchase the Masterclass, you will have lifetime
            access to the content, allowing you to watch it anytime and at your
            own pace
          </p>
        </div>
        <div class="question flex flex-col gap-6 max-w-[90%]">
          <p
            class="question-title text-left text-2xl text-secondary font-extrabold"
          >
            What’s included in the masterclass?
          </p>
          <p
            class="question-answer pl-24 text-left text-xl text-neutral-500 font-bolder"
          >
            You get over 15 hours of in-depth video lessons from legendary
            producer Flemming Rasmussen, breaking down the recording and mixing
            secrets behind Metallica’s iconic albums: Ride The Lightning, Master
            of Puppets, ...and Justice for All. Plus, you receive:
            <br />
            -...The Justice Drums Sample Pack
            <br />
            – Mix-ready drum sounds inspired by the classic tones
            <br />
            -The ToneGodz IR Pack – Guitar and bass impulse responses engineered
            for massive, studio-quality tones for your own productions.
            <br />
            -Exclusive access to live webinars with Flemming!
          </p>
        </div>
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
  </div>
</template>

<script setup>
import LargeButton from '@/components/LargeButton.vue';
import { router, usePage } from '@inertiajs/vue3';

const redirectToRegister = () => {
  router.visit('account/register');
};
</script>

<style scoped>
@media screen and (max-width: 860px) {
  .questions-container {
    width: 100%;
    padding: 2rem;
  }

  .question-answer {
    padding: 0rem;
  }
}
</style>
