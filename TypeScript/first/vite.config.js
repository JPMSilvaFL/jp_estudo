import { defineConfig } from "vite";
// import react from "@vitejs/plugin-react-swc";
// import tailwindcss from "@tailwindcss/vite";
import path from "path";
import { fileURLToPath } from "url";

const __dirname = path.dirname(fileURLToPath(import.meta.url));
// https://vite.dev/config/
export default defineConfig({
  resolve: {
    alias: {
      "@": path.join(__dirname, "frontend", "assets"),
    },
  },
  plugins: [],
  server: {
    port: 3000,
  },
  esbuild: {
    sourcemap: true,
  },
});
