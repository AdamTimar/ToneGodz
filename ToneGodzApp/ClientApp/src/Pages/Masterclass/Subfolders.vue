<script setup>
import { onMounted, computed } from 'vue';
const title = 'About Flemming: The Journey';
const imagePath = '@/assets/AboutFlemming.jpg';
const description =
  'Learn about Flemming Rasmussen and his journey to becoming a world-renowned producer.';

const props = defineProps({
  items: {
    type: Array,
  },
});

const reversedItems = computed(
  () => {
    return [...props.items].reverse();
  } // Create a new array and reverse it
);

onMounted(() => {
  console.log(props.items[0].item3);
});

const location = computed(() => {
  return window.location;
});
</script>

<template>
  <!-- Video library -->
  <div
    class="video-library w-[90%] mx-auto grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 gap-8 lg:p-12"
  >
    <!-- video card item -->
    <a
      v-for="item in reversedItems"
      class="flex flex-col w-fit bg-[rgb(82_81_81/50%)] p-2 rounded-lg shadow relative"
      :href="
        item.item3 !== 'video'
          ? `/masterclass/subfolders/${item.item1}`
          : `/masterclass/videos/${item.item1}`
      "
    >
      <img
        :src="'/thumbnail.png'"
        alt="Video Thumbnail"
        class="w-96 object-cover rounded-lg mx-auto"
      />
      <svg
        v-if="item.item3 === 'video'"
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        stroke-width="1.5"
        stroke="currentColor"
        class="size-12 absolute top-[35%] left-[40%] rounded-full p-3 fill-white bg-[rgb(82_81_81/90%)]"
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
        class="size-12 absolute top-[35%] left-[40%] rounded-full p-3 fill-white bg-[rgb(82_81_81/90%)]"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          d="M2.25 12.75V12A2.25 2.25 0 0 1 4.5 9.75h15A2.25 2.25 0 0 1 21.75 12v.75m-8.69-6.44-2.12-2.12a1.5 1.5 0 0 0-1.061-.44H4.5A2.25 2.25 0 0 0 2.25 6v12a2.25 2.25 0 0 0 2.25 2.25h15A2.25 2.25 0 0 0 21.75 18V9a2.25 2.25 0 0 0-2.25-2.25h-5.379a1.5 1.5 0 0 1-1.06-.44Z"
        />
      </svg>

      <h3 class="mt-4 text-lg font-medium text-secondary">
        {{ item.item2 }}
      </h3>
    </a>
    <!--  -->
  </div>
</template>
<style scoped></style>
