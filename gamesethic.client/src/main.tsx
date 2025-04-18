import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import { createBrowserRouter, Navigate, RouterProvider } from "react-router";
import Home from "./components/pages/Home";
import Profile from "./components/pages/Profile";
import Games from "./components/pages/Games";
import GameDetails from "./components/pages/GameDetails";
import App from "./containers/App";
import { AuthProvider } from "./contexts/AuthContext";

const router = createBrowserRouter([
  {
    path: "/",
    Component: App,
    children: [
      {
        index: true,
        Component: Home,
      },
      {
        path: "profile",
        Component: Profile,
      },
      {
        path: "games",
        children: [
          {
            index: true,
            Component: Games,
          },
          {
            path: ":id",
            Component: GameDetails,
          },
        ],
      },
      {
        path: "*",
        element: <Navigate to="/" />
      }
    ],
  },
]);

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <AuthProvider>
      <RouterProvider router={router} />
    </AuthProvider>
  </StrictMode>
);
