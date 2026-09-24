<template>
  <div class="overflow-hidden text-secondary font-russo">
    <!-- WHAT MAKES THIS SPECIAL -->
    <section
      class="mx-auto w-[calc(100%-32px)] py-12 md:w-[calc(100%-64px)] md:py-16 lg:w-[min(1400px,calc(100%-96px))] lg:py-20"
    >
      <!-- TITLE -->
      <h2
        class="mb-8 text-center text-[clamp(40px,10vw,58px)] font-normal leading-[0.98] tracking-[-1px] md:mb-10 lg:mb-12 lg:text-[clamp(48px,5vw,68px)]"
      >
        What makes this special
      </h2>

      <!-- IMAGE + CONTENT -->
      <div
        class="grid items-center gap-8 md:gap-10 lg:grid-cols-[1.15fr_0.85fr] lg:gap-12"
      >
        <!-- IMAGE PLACEHOLDER -->
        <div
          class="relative overflow-hidden rounded-[18px] border border-primary/80 bg-gradient-to-br from-[#26102d] via-[#671d68] to-[#101020] shadow-[0_0_35px_rgba(255,120,20,0.25)]"
        >
          <div
            class="flex aspect-[1.65/1] items-center justify-center text-sm text-white/40"
          >
            <picture>
              <source
                media="(max-width: 767px)"
                srcset="Flemming-Rasmussen-Mobile.webp"
              />
            </picture>
            <img
              src="Flemming Rasmussen Desktop.webp"
              alt="Placeholder"
              class="block h-full w-full object-cover"
            />
          </div>
        </div>

        <!-- TEXT -->
        <div class="flex flex-col">
          <div
            class="space-y-6 text-[14px] font-normal leading-[1.5] text-[#d7d7d7] md:text-[15px] lg:space-y-5 lg:text-[15px]"
          >
            <p>
              This isn’t a basic tone breakdown. There are countless videos,
              forum threads and gear lists about Cliff Burton’s sound.
            </p>

            <p>
              This is different. The Cliff Burton Special was created with
              Flemming Rasmussen, the producer who actually was there in the
              studio with Cliff.
            </p>

            <p>
              Across more than 100 minutes, Flemming takes you inside the sound.
            </p>

            <p>
              This isn’t about just copying a few settings. It’s about
              understanding how the sound came together and how you can create
              your unique tone.
            </p>
          </div>

          <!-- CTA -->
          <div class="mt-7 lg:mt-6">
            <ClifftonPrimaryButton
              class="min-h-[58px] w-full rounded-[5px] border-0 bg-primary px-[22px] py-[15px] text-[16px] font-normal text-secondary transition duration-200 hover:bg-hoverPrimary lg:w-auto lg:min-h-0 lg:text-[14px]"
            >
              <span
                class="pointer-events-none absolute inset-x-0 top-0 h-[45%] bg-gradient-to-b from-white/20 to-transparent"
              ></span>
              <span class="relative z-10">GET INSTANT ACCESS</span>
            </ClifftonPrimaryButton>
          </div>
        </div>
      </div>
    </section>

    <!-- UNDERSTAND THE ENTIRE CHAIN -->
  </div>
</template>

<style></style>

<script setup>
import ClifftonPrimaryButton from './ClifftonPrimaryButton.vue';
</script>
