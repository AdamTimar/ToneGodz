<template>
  <div
    class="backstage-pass-section background-image w-full flex justify-center mt-20"
  >
    <div class="text-container p-8 mx-20 flex rounded-md">
      <div class="textsection w-[45%]">
        <p class="text-center text-6xl font-bold mb-4 m-auto text-primary">
          IR Pack & Drum Samples
        </p>
        <p class="thebundle text-center text-4xl font-bold mb-8 mt-12 m-auto">
          The Bundle now comes with studio-grade impulse responses and crushing
          drum samples.
        </p>
        <div class="content flex flex-row gap-1 justify-between mt-18">
          <div class="content-first-element flex flex-col gap-9 m-auto">
            <p
              class="become-the-master text-left text-3xl text-primary mb-4 m-auto"
            >
              The ToneGodz IR Pack
              <span class="text-xl text-secondary">
                - 30 meticulously crafted impulse responses for guitar and bass.
                Featuring both raw and processed IRs, which have been perfected
                with the legendary Trident A-Range and in some cases Neve
                consoles.
              </span>
            </p>

            <p
              class="become-the-master text-left text-3xl text-primary mb-4 m-auto"
            >
              -...The Justice Drums Sample Pack
              <span class="text-xl text-secondary">
                -Captured by Flemming Rasmussen himself, these drum samples
                deliver probably the heaviest, most iconic kick drum sound ever
                - raw, punchy, and undeniable. Includes .wav and TCI files for
                Slate Trigger.
              </span>
            </p>
          </div>
        </div>
      </div>
      <div
        class="flex flex-col image-container justify-items-center items-center w-[55%]"
      >
        <img src="IRSamples.webp" alt="Pass" width="480" />
        <div v-for="(file, index) in files" :key="index" class="mt-4">
          <div class="ml-6 mb-2 font-semibold">
            {{ file.name }}
          </div>
          <audio controls>
            <source :src="file.url" type="audio/mpeg" />
            Your browser does not support the audio element.
          </audio>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import LargeButton from '@/components/LargeButton.vue';
import { onMounted } from 'vue';
import { AVBars, AVWaveform } from 'vue-audio-visual';
import { ref, onBeforeUnmount } from 'vue';

const waveform = ref(null);
let wavesurfer = null;
const isPlaying = ref(false);

const files = ref([]);

onMounted(() => {
  // Load audio files
  const audioFiles = [
    'AJFA Bass.mp3',
    'AJFA Drum Sample.mp3',
    'AJFA Heavy Gtr.mp3',
    'JC Clean.mp3',
    'MOP Heavy Gtr.mp3',
    'RTL Heavy Gtr.mp3',
    'RTL MOP Bass.mp3',
  ];

  audioFiles.forEach((file, index) => {
    files.value.push({
      name: `${file.substring(0, file.lastIndexOf('.'))}`,
      url: window.location.origin + '/' + file,
      isPlaying: false,
      wavesurfer: null,
    });
  });
});

// Setup WaveSurfer instance for each file
function setupWaveform(file, index) {
  const waveformRef = `waveform-${index}`;
  const wavesurfer = WaveSurfer.create({
    container: `.${waveformRef}`,
    waveColor: '#ccc',
    progressColor: '#007BFF',
    height: 100,
    responsive: true,
  });

  wavesurfer.load(URL.createObjectURL(file));

  wavesurfer.on('finish', () => {
    file.isPlaying = false;
  });

  file.wavesurfer = wavesurfer;
  file.isPlaying = false;
}

function togglePlay(index) {
  const file = files.value[index];
  const wavesurfer = file.wavesurfer;
  wavesurfer.playPause();
  file.isPlaying = wavesurfer.isPlaying();
}

onBeforeUnmount(() => {
  // Cleanup wavesurfer instances when the component is destroyed
  files.value.forEach((file) => file.wavesurfer?.destroy());
});

const scrollToSection = (sectionId) => {
  const element = document.getElementById(sectionId);
  if (element) {
    element.scrollIntoView({ behavior: 'smooth' });
  }
};

const redirectToPurchase = () => {
  window.location.href = '/purchase';
};
</script>

<style scoped>
@media screen and (max-width: 860px) {
  .image-container {
    width: 100%;
    margin: 0 auto;
    padding: 0 !important;
  }

  .thebundle {
    font-size: 2rem !important;
  }

  .textsection {
    width: 100%;
    margin: 0 auto;
    padding: 0 !important;
  }

  .text-container {
    width: 100%;
    margin: 0 auto;
    flex-direction: column;
    align-items: center;
  }

  .backstage-pass-section {
    /* background-image: url('src/assets/backstagePass.svg'); */
    /* background-repeat: no-repeat; */
    /* background-size: cover; */
    max-width: 100%;
    display: block !important;
    /* min-height: 365px; */
    /* padding: 3rem 1rem; */
    align-items: center;
    font-size: 1rem;
    margin-top: 2rem !important;
  }
  .backstage-pass-section .text-container {
    width: 100%;
    /* padding: 1rem; */
  }
  .backstage-pass-section .text-container .content {
    display: block;
    width: 100%;
    align-items: center;
  }

  .content-first-element {
    max-width: 100% !important;
    display: block !important;
    text-align: center;
  }

  .backstage-pass-section .text-container .become-the-master {
    font-size: 1.5rem;
    text-align: center;
    width: 100%;
  }

  .backstage-pass-section .text-container p {
    font-size: 2.5rem;
    width: 100%;
    text-align: center;
  }

  .backstage-pass-section .image-container {
    max-width: 100%;
    padding: 1rem;
  }

  .backstage-pass-section .image-container img {
    width: 100%;
  }

  .backstage-pass-section .text-container .elements {
    font-size: 1.5rem;
    margin: 1.5rem 0;
    text-align: left;
    width: 100%;
  }

  .lets-see-button {
    width: 70% !important;
    padding: 0.8rem 1rem;
  }

  .text-container {
    padding: 0 2rem !important;
  }
}
</style>
