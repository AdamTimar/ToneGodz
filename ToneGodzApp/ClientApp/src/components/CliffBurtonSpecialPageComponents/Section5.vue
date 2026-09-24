<template>
  <section class="relative overflow-hidden text-white">
    <div
      class="mx-auto grid w-[calc(100%-32px)] max-w-[1400px] gap-8 md:w-[calc(100%-64px)] lg:grid-cols-2 lg:gap-8 lg:px-0"
    >
      <!-- ========================================= -->
      <!-- HEAR THE TONE -->
      <!-- ========================================= -->

      <div class="flex flex-col">
        <!-- TITLE -->
        <div class="text-center">
          <h2
            class="font-russo text-[42px] font-normal leading-[0.95] tracking-[-1px] md:text-[52px] lg:text-[54px]"
          >
            Hear the Tone
          </h2>

          <p
            class="mx-auto mt-4 max-w-[620px] font-sans text-[15px] leading-[1.4] text-[#d7d7d7] md:text-[16px]"
          >
            The Cliff Burton Special now comes with a Bonus IR Pack. Explore the
            sound and use these IRs to shape your own tone, add character, and
            make it unmistakably yours.
          </p>
        </div>

        <!-- AUDIO PLAYERS -->
        <div class="mt-24 space-y-2">
          <!-- AUDIO 1 -->
          <div
            v-for="(track, index) in tracks"
            :key="track.url"
            class="flex min-h-[78px] items-center gap-5 rounded-[9px] border border-primary px-4 py-3 md:px-5"
          >
            <img
              src="/1.Playhead.svg"
              alt="Play"
              class="size-[54px] shrink-0 cursor-pointer"
              role="button"
              tabindex="0"
              @click="togglePlay(index)"
            />

            <div class="min-w-0 flex-1">
              <div class="mb-1 text-center font-sans text-[13px] text-white">
                {{ track.title }}
              </div>

              <div class="flex h-8 items-center justify-center">
                <div
                  :ref="(el) => (waveformRefs[index] = el)"
                  class="w-full"
                ></div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- ========================================= -->
      <!-- BONUS IR PACK -->
      <!-- ========================================= -->

      <div
        class="rounded-[9px] border border-primary px-5 py-8 md:px-8 lg:px-10 lg:py-8"
      >
        <!-- TITLE -->
        <div class="text-center">
          <h2
            class="font-russo text-[40px] font-normal leading-[0.9] tracking-[-1px] md:text-[50px] lg:text-[52px]"
          >
            Bonus IR Pack
            <br />
            Included
          </h2>

          <p
            class="mx-auto mt-4 max-w-[500px] font-sans text-[15px] leading-[1.4] text-[#d7d7d7] md:text-[16px]"
          >
            Get the exact cabinet impulse responses used and inspired by Cliff’s
            iconic tone.
          </p>
        </div>

        <!-- PRODUCT + FEATURES -->
        <div
          class="mt-7 grid items-center gap-7 md:grid-cols-[0.9fr_1.1fr] lg:grid-cols-[0.85fr_1.15fr]"
        >
          <!-- PRODUCT IMAGE PLACEHOLDER -->
          <picture>
            <source
              media="(max-width: 767px)"
              srcset="Box-Mockup-Cliff-Burton-Special-Mobile.webp"
            />
            <img
              src="Box Mockup Cliff Burton Special Desktop.webp"
              alt=""
              class="w-full"
            />
          </picture>

          <!-- DESKTOP -->

          <!-- FEATURES -->
          <div class="space-y-7">
            <!-- FEATURE 1 -->
            <div class="flex items-start gap-4">
              <div
                class="flex size-[54px] shrink-0 items-center justify-center"
              >
                <img src="cab.svg" alt="" class="size-[54px] shrink-0" />
              </div>

              <div>
                <h3
                  class="font-sans text-[20px] font-normal leading-tight text-white"
                >
                  Premium bass cabs
                </h3>
                <p
                  class="mt-1 font-sans text-[15px] leading-[1.35] text-[#d7d7d7]"
                >
                  Carefully captured authentic equipment.
                </p>
              </div>
            </div>

            <!-- FEATURE 2 -->
            <div class="flex items-start gap-4">
              <div
                class="flex size-[54px] shrink-0 items-center justify-center"
              >
                <img src="download.svg" alt="" class="size-[54px] shrink-0" />
              </div>

              <div>
                <h3
                  class="font-sans text-[20px] font-normal leading-tight text-white"
                >
                  Instant download
                </h3>
                <p
                  class="mt-1 font-sans text-[15px] leading-[1.35] text-[#d7d7d7]"
                >
                  Get the complete pack immediately and start using and abusing
                  it.
                </p>
              </div>
            </div>

            <!-- FEATURE 3 -->
            <div class="flex items-start gap-4">
              <div
                class="flex size-[54px] shrink-0 items-center justify-center"
              >
                <img src="wav.svg" alt="" class="size-[54px] shrink-0" />
              </div>

              <div>
                <h3
                  class="font-sans text-[20px] font-normal leading-tight text-white"
                >
                  Universal compatibility
                </h3>
                <p
                  class="mt-1 font-sans text-[15px] leading-[1.35] text-[#d7d7d7]"
                >
                  WAV files that work with virtually any IR Loader and hardware.
                </p>
              </div>
            </div>

            <!-- FEATURE 4 -->
            <div class="flex items-start gap-4">
              <div
                class="flex size-[54px] shrink-0 items-center justify-center"
              >
                <img src="mic.svg" alt="" class="size-[54px] shrink-0" />
              </div>

              <div>
                <h3
                  class="font-sans text-[20px] font-normal leading-tight text-white"
                >
                  Add your own flavor
                </h3>
                <p
                  class="mt-1 font-sans text-[15px] leading-[1.35] text-[#d7d7d7]"
                >
                  Individual mic IRs let you blend the captures yourself and
                  shape the tone your way.
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
import { ref, onMounted, onBeforeUnmount } from 'vue';
import WaveSurfer from 'wavesurfer.js';

const tracks = [
  {
    title: 'Ktulu',
    url: '/Ktulu.mp3',
  },
  {
    title: 'Orion Rhythm and Lead',
    url: '/Orion Rhythm and Lead.mp3',
  },
  {
    title: 'Battery',
    url: '/Battery.mp3',
  },
];

const waveformRefs = ref([]);
const wavesurfers = [];

onMounted(() => {
  tracks.forEach((track, index) => {
    const wavesurfer = WaveSurfer.create({
      container: waveformRefs.value[index],
      url: track.url,

      height: 32,
      waveColor: '#ffffff',
      progressColor: '#ff641e',

      barWidth: 2,
      barGap: 3,
      barRadius: 2,

      cursorWidth: 0,
      normalize: true,
    });

    wavesurfers.push(wavesurfer);
  });
});

onBeforeUnmount(() => {
  wavesurfers.forEach((wavesurfer) => {
    wavesurfer.destroy();
  });
});

function togglePlay(index) {
  wavesurfers[index]?.playPause();
}
</script>
