import { createInertiaApp } from '@inertiajs/vue3';
import { createApp, h } from 'vue';
import { resolvePageComponent } from 'laravel-vite-plugin/inertia-helpers';
import Layout from './Layout.vue';
import './style.css';
import './fonts.css';

createInertiaApp({
  resolve: (name) => {
    // Dynamically resolve the page component based on the name
    const page = resolvePageComponent(
      `./Pages/${name}.vue`,
      import.meta.glob('./Pages/**/*.vue')
    );

    // Ensure that the layout is assigned to each page
    page.then((module) => {
      module.default.layout = module.default.layout || Layout;
    });
    return page;
  },
  setup({ el, App, props, plugin }) {
    // Initialize Vue app and Inertia plugin
    const app = createApp({ render: () => h(App, props) }).use(plugin); // Inertia.js plugin // Vue Router plugin

    // Mount the app to the DOM
    app.mount(el);
  },
  title: (title) => `${title}`, // Set the document title dynamically
  progress: {
    color: '#4B5563', // Progress bar color
  },
});
