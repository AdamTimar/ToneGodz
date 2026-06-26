19:08
<template>
  <div>
    <ToneGodzEQFSection />
    <div class="backdrop-blur-xl bg-slate-900/30 flex flex-col gap-20">
      <TheSilentHero />
      <WhyIsItSoSpecial />
      <TheWeaponOfChoice />
      <HearItInAction />
      <Testimonials />
    </div>
  </div>
</template>

<script setup>
import HearItInAction from '@/components/PluginPageComponents/HearItInAction.vue';
import Testimonials from '@/components/PluginPageComponents/Testimonials.vue';
import TheSilentHero from '@/components/PluginPageComponents/TheSilentHero.vue';
import TheWeaponOfChoice from '@/components/PluginPageComponents/TheWeaponOfChoice.vue';
import ToneGodzEQFSection from '@/components/PluginPageComponents/ToneGodzEQFSection.vue';
import WhyIsItSoSpecial from '@/components/PluginPageComponents/WhyIsItSoSpecial.vue';
</script>
<style scoped>
@media screen and (max-width: 1080px) {
  .background-image {
    background-image: url('tonegodz-eqf2-aphex-eqf2-plugin.webp');
    background-repeat: no-repeat;
    /* background-size: 1000px !important; */
    max-width: 100%;
    /* min-height: 45rem; */
    /* padding: 3rem 1rem; */
    /*align-items: center;*/
  }
}
</style>
