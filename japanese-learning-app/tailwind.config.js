/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        card: "#EAEAEA", // Explicitly add 'card' to Tailwind colors
        text: "#ffffff", // Ensure text color is included
      },
      fontFamily: {
        sans: ["Poppins", "sans-serif"],
      },
    },
  },
  plugins: [
    require("@tailwindcss/typography"), require('daisyui'),
  ],
  daisyui: {
    themes: [
      {
        mytheme: {
          "primary": "#4E3A4F", 
          "secondary": "#998FD5",
          "accent": "#BCDCAC",
          "neutral": "#1c1c1c",
          "text": "#FDFDFD",
          "card": "#EAEAEA",
          "base-100": "#2D222D",
          "info": "#3abff8",
          "success": "#36d399",
          "warning": "#fbbf24",
          "error": "#ef4444",
          "--rounded-btn": "5rem",
          "font-family": "Poppins, sans-serif",
        },
      },
      "light", // Keep default light theme
      "dark",  // Keep default dark theme
    ],
  },
}
