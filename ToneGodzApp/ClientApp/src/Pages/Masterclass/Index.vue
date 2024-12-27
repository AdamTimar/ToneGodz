<script setup>
import { onMounted, computed } from 'vue';
const title = 'About Flemming: The Journey';
const imagePath = '@/assets/AboutFlemming.jpg';
const description =
  'Learn about Flemming Rasmussen and his journey to becoming a world-renowned producer.';

const props = defineProps({
  folders: {
    type: Array,
  },
});

onMounted(() => {
  console.log(props.folders);
});

const reversedItems = computed(
  () => {
    return [...props.folders].reverse();
  } // Create a new array and reverse it
);
</script>

<template>
  <!-- Video library -->
  <p class="w-[90%] mx-auto text-2xl lg:px-12 my-8">Masterclass</p>
  <div
    class="video-library w-[90%] mx-auto grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 gap-8 lg:p-12"
  >
    <!-- video card item -->
    <a
      v-for="folder in reversedItems"
      class="flex flex-col w-fit bg-[rgb(82_81_81/50%)] p-2 rounded-lg shadow"
      :href="`/masterclass/subfolders/${folder.id}`"
    >
      <div class="relative">
        <img
          :src="'/thumbnail.png'"
          alt="Video Thumbnail"
          class="w-96 object-cover rounded-lg mx-auto"
        />
        <svg
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
        {{ folder.name }}
      </h3>
    </a>
    <!--  -->
  </div>
</template>
<style scoped></style>
