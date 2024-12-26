<template>
  <div class="flex justify-between nav-container items-center px-10 py-6">
    <div class="w-1/4 flex justify-items-start">
      <img src="/logo.svg" alt="Logo" class="logo w-48" />
    </div>
    <nav
      class="w-2/4 flex justify-center gap-16 flex-grow text-2xl tracking-wide"
    >
      <a
        href="/"
        :class="{
          '!border-hoverPrimary border-b-2': currentPath === '/',
        }"
        class="text-secondary hover:text-hoverPrimary border-b-2 border-transparent px-4"
      >
        Home
      </a>
      <a
        href="/#achieveYourVision"
        :class="{
          '!border-hoverPrimary border-b-2': currentPath === '/about-us',
        }"
        class="text-secondary hover:text-hoverPrimary border-b-2 border-transparent px-4"
        @click.prevent="navigateAndScroll()"
      >
        About Us
      </a>
      <a
        href="/masterclass"
        :class="{
          '!border-hoverPrimary border-b-2': currentPath === '/masterclass',
        }"
        class="text-secondary hover:text-hoverPrimary border-b-2 border-transparent px-4"
      >
        Masterclass
      </a>
    </nav>

    <!-- Add more links as needed -->

    <div class="w-1/4 flex justify-end gap-4 text-xl">
      <PrimaryButton
        v-if="!page.props.auth"
        @click="redirectToLogin()"
        class="h-full w-24 bg-transparent border border-secondary hover:border-hoverPrimary hover:bg-hoverPrimary"
      >
        Log in
      </PrimaryButton>

      <div
        v-else
        class="font-ubuntu text-secondary font-bold py-1 px-4 rounded-lg transition duration-300 min-w-fit"
      >
        {{ page.props.auth.email }}
      </div>

      <PrimaryButton
        v-if="!page.props.auth"
        @click="redirectToRegister()"
        class="h-full w-24"
      >
        Register
      </PrimaryButton>
      <PrimaryButton
        v-else
        @click="logout()"
        class="h-full w-24 bg-transparent border border-secondary hover:border-hoverPrimary hover:bg-hoverPrimary"
      >
        Logout
      </PrimaryButton>
    </div>
    <!-- Hamburger Menu for mobile -->
    <div class="hamburger-container hidden">
      <input type="checkbox" id="hamburger" class="hidden" />
      <label for="hamburger" class="hamburger-icon cursor-pointer relative">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="30"
          height="30"
          viewBox="0 0 30 30"
          class="hamburger-svg"
        >
          <path fill="#FFFFFF" d="M5 7h20v4H5zM5 13h20v4H5zM5 19h20v4H5z" />
        </svg>
      </label>
      <nav class="menu">
        <a
          href="/#aboutus"
          :class="{ 'border-hoverPrimary border-b-2': currentPath === '/' }"
          class="text-secondary hover:text-hoverPrimary border-b-2 px-4"
        >
          AboutUs
        </a>
        <a
          href="/#purchase"
          :class="{ 'border-hoverPrimary border-b-2': currentPath === '/' }"
          class="text-secondary hover:text-hoverPrimary border-b-2 border-transparent px-4"
        >
          Purchase
        </a>
        <a
          href="/#contact"
          :class="{ 'border-hoverPrimary border-b-2': currentPath === '/' }"
          class="text-secondary hover:text-hoverPrimary border-b-2 border-transparent px-4"
        >
          Contact
        </a>
        <PrimaryButton class="w-full">Log in</PrimaryButton>
        <PrimaryButton class="w-full">Register</PrimaryButton>
      </nav>
    </div>
  </div>
</template>

<script setup>
import PrimaryButton from '@/components/PrimaryButton.vue';
import { router, usePage } from '@inertiajs/vue3';
import { computed, onMounted } from 'vue';
import axios from 'axios';

const page = usePage();

const currentPath = computed(() => {
  return window.location.pathname;
});

function navigateAndScroll() {
  // Step 1: Redirect to a new page (e.g., "/page2.html")
  window.location.href = '/?scrollToAboutUs=true';
}

const redirectToLogin = () => {
  router.visit('/account/login');
};

const redirectToRegister = () => {
  router.visit('/account/register');
};

const logout = () => {
  axios
    .post('/account/logout')
    .then((response) => {
      router.visit('/');
    })
    .catch((error) => {
      // Handle error
    });
};

const scrollToSection = (sectionId) => {
  const element = document.getElementById(sectionId);
  console.log(element);
  if (element) {
    element.scrollIntoView({ behavior: 'smooth' });
  }
};
</script>

<style scoped>
@media screen and (max-width: 1360px) {
  .nav-container > :nth-child(1) {
    width: 30%;
  }
  .nav-container > :nth-child(2),
  .nav-container > :nth-child(3) {
    display: none;
  }
  .hamburger-container {
    display: block;
  }
}

.hamburger-container {
  position: relative; /* Ensure relative positioning for z-index */
  z-index: 10; /* Higher z-index for the hamburger */
}

.hamburger-icon {
  z-index: 15; /* Ensure the icon is above other elements */
}

.menu {
  display: flex;
  flex-direction: column;
  position: fixed; /* Fixed positioning */
  top: 0; /* Align with top */
  right: 0; /* Start from the right */
  background-color: white; /* Background color for menu */
  height: 100%; /* Full height */
  width: 40%; /* Width of the menu */
  transition: transform 0.3s ease; /* Smooth transition for transform */
  transform: translateX(100%); /* Start off-screen */
  overflow-y: auto; /* Enable vertical scrolling */
  z-index: 5; /* Lower z-index than hamburger */
}

#hamburger:checked + .hamburger-icon + .menu {
  transform: translateX(0); /* Slide in when checked */
}

.hamburger-svg {
  transition: fill 0.3s ease; /* Smooth transition for color change */
}

#hamburger:checked + .hamburger-icon .hamburger-svg path {
  fill: black; /* Change to black when checked */
}

.menu a {
  padding: 15px;
  text-decoration: none;
  color: #232323;
  transition: color 0.3s ease;
}

.menu a:hover {
  color: tomato; /* Color on hover */
}
</style>
