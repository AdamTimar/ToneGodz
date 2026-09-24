<template>
  <section class="relative overflow-hidden py-14 text-white md:py-16 lg:py-12">
    <div
      class="mx-auto w-[calc(100%-32px)] max-w-[1400px] md:w-[calc(100%-64px)] lg:w-[calc(100%-72px)]"
    >
      <!-- ========================================= -->
      <!-- DESKTOP -->
      <!-- ========================================= -->

      <div class="hidden lg:grid lg:grid-cols-[1.15fr_0.85fr] lg:gap-8">
        <!-- LEFT SIDE -->
        <div>
          <!-- TITLE -->
          <h2
            class="ml-20 font-russo text-[56px] font-normal leading-[0.92] tracking-[-1px] text-white"
          >
            CLAIM YOUR
            <br />
            ALL ACCESS PASS
          </h2>

          <!-- BENEFITS -->
          <div class="mt-8 grid grid-cols-4">
            <!-- BENEFIT 1 -->
            <div class="px-3 text-center">
              <div
                class="mx-auto flex size-[66px] items-center justify-center rounded-full border border-primary"
              >
                <img
                  src="Flemming icon.webp"
                  alt=""
                  class="size-full object-contain"
                />
              </div>

              <h3
                class="mt-4 font-sans text-[14px] font-normal leading-[1.15] text-white"
              >
                FIRST-HAND
                <br />
                LEARNING
              </h3>

              <p
                class="mt-2 font-sans text-[13px] leading-[1.35] text-[#d7d7d7]"
              >
                Learn directly from
                <br />
                the man who was
                <br />
                there.
              </p>
            </div>

            <!-- BENEFIT 2 -->
            <div class="border-l border-primary px-3 text-center">
              <div class="mx-auto flex size-[66px] items-center justify-center">
                <img src="Hd.svg" alt="" class="size-full object-contain" />
              </div>

              <h3
                class="mt-4 font-sans text-[14px] font-normal leading-[1.15] text-white"
              >
                80+ MINUTES OF
                <br />
                VIDEO LESSONS
              </h3>

              <p
                class="mt-2 font-sans text-[13px] leading-[1.35] text-[#d7d7d7]"
              >
                In-depth lessons,
                <br />
                stories and
                <br />
                demonstrations.
              </p>
            </div>

            <!-- BENEFIT 3 -->
            <div class="border-l border-primary px-3 text-center">
              <div
                class="mx-auto flex size-[66px] items-center justify-center rounded-full border border-primary"
              >
                <img src="Cab.svg" alt="" class="size-full object-contain" />
              </div>

              <h3
                class="mt-4 font-sans text-[14px] font-normal leading-[1.15] text-white"
              >
                BONUS BASS IR
                <br />
                PACK
              </h3>

              <p
                class="mt-2 font-sans text-[13px] leading-[1.35] text-[#d7d7d7]"
              >
                Bring the captured
                <br />
                sound into your
                <br />
                own tone.
              </p>
            </div>

            <!-- BENEFIT 4 -->
            <div class="border-l border-primary px-3 text-center">
              <div
                class="mx-auto flex size-[66px] items-center justify-center rounded-full border border-primary"
              >
                <img
                  src="Flemming Rasmussen Notes.webp"
                  alt=""
                  class="size-full object-contain"
                />
              </div>

              <h3
                class="mt-4 font-sans text-[14px] font-normal leading-[1.15] text-white"
              >
                BEYOND THE
                <br />
                DETAILS
              </h3>

              <p
                class="mt-2 font-sans text-[13px] leading-[1.35] text-[#d7d7d7]"
              >
                Original studio notes
                <br />
                and rare details
                <br />
                beyond the gear lists.
              </p>
            </div>
          </div>
        </div>

        <!-- RIGHT SIDE -->
        <div
          class="rounded-[10px] border border-primary bg-black/60 px-5 pb-6 pt-5 text-center md:px-8"
        >
          <h3
            class="font-sans text-[18px] font-normal leading-none text-[#d7d7d7] md:text-[20px]"
          >
            GET INSTANT ACCESS NOW
          </h3>

          <!-- PRICE -->
          <div class="mt-4">
            <div
              class="mx-auto flex w-fit items-center justify-center gap-2 font-sans font-bold leading-none md:gap-3"
            >
              <div class="relative text-[42px] text-[#d7d0c4] md:text-[54px]">
                <span>$149</span>

                <span
                  class="absolute left-[-4px] right-[-4px] top-1/2 h-[3px] -translate-y-1/2 rotate-[-10deg] bg-[#ff5428]"
                ></span>
              </div>

              <span
                class="text-[68px] tracking-[-4px] text-[#e5ded2] md:text-[88px] md:tracking-[-5px]"
              >
                $99
              </span>
            </div>
          </div>

          <!-- BUTTON -->
          <ClifftonPrimaryButton
            class="mt-6 min-h-[58px] w-full rounded-[5px] border-0 bg-primary px-[22px] py-[15px] text-[16px] font-normal text-secondary transition duration-200 hover:bg-hoverPrimary lg:w-auto lg:min-h-0 lg:text-[14px]"
          >
            <span
              class="pointer-events-none absolute inset-x-0 top-0 h-[45%] bg-gradient-to-b from-white/20 to-transparent"
            ></span>
            <span class="relative z-10">GET INSTANT ACCESS</span>
          </ClifftonPrimaryButton>

          <!-- SECURE CHECKOUT -->
          <div class="mt-5 md:mt-6">
            <p class="font-sans text-[12px] text-[#d7d7d7] md:text-[13px]">
              Secure checkout powered by
              <span class="font-bold">Stripe</span>
            </p>

            <div class="mt-3 flex items-center justify-center gap-2.5 md:gap-5">
              <div
                class="flex h-[32px] w-[52px] items-center justify-center rounded-[3px] bg-white p-1.5"
              >
                <img
                  src="visa.svg"
                  alt="Visa"
                  class="max-h-full max-w-full object-contain"
                />
              </div>

              <div
                class="flex h-[32px] w-[52px] items-center justify-center rounded-[3px] bg-white p-1.5"
              >
                <img
                  src="mastercard.svg"
                  alt="Mastercard"
                  class="max-h-full max-w-full object-contain"
                />
              </div>

              <div
                class="flex h-[32px] w-[52px] items-center justify-center rounded-[3px] bg-white p-1.5"
              >
                <img
                  src="amex.svg"
                  alt="American Express"
                  class="max-h-full max-w-full object-contain"
                />
              </div>

              <div
                class="flex h-[32px] w-[52px] items-center justify-center rounded-[3px] bg-white p-1.5"
              >
                <img
                  src="link.svg"
                  alt="Discover"
                  class="max-h-full max-w-full object-contain"
                />
              </div>

              <div
                class="flex h-[32px] w-[52px] items-center justify-center rounded-[3px] bg-white p-1.5"
              >
                <img
                  src="applepay.svg"
                  alt="Apple Pay"
                  class="max-h-full max-w-full object-contain scale-[2.3]"
                />
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- ========================================= -->
      <!-- MOBILE -->
      <!-- ========================================= -->

      <div class="lg:hidden">
        <!-- TITLE -->
        <h2
          class="text-center font-russo text-[42px] font-normal leading-[0.94] tracking-[-1px] text-white md:text-[52px]"
        >
          CLAIM YOUR
          <br />
          ALL ACCESS PASS
        </h2>

        <!-- BENEFITS -->
        <div class="mt-8 flex flex-col gap-2">
          <!-- BENEFIT 1 -->
          <div
            class="flex min-h-[140px] items-center gap-6 rounded-[14px] border-2 border-primary px-5 py-5"
          >
            <div
              class="flex size-[90px] shrink-0 items-center justify-center rounded-full border border-primary"
            >
              <img
                src="Flemming icon.webp"
                alt=""
                class="size-full object-contain"
              />
            </div>

            <div>
              <h3
                class="font-sans text-[21px] font-bold leading-[1.05] text-white"
              >
                FIRST-HAND
                <br />
                LEARNING
              </h3>

              <p
                class="mt-2 font-sans text-[16px] leading-[1.3] text-[#d7d7d7]"
              >
                Learn directly from the man who was there.
              </p>
            </div>
          </div>

          <!-- BENEFIT 2 -->
          <div
            class="flex min-h-[140px] items-center gap-6 rounded-[14px] border-2 border-primary px-5 py-5"
          >
            <div class="flex size-[90px] shrink-0 items-center justify-center">
              <img src="Hd.svg" alt="" class="size-full object-contain" />
            </div>

            <div>
              <h3
                class="font-sans text-[21px] font-bold leading-[1.05] text-white"
              >
                80+ MINUTES OF
                <br />
                VIDEO LESSONS
              </h3>

              <p
                class="mt-2 font-sans text-[16px] leading-[1.3] text-[#d7d7d7]"
              >
                In-depth lessons, stories and demonstrations.
              </p>
            </div>
          </div>

          <!-- BENEFIT 3 -->
          <div
            class="flex min-h-[140px] items-center gap-6 rounded-[14px] border-2 border-primary px-5 py-5"
          >
            <div
              class="flex size-[90px] shrink-0 items-center justify-center rounded-full border border-primary"
            >
              <img src="Cab.svg" alt="" class="size-full object-contain" />
            </div>

            <div>
              <h3
                class="font-sans text-[21px] font-bold leading-[1.05] text-white"
              >
                BONUS BASS IR
                <br />
                PACK
              </h3>

              <p
                class="mt-2 font-sans text-[16px] leading-[1.3] text-[#d7d7d7]"
              >
                Bring the captured sound into your own tone.
              </p>
            </div>
          </div>

          <!-- BENEFIT 4 -->
          <div
            class="flex min-h-[140px] items-center gap-6 rounded-[14px] border-2 border-primary px-5 py-5"
          >
            <div
              class="flex size-[90px] shrink-0 items-center justify-center rounded-full border border-primary"
            >
              <img
                src="Flemming Rasmussen Notes.webp"
                alt=""
                class="size-full object-contain"
              />
            </div>

            <div>
              <h3
                class="font-sans text-[21px] font-bold leading-[1.05] text-white"
              >
                BEYOND THE
                <br />
                DETAILS
              </h3>

              <p
                class="mt-2 font-sans text-[16px] leading-[1.3] text-[#d7d7d7]"
              >
                Original studio notes and rare details beyond the gear lists.
              </p>
            </div>
          </div>
        </div>

        <!-- PURCHASE CARD -->
        <div
          class="mt-5 rounded-[10px] border border-primary bg-black/60 px-5 pb-6 pt-5 text-center"
        >
          <h3
            class="font-sans text-[18px] font-normal leading-none text-[#d7d7d7]"
          >
            GET INSTANT ACCESS NOW
          </h3>

          <!-- PRICE -->
          <div class="mt-4">
            <div
              class="mx-auto flex w-fit items-center justify-center gap-2 font-sans font-bold leading-none"
            >
              <div class="relative text-[42px] text-[#d7d0c4]">
                <span>$149</span>

                <span
                  class="absolute left-[-4px] right-[-4px] top-1/2 h-[3px] -translate-y-1/2 rotate-[-10deg] bg-[#ff5428]"
                ></span>
              </div>

              <span class="text-[68px] tracking-[-4px] text-[#e5ded2]">
                $99
              </span>
            </div>
          </div>

          <!-- BUTTON -->
          <ClifftonPrimaryButton
            class="mt-6 w-full rounded-[5px] bg-[#ff5428] px-5 py-3.5 font-sans text-[17px] font-bold text-white shadow-[0_0_18px_rgba(255,84,40,0.55)]"
          >
            GET INSTANT ACCESS
          </ClifftonPrimaryButton>

          <!-- PAYMENT -->
          <div class="mt-5">
            <p class="font-sans text-[12px] text-[#d7d7d7]">
              Secure checkout powered by
              <span class="font-bold">Stripe</span>
            </p>

            <div class="mt-3 flex items-center justify-center gap-2.5">
              <img
                src="visa.svg"
                alt="Visa"
                class="h-[23px] w-auto object-contain"
              />
              <img
                src="mastercard.svg"
                alt="Mastercard"
                class="h-[23px] w-auto object-contain"
              />
              <img
                src="amex.svg"
                alt="American Express"
                class="h-[23px] w-auto object-contain"
              />
              <img
                src="link.svg"
                alt="Discover"
                class="h-[23px] w-auto object-contain"
              />
              <img
                src="applepay.svg"
                alt="Apple Pay"
                class="h-[23px] w-auto object-contain"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
import ClifftonPrimaryButton from './ClifftonPrimaryButton.vue';
</script>
