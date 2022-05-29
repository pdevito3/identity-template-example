const colors = require('tailwindcss/colors')

module.exports = {
  content: ['./**/*.{razor,html}'],
  theme: {
    extend: {
      colors: {
        violet: colors.violet,
      }
    },
  },
  plugins: [
    require('@tailwindcss/forms'),
  ],
}