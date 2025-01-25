<template>
  <!-- <h1>Home</h1>
        <p>Welcome to the Home page</p> -->
  <div class="font-russo">
    <TitleSection />
    <BackstagePassSection />
    <AlwaysLookingForTheToneSection />
    <AboutFlemmingSection />
    <AchieveYourVisionSection />
    <!-- <LimitedTimeOfferSection /> -->
    <ExclusiveBundleSection />
    <FAQSection />
  </div>
</template>

<script setup>
const params = new URLSearchParams(window.location.search);

onMounted(() => {
  if (params.get('scrollToAboutUs') === 'true') {
    const targetElement = document.getElementById('achieveYourVision');
    if (targetElement) {
      // If the target element exists, scroll to it
      targetElement.scrollIntoView({ behavior: 'smooth' });
    } else {
      // If the target section is not found, scroll to a fallback section
      const fallbackElement = document.getElementById('fallbackSection');
      if (fallbackElement) {
        fallbackElement.scrollIntoView({ behavior: 'smooth' });
      }
    }
  }
});

import TitleSection from '@/components/HomePageComponents/TitleSection.vue';
import BackstagePassSection from '@/components/HomePageComponents/BackstagePassSection.vue';
import AlwaysLookingForTheToneSection from '@/components/HomePageComponents/AlwaysLookingForTheToneSection.vue';
import AboutFlemmingSection from '@/components/HomePageComponents/AboutFlemmingSection.vue';
import AchieveYourVisionSection from '@/components/HomePageComponents/AchieveYourVisionSection.vue';
import LimitedTimeOfferSection from '@/components/HomePageComponents/LimitedTimeOfferSection.vue';
import ExclusiveBundleSection from '@/components/HomePageComponents/ExclusiveBundleSection.vue';
import FAQSection from '@/components/HomePageComponents/FAQSection.vue';
import { onMounted } from 'vue';
</script>
