import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import laravel from 'laravel-vite-plugin';
import path from 'path';
import { mkdirSync } from 'fs';

const outDir = '../wwwroot/build';

// Ensure the build directory exists
mkdirSync(outDir, { recursive: true });

export default defineConfig({
  plugins: [
    laravel({
      input: ['src/main.js'],
      publicDirectory: outDir,
      refresh: true, // Keep automatic refresh functionality
    }),
    vue({
      template: {
        transformAssetUrls: {
          // Ensure assets are correctly referenced in production
          base: null, // Avoid rewriting asset URLs during the build
          includeAbsolute: false, // Keep the URLs relative to the build folder
        },
      },
    }),
  ],
  resolve: {
    alias: {
      '@': path.resolve(__dirname, 'src'),
    },
  },
  build: {
    outDir, // Output directory for your built assets
    emptyOutDir: true, // Clean the output directory before building
    // Base path for production (to serve assets correctly)
    base: process.env.NODE_ENV === 'production' ? '/build/' : '/',
  },
  server: {
    // Disable HMR in production to avoid connections to the dev server
    hmr: process.env.NODE_ENV !== 'production',
  },
  optimizeDeps: {
    exclude: ['vue3-toastify'], // Exclude the problematic package from optimization
  },
});
