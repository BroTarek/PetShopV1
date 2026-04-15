import type { Config } from 'tailwindcss';

const config: Config = {
  darkMode: "class",
  theme: {
    extend: {
      colors: {
        "surface-tint": "#5f5e5e",
        "tertiary-fixed-dim": "#c7c6c6",
        "on-error": "#ffffff",
        "on-secondary-fixed-variant": "#284e42",
        "surface-container": "#f0edf2",
        "on-background": "#1b1b1f",
        "tertiary": "#000000",
        "on-surface-variant": "#444748",
        "surface-bright": "#fbf8fd",
        "surface-variant": "#e4e1e6",
        "surface-container-low": "#f5f2f7",
        "secondary-fixed-dim": "#a6cfc0",
        "tertiary-fixed": "#e3e2e2",
        "primary-fixed": "#e5e2e1",
        "on-secondary-fixed": "#002018",
        "primary-fixed-dim": "#c8c6c5",
        "error": "#ba1a1a",
        "on-error-container": "#93000a",
        "inverse-surface": "#303034",
        "surface-container-lowest": "#ffffff",
        "on-tertiary-fixed": "#1b1c1c",
        "surface": "#fbf8fd",
        "on-secondary-container": "#446a5e",
        "outline": "#747878",
        "surface-dim": "#dcd9de",
        "on-tertiary": "#ffffff",
        "on-primary-fixed-variant": "#474646",
        "inverse-primary": "#c8c6c5",
        "background": "#fbf8fd",
        "on-tertiary-container": "#848484",
        "tertiary-container": "#1b1c1c",
        "surface-container-high": "#eae7ec",
        "on-primary-fixed": "#1c1b1b",
        "surface-container-highest": "#e4e1e6",
        "on-secondary": "#ffffff",
        "on-primary": "#ffffff",
        "on-surface": "#1b1b1f",
        "inverse-on-surface": "#f2f0f5",
        "secondary-fixed": "#c2ebdc",
        "secondary": "#406659",
        "on-primary-container": "#858383",
        "secondary-container": "#bfe9d9",
        "primary-container": "#1c1b1b",
        "primary": "#000000",
        "outline-variant": "#c4c7c7",
        "on-tertiary-fixed-variant": "#464747",
        "error-container": "#ffdad6"
      },
      borderRadius: {
        DEFAULT: "1rem",
        lg: "2rem",
        xl: "3rem",
        full: "9999px"
      },
      fontFamily: {
        headline: ["Plus Jakarta Sans", "sans-serif"],
        body: ["Inter", "sans-serif"],
        label: ["Inter", "sans-serif"]
      },
      boxShadow: {
        'editorial-shadow': '0 20px 40px -10px rgba(27, 27, 31, 0.05)',
        'editorial-hover': '0 20px 40px rgba(27, 27, 31, 0.06)',
      }
    },
  },
  plugins: [],
};

export default config;