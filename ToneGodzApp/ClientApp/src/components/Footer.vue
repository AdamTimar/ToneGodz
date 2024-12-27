<template>
  <div class="w-full">
    <div class="text-container p-8 mx-28 text-center border-t-2">
      <p class="title text-center text-2xl text-primary font-extrabold mx-auto">
        REACH OUT
      </p>
      <div class="footer-container flex flex-col justify-center">
        <div
          class="contact-items flex flex-row gap-28 mx-auto my-10 justify-center"
        >
          <div
            class="flex gap-2 bg-[#383838] max-w-fit mx-auto p-3 rounded-md min-w-fit items-center"
          >
            <img
              src="/clipboard.svg"
              alt="clip"
              class="size-9 cursor-pointer"
              @click="copyURL()"
            />
            <p class="text-left text-lg text-secondary break-all">
              contact@tonegodz.com
            </p>
          </div>

          <div class="flex gap-10 p-3 rounded-md justify-center">
            <a
              href="https://www.facebook.com/profile.php?id=61560654952451/"
              target="_blank"
            >
              <img
                src="/facebook.svg"
                alt="phone"
                class="size-9 cursor-pointer"
              />
            </a>
            <a
              href="https://www.instagram.com/tonegodz.production/"
              target="_blank"
            >
              <img src="/insta.svg" alt="phone" class="size-9 cursor-pointer" />
            </a>
            <a href="https://x.com/ToneGodz/" target="_blank">
              <img
                src="/twitter.svg"
                alt="phone"
                class="stroke-2 size-9 cursor-pointer"
              />
            </a>
            <!-- <img src="@/assets/google.svg" alt="phone" class="size-9 cursor-pointer"/> -->
          </div>
        </div>
        <div class="footer-items flex gap-10 p-3 rounded-md justify-center">
          <a
            href="/TermsOfUse.pdf"
            target="_blank"
            class="text-left text-sm text-secondary"
          >
            Terms and Conditions
          </a>
          <a
            href="/PrivacyPolicy.pdf"
            target="_blank"
            class="text-left text-sm text-secondary"
          >
            Privacy Policy
          </a>
          <p class="text-left text-sm text-secondary">
            © 2024 ToneGodz Production LLC - All Rights Reserved.
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import LargeButton from '@/components/LargeButton.vue';

const copyURL = () => {
  navigator.clipboard.writeText('contact@tonegodz.com');
};
</script>

<style scoped>
@media screen and (max-width: 860px) {
  .contact-items {
    width: 100%;
    flex-direction: column;
    gap: 20px;
  }

  .text-container {
    width: 90%;
    margin: 15px auto;
  }

  .footer-items {
    flex-direction: column;
    gap: 20px;
    align-items: center;
    padding: 0px;
  }

  .footer-items p {
    font-size: 1rem;
    text-align: center;
  }
}
</style>
