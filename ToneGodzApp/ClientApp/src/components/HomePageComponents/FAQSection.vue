<template>
    <div class="backstage-pass-section background-image w-full flex justify-center mt-20">
        <div class="text-container rounded-md">
            <p class="text-center text-primary text-5xl font-bold mb-4 w-[60%] m-auto">
                FAQ
            </p>
            <div class="questions-container flex flex-col gap-12 px-28">
                <div class="question flex flex-col gap-6 max-w-[90%]">
                <p class="question-title text-left text-2xl text-secondary font-extrabold">
                    Why buy it now?                </p>
                <p class="question-answer pl-24 text-left text-xl text-neutral-500 font-bolder">
                    During the Pre-Order Period you can get access to the full Masterclass with a 20% discount, but not only that. You also gain access to an exclusive, live webinar with Flemming Rasmussen.                </p>
                </div>
                <div class="question flex flex-col gap-6 max-w-[90%]">
                <p class="question-title text-left text-xl text-secondary font-extrabold">
                    How can I access the webinar?               </p>
                <p class="question-answer pl-24 text-left text-xl text-neutral-500 font-bolder">
                    You will receive an invitation via email, so make sure to enter your email address correctly.               </p>
                </div>
                <div class="question flex flex-col gap-6 max-w-[90%]">
                <p class="question-title text-left text-xl text-secondary font-extrabold">
                    Will I have lifetime access to the masterclass?                </p>
                <p class="question-answer pl-24 text-left text-xl text-neutral-500 font-bolder">
                    Yes! Once you purchase the Masterclass, you will have lifetime access to the content, allowing you to watch it anytime and at your own pace             </p>
                </div>
            </div>
            
        </div>
    </div>
</template>
  
<script setup>
import LargeButton from "@/components/LargeButton.vue";
</script>
  
<style scoped>


@media screen and (max-width: 860px) {
   .questions-container {
       width: 100%;
       padding: 2rem;
   }

   .question-answer {
       padding: 0rem;
   }
}

</style>