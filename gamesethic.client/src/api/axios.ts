import axios from "axios";

const instance = axios.create({
  timeout: 5000
});

const agent = {
  get: (url: string, signal?: AbortSignal, authorization?: string) =>
    instance
      .get(url, { signal: signal, headers: { Authorization: authorization } })
      .then((response) => response.data),
  post: (
    url: string,
    body: unknown,
    signal?: AbortSignal,
    authorization?: string,
    contentType: string | null = null
  ) =>
    instance
      .post(url, body, {
        signal: signal,
        headers: { Authorization: authorization, "Content-Type": contentType },
      })
      .then((response) => response.data),
  put: (url: string, body: unknown, signal?: AbortSignal, authorization?: string) =>
    instance
      .put(url, body, {
        signal: signal,
        headers: { Authorization: authorization },
      })
      .then((response) => response.data),
  delete: (url: string, signal?: AbortSignal, authorization?: string) =>
    instance
      .delete(url, {
        signal: signal,
        headers: { Authorization: authorization },
      })
      .then((response) => response.data),
};

export default agent;