<script setup>
import { onMounted, computed } from 'vue';

const props = defineProps({
  video: {
    type: Object,
  },
});

onMounted(() => {
  const vimeoScript = document.createElement('script');
  vimeoScript.setAttribute('src', 'https://player.vimeo.com/api/player.js');
  document.head.appendChild(vimeoScript);
});

const reversedSiblings = computed(
  () => {
    return [...props.video.siblings].reverse();
  } // Create a new array and reverse it
);
</script>
<template>
  <div
    class="library-player-container max-w-[90%] mx-auto flex gap-24 items-start"
  >
    <!-- video -->
    <!-- <div style="width: 70%; height: auto; padding:56.25% 0 0 0;position:relative;"><iframe src="https://player.vimeo.com/video/1040725600?badge=0&amp;autopause=0&amp;player_id=0&amp;app_id=58479" frameborder="0" allow="autoplay; fullscreen; picture-in-picture; clipboard-write" style="position:absolute;top:0;left:0;width:100%;height:100%;" title="02. Us Against The Whole World"></iframe></div> -->
    <!--  -->

    <!-- videos layout -->
    <div class="mainVideo flex items-center w-fit">
      <a class="ml-24 my-10 flex flex-col w-fit p-2 rounded-lg" href="/videos">
        <!-- video -->
        <div
          style="
            width: 55vw;
            margin-bottom: 30px;
            padding: 56.25% 0 0 0;
            position: relative;
          "
          class="mainvidplay"
        >
          <iframe
            src="https://player.vimeo.com/video/1040725600?badge=0&amp;autopause=0&amp;player_id=0&amp;app_id=58479"
            frameborder="0"
            allow="autoplay; fullscreen; picture-in-picture; clipboard-write"
            class="rounded-md"
            style="
              position: absolute;
              top: 0;
              left: 0;
              width: 100%;
              height: 100%;
            "
            title="02. Us Against The Whole World"
          ></iframe>
        </div>
        <h3 class="mt-2 text-2xl font-medium text-secondary">
          {{ props.video.name }}
        </h3>
      </a>
      <!-- <p class="mx-auto">videoplayer</p> -->
    </div>
    <div class="videos-list responsive-videos w-[30%] flex items-end">
      <div class="mx-auto mt-10 flex flex-col gap-8">
        <!-- <p class="mx-auto">videos list</p> -->
        <a
          v-for="sibling in reversedSiblings"
          class="flex flex-col w-[90%] p-2 rounded-lg relative"
          :href="`/masterclass/videos/${sibling.item1}`"
        >
          <img
            src="/thumbnail.png"
            alt="Video Thumbnail"
            class="w-60 h-36 object-cover rounded-lg"
          />

          <svg
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke-width="1.5"
            stroke="currentColor"
            class="size-12 absolute top-[35%] left-[33%] rounded-full p-3 fill-white bg-[rgb(82_81_81/90%)]"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M5.25 5.653c0-.856.917-1.398 1.667-.986l11.54 6.347a1.125 1.125 0 0 1 0 1.972l-11.54 6.347a1.125 1.125 0 0 1-1.667-.986V5.653Z"
            />
          </svg>
          <h3 class="mt-2 text-lg font-medium text-secondary">
            {{ sibling.item2 }}
          </h3>
        </a>
      </div>
    </div>
    <!--  -->
  </div>
</template>

<style scoped>
@media screen and (max-width: 860px) {
  .library-player-container {
    flex-direction: column;
    gap: 20px;
  }

  .library-player-container .mainVideo {
    width: 100%;
    height: auto;
  }

  .library-player-container .mainVideo a {
    margin: 0px;
    margin-left: auto;
    margin-right: auto;
  }

  .videos-list {
    width: 100%;
    height: auto;
    margin-left: 0px !important;
    margin-right: 0px !important;
  }

  .videos-list:first-child {
    margin: 0px !important;
  }

  .responsive-videos {
    width: 100%; /* Default width for small screens */
    display: flex;
    justify-content: flex-start;
  }
}

@media (max-width: 768px) {
  .responsive-videos {
    width: 30%; /* Adjust for larger screens */
  }

  .responsive-videos {
    width: 100%; /* Default width for small screens */
    display: flex;
    justify-content: flex-start;
  }

  .mainvidplay {
    width: unset !important;
  }

  .videos-list:first-child {
    margin-left: 0px !important;
    margin-left: 0px !important;
  }

  .videos-list {
    width: 100%;
    height: auto;
    margin-left: 0px !important;
    margin-right: 0px !important;
  }
}
</style>
<style scoped></style>
