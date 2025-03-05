/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {},
  },
  plugins: [
    require("@tailwindcss/typography"), require('daisyui'),
  ],
  daisyui: {
    themes: [
      {
        mytheme: {  // 👈 Custom Theme Name
          "primary": "#4E3A4F", 
          "secondary": "#998FD5",
          "accent": "#50e3c2",
          "neutral": "#1c1c1c",
          "text": "#ffffff",
          "base-100": "#2D222D",
          "info": "#3abff8",
          "success": "#36d399",
          "warning": "#fbbf24",
          "error": "#ef4444",
          "--rounded-btn": "5rem",
        },
      },
      "light", // Keep default light theme
      "dark",  // Keep default dark theme
    ],
  },
}
