import CONSTANTS from "@/constants";
import axios from "axios";

const instance = axios.create({
  timeout: 5000,
  baseURL: "https://localhost:7047",
  headers: {
    // En global, on laisse l'axios choisir le bon Content-Type par défaut
  }
});

instance.interceptors.request.use((config) => {
  const token = localStorage.getItem(CONSTANTS.ACCESS_TOKEN);
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

const agent = {
  get: (url: string, signal?: AbortSignal) =>
    instance
      .get(url, {
        signal,
      })
      .then((response) => response.data),

  post: (
    url: string,
    body: unknown,
    signal?: AbortSignal,
    contentType?: string // optionnel
  ) =>
    instance
      .post(url, body, {
        signal,
        headers: {
          ...(contentType && { "Content-Type": contentType })
        }
      })
      .then((response) => response.data),

  put: (
    url: string,
    body: unknown,
    signal?: AbortSignal,
  ) =>
    instance
      .put(url, body, {
        signal
      })
      .then((response) => response.data),

  patch: (
    url: string,
    body: unknown,
    signal?: AbortSignal,
    contentType: string = "application/json-patch+json"
  ) =>
    instance
      .patch(url, body, {
        signal,
        headers: {
          ...(contentType && { "Content-Type": contentType })
        }
      })
      .then((response) => response.data),

  delete: (
    url: string,
    signal?: AbortSignal,
  ) =>
    instance
      .delete(url, {
        signal,
      })
      .then((response) => response.data),
};

export default agent;