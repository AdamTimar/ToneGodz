<script setup>
import { onMounted, computed } from 'vue';
const title = 'About Flemming: The Journey';
const imagePath = '@/assets/AboutFlemming.jpg';
import { router } from '@inertiajs/vue3';
const description =
  'Learn about Flemming Rasmussen and his journey to becoming a world-renowned producer.';

const props = defineProps({
  items: {
    type: Array,
  },
  folderName: {
    type: String,
  },
});

const reversedItems = computed(
  () => {
    return [...props.items].reverse();
  } // Create a new array and reverse it
);

const currentId = computed(() => {
  const pathName = window.location.pathname;
  const splittedPath = pathName.split('/');
  return splittedPath[splittedPath.length - 1];
});

const back = () => {
  const backFolderId = new URLSearchParams(window.location.search).get(
    'backFolderId'
  );
  if (backFolderId !== null) {
    router.visit(`/masterclass/subfolders/${backFolderId}`);
  } else {
    router.visit('/masterclass');
  }
};
</script>

<template>
  <!-- Video library -->
  <div class="flex w-[90%] mx-auto text-2xl lg:px-12 items-center gap-3 my-8">
    <svg
      xmlns="http://www.w3.org/2000/svg"
      fill="none"
      viewBox="0 0 24 24"
      stroke-width="1.5"
      stroke="currentColor"
      class="size-6 cursor-pointer"
      @click="back()"
    >
      <path
        stroke-linecap="round"
        stroke-linejoin="round"
        d="m18.75 4.5-7.5 7.5 7.5 7.5m-6-15L5.25 12l7.5 7.5"
      />
    </svg>

    <p>{{ folderName }}</p>
  </div>
  <div
    class="video-library w-[90%] mx-auto grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 gap-8 lg:p-12"
  >
    <!-- video card item -->
    <a
      v-for="item in reversedItems"
      class="flex flex-col w-fit bg-[rgb(82_81_81/50%)] p-2 rounded-lg shadow"
      :href="
        item.type !== 'video'
          ? `/masterclass/subfolders/${item.itemId}?backFolderId=${currentId}`
          : `/masterclass/videos/${item.itemId}?backFolderId=${currentId}`
      "
    >
      <div class="relative">
        <img
          :src="item.type === 'video' ? item.thumbnail : '/thumbnail.png'"
          alt="Video Thumbnail"
          class="w-96 object-cover rounded-lg mx-auto"
        />
        <svg
          v-if="item.type === 'video'"
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          stroke-width="1.5"
          stroke="currentColor"
          class="size-12 absolute top-[50%] left-[50%] -translate-x-1/2 -translate-y-1/2 rounded-full p-3 fill-white bg-[rgb(82_81_81/90%)]"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            d="M5.25 5.653c0-.856.917-1.398 1.667-.986l11.54 6.347a1.125 1.125 0 0 1 0 1.972l-11.54 6.347a1.125 1.125 0 0 1-1.667-.986V5.653Z"
          />
        </svg>

        <svg
          v-else
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          stroke-width="1.5"
          stroke="currentColor"
          class="size-12 absolute top-[50%] left-[50%] -translate-x-1/2 -translate-y-1/2 rounded-full p-3 fill-white bg-[rgb(82_81_81/90%)]"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            d="M2.25 12.75V12A2.25 2.25 0 0 1 4.5 9.75h15A2.25 2.25 0 0 1 21.75 12v.75m-8.69-6.44-2.12-2.12a1.5 1.5 0 0 0-1.061-.44H4.5A2.25 2.25 0 0 0 2.25 6v12a2.25 2.25 0 0 0 2.25 2.25h15A2.25 2.25 0 0 0 21.75 18V9a2.25 2.25 0 0 0-2.25-2.25h-5.379a1.5 1.5 0 0 1-1.06-.44Z"
          />
        </svg>
      </div>
      <h3 class="mt-4 text-lg font-medium text-secondary">
        {{ item.itemName }}
      </h3>
    </a>
    <!--  -->
  </div>
</template>
<style scoped></style>
