/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./src/**/*.{html,js,vue}'],
  theme: {
    extend: {
      colors: {
        background: '#242424',
        // primary: '#ff4f17',
        primary: '#F15A29', //Izsak adta meg
        hoverPrimary: '#C64A21',
        secondary: '#FFFFFF',
        error: '#FA0707',
        tertiary: '#111827',
      },
      fontFamily: {
        ubuntu: ['"Ubuntu-Regular"', 'sans-serif'],
        ubuntuBold: ['"Ubuntu-Bold"', 'sans-serif'],
        ubuntuItalic: ['"Ubuntu-Italic"', 'sans-serif'],
        russo: ['"Russo-One"', 'sans-serif'],
      },
    },
  },
  plugins: [require('flowbite/plugin')],
};
