<template>
  <div class="access-denied">
    <h1>Access Denied</h1>
    <p>You do not have permission to access this page.</p>
    <div v-if="returnUrl === '/masterclass'">
      <p>You didn't purchase our masterclass yet.</p>
      <span>
        Click
        <a href="/purchase">here</a>
        to get access!
      </span>
    </div>
  </div>
</template>

<script setup>
import { onMounted, ref } from 'vue';
const returnUrl = ref(
  new URLSearchParams(window.location.search).get('ReturnUrl')
);
</script>
<style scoped>
.access-denied {
  text-align: center;
  margin-top: 50px;
}

.access-denied h1 {
  font-size: 2em;
  color: #f44336;
}

.access-denied p {
  font-size: 1.2em;
}

.access-denied a {
  color: #007bff;
  text-decoration: none;
  font-size: 1.2em;
}

.access-denied a:hover {
  text-decoration: underline;
}
</style>
