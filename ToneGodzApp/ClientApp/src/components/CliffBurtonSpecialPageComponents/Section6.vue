<template>
  <section
    class="relative overflow-hidden py-14 text-white md:py-16 lg:pt-32 lg:min-h-[850px]"
  >
    <!-- BACKGROUND -->
    <picture class="pointer-events-none absolute inset-0 z-0">
      <!-- MOBILE BACKGROUND -->
      <source media="(max-width: 1023px)" srcset="Mic-Background-Mobile.webp" />

      <!-- DESKTOP BACKGROUND -->
      <img
        src="Mic Background Desktop.webp"
        alt=""
        class="absolute top-[250px] left-0 w-[55%] rotate-[110deg] opacity-70 lg:w-[20%]"
      />
    </picture>

    <!-- CONTENT -->
    <div
      class="relative z-10 mx-auto w-[calc(100%-32px)] max-w-[1400px] md:w-[calc(100%-64px)]"
    >
      <!-- TITLE -->
      <div class="mx-auto max-w-[1000px] text-center">
        <h2
          class="font-russo text-[42px] font-normal leading-[0.98] tracking-[-1px] text-white md:text-[52px] lg:text-[64px]"
        >
          Trusted by Players, Producers
          <br />
          &amp; Clifffanatics
        </h2>
      </div>

      <!-- TESTIMONIALS -->
      <div class="mt-10 grid gap-5 md:mt-12 lg:grid-cols-3 lg:gap-8">
        <!-- TESTIMONIAL 1 -->
        <div
          class="relative flex h-full flex-col rounded-[14px] border border-primary bg-black/75 px-6 py-7 md:px-7 lg:px-5 lg:py-5"
        >
          <!-- Quote -->
          <div
            class="absolute left-5 top-1 font-serif text-[110px] leading-none text-white/10"
          >
            “
          </div>

          <div class="relative z-10 flex h-full flex-col">
            <!-- Stars -->
            <div
              class="ml-[105px] flex gap-1 text-[24px] leading-none text-[#ffb800] lg:ml-[65px] lg:text-[18px]"
            >
              <span v-for="star in 5" :key="star">★</span>
            </div>

            <!-- Testimonial -->
            <p
              class="mt-5 ml-[105px] font-sans text-[17px] leading-[1.45] text-[#e4e4e4] lg:ml-[65px] lg:mt-4 lg:text-[14px]"
            >
              “Honestly I expected this to be only about recreating the bass
              tone, but there’s so much more in here. All the little details
              made it feel like you're getting a look behind the curtain. I’ve
              been a Cliff fan for years and this is one of the best things I’ve
              bought in a long time. 100% worth it!”
            </p>

            <!-- Divider -->
            <div
              class="ml-[105px] mt-6 h-[2px] w-[90px] bg-primary lg:ml-[30%] lg:mt-4 lg:w-[60px]"
            ></div>

            <!-- Profile / Author -->
            <div
              class="mt-auto flex items-center gap-4 pt-6 lg:gap-3 lg:pt-5 lg:ml-[20px]"
            >
              <!-- Profile image -->
              <div
                class="flex size-[82px] shrink-0 items-center justify-center overflow-hidden rounded-full border border-primary bg-black lg:size-[52px]"
              >
                <img
                  src="/Andrew J.webp"
                  alt="Andrew J."
                  class="h-full w-full object-cover"
                />
              </div>

              <!-- Name / Role / Band -->
              <div class="min-w-0">
                <h3
                  class="font-sans text-[18px] font-normal text-white lg:text-[13px]"
                >
                  Justin M.
                </h3>

                <p
                  class="mt-1 font-sans text-[16px] text-primary lg:text-[12px]"
                >
                  Bassist
                </p>

                <p
                  class="mt-1 font-sans text-[15px] text-white/55 lg:text-[11px]"
                >
                  Symphony X
                </p>
              </div>
            </div>
          </div>
        </div>

        <!-- TESTIMONIAL 2 -->
        <div
          class="relative flex h-full flex-col rounded-[14px] border border-primary bg-black/75 px-6 py-7 md:px-7 lg:px-5 lg:py-5"
        >
          <!-- Quote -->
          <div
            class="absolute left-5 top-1 font-serif text-[110px] leading-none text-white/10"
          >
            “
          </div>

          <div class="relative z-10 flex h-full flex-col">
            <!-- Stars -->
            <div
              class="ml-[105px] flex gap-1 text-[24px] leading-none text-[#ffb800] lg:ml-[65px] lg:text-[18px]"
            >
              <span v-for="star in 5" :key="star">★</span>
            </div>

            <!-- Testimonial -->
            <p
              class="mt-5 ml-[105px] font-sans text-[17px] leading-[1.45] text-[#e4e4e4] lg:ml-[65px] lg:mt-4 lg:text-[14px]"
            >
              “Watching the tone being built by the man himself was fascinating.
              The IR Pack is a really nice bonus too!”
            </p>

            <!-- Divider -->
            <div
              class="ml-[105px] mt-6 h-[2px] w-[90px] bg-primary lg:ml-[30%] lg:mt-4 lg:w-[60px]"
            ></div>

            <!-- Profile / Author -->
            <div
              class="mt-auto flex items-center gap-4 pt-6 lg:gap-3 lg:pt-5 lg:ml-[20px]"
            >
              <!-- Profile image -->
              <div
                class="flex size-[82px] shrink-0 items-center justify-center overflow-hidden rounded-full border border-primary bg-black lg:size-[52px]"
              >
                <img
                  src="/Andrew J.webp"
                  alt="Andrew J."
                  class="h-full w-full object-cover"
                />
              </div>

              <!-- Name / Role / Band -->
              <div class="min-w-0">
                <h3
                  class="font-sans text-[18px] font-normal text-white lg:text-[13px]"
                >
                  Lewis R.
                </h3>

                <p
                  class="mt-1 font-sans text-[16px] text-primary lg:text-[12px]"
                >
                  Bassist
                </p>

                <p
                  class="mt-1 font-sans text-[15px] text-white/55 lg:text-[11px]"
                >
                  Symphony X
                </p>
              </div>
            </div>
          </div>
        </div>

        <!-- TESTIMONIAL 3 -->
        <div
          class="relative flex h-full flex-col rounded-[14px] border border-primary bg-black/75 px-6 py-7 md:px-7 lg:px-5 lg:py-5"
        >
          <!-- Quote -->
          <div
            class="absolute left-5 top-1 font-serif text-[110px] leading-none text-white/10"
          >
            “
          </div>

          <div class="relative z-10 flex h-full flex-col">
            <!-- Stars -->
            <div
              class="ml-[105px] flex gap-1 text-[24px] leading-none text-[#ffb800] lg:ml-[65px] lg:text-[18px]"
            >
              <span v-for="star in 5" :key="star">★</span>
            </div>

            <!-- Testimonial -->
            <p
              class="mt-5 ml-[105px] font-sans text-[17px] leading-[1.45] text-[#e4e4e4] lg:ml-[65px] lg:mt-4 lg:text-[14px]"
            >
              “I’ve seen a lot of Metallica documentaries and gear videos over
              the years, and this felt different. I thought I knew a lot about
              Cliff’s sound already, but there were quite a few things here I’d
              never heard before. Really enjoyed it.”
            </p>

            <!-- Divider -->
            <div
              class="ml-[105px] mt-6 h-[2px] w-[90px] bg-primary lg:ml-[30%] lg:mt-4 lg:w-[60px]"
            ></div>

            <!-- Profile / Author -->
            <div
              class="mt-auto flex items-center gap-4 pt-6 lg:gap-3 lg:pt-5 lg:ml-[20px]"
            >
              <!-- Profile image -->
              <div
                class="flex size-[82px] shrink-0 items-center justify-center overflow-hidden rounded-full border border-primary bg-black lg:size-[52px]"
              >
                <img
                  src="/Andrew J.webp"
                  alt="Andrew J."
                  class="h-full w-full object-cover"
                />
              </div>

              <!-- Name / Role / Band -->
              <div class="min-w-0">
                <h3
                  class="font-sans text-[18px] font-normal text-white lg:text-[13px]"
                >
                  Andrew J.
                </h3>

                <p
                  class="mt-1 font-sans text-[16px] text-primary lg:text-[12px]"
                >
                  Bassist
                </p>

                <p
                  class="mt-1 font-sans text-[15px] text-white/55 lg:text-[11px]"
                >
                  Symphony X
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>
