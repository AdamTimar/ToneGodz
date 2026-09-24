<template>
  <div class="overflow-hidden text-secondary font-russo">
    <!-- HERO -->
    <section class="w-full">
      <div
        class="mx-auto flex w-[calc(100%-32px)] flex-col gap-7 py-7 md:w-[calc(100%-64px)] md:gap-10 md:py-12 lg:grid lg:w-[min(1400px,calc(100%-64px))] lg:grid-cols-[0.85fr_1.15fr] lg:items-start lg:gap-[70px] lg:py-20"
      >
        <!-- IMAGE / VIDEO -->
        <div class="order-1 w-full lg:order-2 lg:-mt-10">
          <!-- Replace this div with your image/video -->
          <div
            class="relative flex aspect-[1.13/1] w-full items-center justify-center overflow-hidden rounded-[7px] border border-white/10 bg-gradient-to-br lg:h-[580px] lg:aspect-auto lg:rounded-lg"
          >
            <!-- Placeholder -->

            <div class="h-full w-full overflow-hidden">
              <iframe
                class="h-full w-full"
                src="https://www.youtube.com/embed/b5-leQFI-Fo"
                title="Cliff Burton Special"
                frameborder="0"
                allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                allowfullscreen
              ></iframe>
            </div>

            <!-- HD -->
            <!-- <img
              src="/HD.svg"
              alt="HD"
              class="absolute left-5 top-5 h-[28px] w-auto lg:left-7 lg:top-7 lg:h-[34px]"
            /> -->

            <!-- PLAY -->
          </div>
        </div>

        <!-- CONTENT -->
        <div class="order-2 lg:order-1">
          <!-- TITLE -->
          <h1
            class="mb-[23px] text-[clamp(40px,11vw,54px)] font-normal leading-[1.04] tracking-[-0.5px] lg:mb-[25px] lg:text-[clamp(48px,5vw,76px)] lg:leading-[1.03] lg:tracking-[-1px]"
          >
            The Cliff
            <br />
            Burton Special
          </h1>

          <!-- DESCRIPTION -->
          <p
            class="mb-7 max-w-[570px] text-[14px] font-normal leading-[1.55] text-secondary lg:mb-[30px] lg:text-base"
          >
            Go deeper into the tone, gear and recording methods behind Cliff
            Burton’s sound with Flemming Rasmussen - the producer who worked
            with Cliff in the studio.
          </p>

          <!-- FEATURES -->
          <ul class="mb-[30px] flex flex-col gap-[17px] p-0 lg:mb-8">
            <!-- FEATURE 1 -->
            <li
              class="flex items-start gap-[13px] text-[14px] leading-[1.4] text-[#d7d7d7] lg:items-center lg:gap-[14px] lg:text-[15px]"
            >
              <img
                src="/1.Playhead.svg"
                alt=""
                class="mt-[-2px] h-[27px] w-[27px] shrink-0 object-contain lg:mt-0 lg:h-7 lg:w-7"
              />

              <span>100+ minutes of video lessons</span>
            </li>

            <!-- FEATURE 2 -->
            <li
              class="flex items-start gap-[13px] text-[14px] leading-[1.4] text-[#d7d7d7] lg:items-center lg:gap-[14px] lg:text-[15px]"
            >
              <img
                src="/Soundwave.svg"
                alt=""
                class="mt-[-2px] h-[27px] w-[27px] shrink-0 object-contain lg:mt-0 lg:h-7 lg:w-7"
              />

              <span>Bonus bass impulse response included</span>
            </li>

            <!-- FEATURE 3 -->
            <li
              class="flex items-start gap-[13px] text-[14px] leading-[1.4] text-[#d7d7d7] lg:items-center lg:gap-[14px] lg:text-[15px]"
            >
              <img
                src="/Profile.svg"
                alt=""
                class="mt-[-2px] h-[27px] w-[27px] shrink-0 object-contain lg:mt-0 lg:h-7 lg:w-7"
              />

              <span>Built with Flemming Rasmussen</span>
            </li>

            <!-- FEATURE 4 -->
            <li
              class="flex items-start gap-[13px] text-[14px] leading-[1.4] text-[#d7d7d7] lg:items-center lg:gap-[14px] lg:text-[15px]"
            >
              <img
                src="/Mixer.svg"
                alt=""
                class="mt-[-2px] h-[27px] w-[27px] shrink-0 object-contain lg:mt-0 lg:h-7 lg:w-7"
              />

              <span>In-depth tone and studio breakdowns</span>
            </li>
          </ul>

          <!-- PRICE -->
          <div
            class="mb-[22px] flex items-baseline justify-center gap-2 text-[15px] lg:mb-6 lg:justify-start"
          >
            <span>NOW ONLY:</span>

            <strong class="text-[25px] font-normal text-primary lg:text-[21px]">
              $99
            </strong>
          </div>

          <!-- CTA -->
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
    </section>
  </div>
</template>

<style></style>

<script setup>
import ClifftonPrimaryButton from './ClifftonPrimaryButton.vue';
</script>
