<template>
  <section class="relative overflow-hidden py-14 md:py-16 lg:py-20">
    <!-- TEXT -->
    <div class="relative z-10 px-4 text-center md:px-8 lg:px-9">
      <h2
        class="mx-auto max-w-[900px] font-russo text-[42px] font-normal leading-[0.98] tracking-[-1px] text-white md:text-[52px] lg:text-[64px]"
      >
        There’s always been
        <br />
        more to the story...
      </h2>

      <div
        class="mx-auto mt-7 max-w-[650px] font-sans text-[15px] leading-[1.45] text-[#d7d7d7] md:mt-8 md:text-[16px]"
      >
        <p>
          For decades, fans have analyzed every photograph,
          <br class="hidden md:block" />
          interview and every second of those records trying to
          <br class="hidden md:block" />
          understand Cliff’s sound.
        </p>

        <p class="mt-4">
          This class goes back to someone who was actually there.
          <br class="hidden md:block" />
          Not to retell the same stories, but to reveal all the details
          <br class="hidden md:block" />
          that are worth discovering.
        </p>
      </div>
    </div>

    <!-- IMAGE -->
    <div
      class="relative -mt-4 h-[620px] w-full md:-mt-20 md:h-[700px] lg:-mt-20 lg:h-[750px]"
    >
      <!-- TAPE REEL -->

      <picture>
        <source
          media="(max-width: 767px)"
          srcset="Tape-Sweet-Silence-Studios-Mobile.webp"
        />

        <img
          src="Tape Reel Sweet Silence Studios Desktop.webp"
          alt=""
          class="absolute left-0 top-[40px] z-0 w-[42%] max-w-none md:left-0 md:top-[50px] md:w-[38%] lg:left-0 lg:-top-[50px] lg:w-[28%]"
        />
      </picture>

      <!-- SIGNATURE -->

      <picture>
        <source
          media="(max-width: 767px)"
          srcset="Cliff-Burton-Signature-Mobile.webp"
        />

        <img
          src="Cliff Burton Signature Desktop.webp"
          alt=""
          class="absolute right-[-2%] top-[20px] z-10 w-[25%] max-w-none md:right-0 md:top-[25px] md:w-[28%] lg:right-[1%] lg:top-[20px] lg:w-[21%]"
        />
      </picture>

      <!-- STUDIO NOTES -->
      <picture>
        <source
          media="(max-width: 767px)"
          srcset="Studio-Notes-Sweet-Silence-Mobile.webp"
        />

        <img
          src="Studio Notes Sweet Silence Desktop.webp"
          alt=""
          class="absolute left-1/2 top-[100px] z-20 w-[92%] max-w-none -translate-x-1/2 md:top-[120px] md:w-[82%] lg:top-[130px] lg:w-[48%] lg:min-w-[800px]"
        />
      </picture>
    </div>
  </section>
</template>
