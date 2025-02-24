<template>
  <div class="text-center px-8">
    <h1>Admin page</h1>
    <Vue3Datatable
      :columns="columns"
      :rows="props.users"
      class="mt-8"
      skin="bh-table-hover"
      columnFilter="true"
      sortable="true"
    >
      <template #confirmed="row">
        <div v-if="row.value.confirmed">
          <CheckCircleIcon class="text-green-500 w-8 h-8 mx-auto" />
        </div>
        <div v-else>
          <XCircleIcon class="text-red-500 w-8 h-8 mx-auto" />
        </div>
      </template>
      <template #hasAccess="row">
        <div v-if="row.value.hasAccess">
          <CheckCircleIcon class="text-green-500 w-8 h-8 mx-auto" />
        </div>
        <div v-else>
          <XCircleIcon class="text-red-500 w-8 h-8 mx-auto" />
        </div>
      </template>
    </Vue3Datatable>
  </div>
</template>

<script setup>
import Vue3Datatable from '@bhplugin/vue3-datatable';
import '@bhplugin/vue3-datatable/dist/style.css';
import { onMounted } from 'vue';
import { CheckCircleIcon, XCircleIcon } from '@heroicons/vue/24/outline';

const props = defineProps({
  users: {
    type: Array,
    required: true,
  },
});

onMounted(() => {
  console.log('Users:', props.users);
});
const columns = [
  {
    title: 'Email',
    field: 'email',
    width: '40%',
  },
  {
    title: 'Confirmed',
    field: 'confirmed',
    width: '20%',
    headerClass: 'justify-center',
  },
  {
    title: 'Has access',
    field: 'hasAccess',
    width: '20%',
    headerClass: 'justify-center',
  },
  {
    title: 'Purchase date',
    field: 'purchaseDate',
    width: '20%',
    headerClass: 'justify-center',
    cellClass: '!text-center',
    filter: false,
  },
];
</script>

<style>
table {
  min-height: 400px;
}
table tr {
  background-color: white;
}

.bh-pagination {
  color: white;
}

.bh-pagesize {
  width: 60px;
}
</style>
