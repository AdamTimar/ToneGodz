<template>
  <div class="flex justify-between nav-container items-center px-10 py-6">
    <div class="w-1/4 flex justify-items-start">
      <a href="/">
        <img src="/logo.svg" alt="Logo" class="logo w-48" />
      </a>
    </div>
    <nav
      :class="{
        hidden: !page.props.auth || !page.props.auth.hasAccess,
      }"
      class="w-3/5 flex justify-center gap-16 flex-grow text-xl tracking-wide"
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
        href="/irpack-drum-sample"
        :class="{
          '!border-hoverPrimary border-b-2':
            currentPath === '/irpack-drum-sample',
        }"
        class="text-secondary hover:text-hoverPrimary border-b-2 border-transparent px-4"
      >
        IR Pack & Drum Sample
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
      <a
        href="/webinars"
        :class="{
          '!border-hoverPrimary border-b-2': currentPath === '/webinars',
        }"
        class="text-secondary hover:text-hoverPrimary border-b-2 border-transparent px-4"
      >
        Webinars
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
      <label
        for="hamburger"
        class="hamburger-icon cursor-pointer relative bottom-3"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="30"
          height="30"
          viewBox="0 0 30 30"
          class="hamburger-svg absolute right-2 center"
        >
          <path fill="#FFFFFF" d="M5 7h20v4H5zM5 13h20v4H5zM5 19h20v4H5z" />
        </svg>
      </label>
      <nav class="menu">
        <a
          href="/"
          class="text-secondary hover:text-hoverPrimary px-4"
          :class="{
            hidden: !page.props.auth || !page.props.auth.hasAccess,
          }"
        >
          Home
        </a>
        <a
          href="/irpack-drum-sample"
          class="text-secondary hover:text-hoverPrimary px-4"
          :class="{
            hidden: !page.props.auth || !page.props.auth.hasAccess,
          }"
        >
          About Us
        </a>
        <a
          href="/masterclass"
          class="text-secondary hover:text-hoverPrimary border-transparent px-4"
          :class="{
            hidden: !page.props.auth || !page.props.auth.hasAccess,
          }"
        >
          Masterclass
        </a>
        <a
          href="/webinars"
          class="text-secondary hover:text-hoverPrimary border-transparent px-4"
          :class="{
            hidden: !page.props.auth || !page.props.auth.hasAccess,
          }"
        >
          Webinars
        </a>
        <PrimaryButton
          v-if="!page.props.auth"
          @click="redirectToLogin()"
          class="navigation-button w-full"
        >
          Log in
        </PrimaryButton>

        <div v-else class="navigation-button max-w-96 break-all">
          {{ page.props.auth.email || !page.props.auth.hasAccess }}
        </div>

        <PrimaryButton
          v-if="!page.props.auth"
          @click="redirectToRegister()"
          class="navigation-button w-full"
        >
          Register
        </PrimaryButton>
        <PrimaryButton
          v-else
          @click="logout()"
          class="navigation-button w-full"
        >
          Logout
        </PrimaryButton>
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

onMounted(() => {
  //console.log(page.props.auth);
});

function navigateAndScroll() {
  // Step 1: Redirect to a new page (e.g., "/page2.html")
  window.location.href = '/?scrollToAboutUs=true';
}

const redirectToLogin = () => {
  router.visit('/account/login', {
    onFinish: () => {
      window.location.reload();
    },
  });
};

const redirectToRegister = () => {
  router.visit('/account/register', {
    onFinish: () => {
      window.location.reload();
    },
  });
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

  .menu a {
    color: white !important;
  }

  .menu:first-child {
    border-bottom-width: 0px;
  }

  .navigation-button {
    width: fit-content;
    margin-top: 10px;
    margin-left: 15px;
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
  padding-top: 100px;
  flex-direction: column;
  position: fixed; /* Fixed positioning */
  top: 0; /* Align with top */
  right: 0; /* Start from the right */
  /* background-color: white;  */
  background-color: #232323;
  height: 100%; /* Full height */
  width: 40%; /* Width of the menu */
  max-width: 250px;
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

#hamburger:checked + .hamburger-icon .hamburger-svg {
  position: fixed;
  right: 3rem;
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
