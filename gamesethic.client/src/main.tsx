import { createRoot } from "react-dom/client";
import "./index.css";
import { createBrowserRouter, Navigate, RouterProvider } from "react-router";
import Home from "./components/pages/Home";
import Profile from "./components/pages/Profile";
import Games from "./components/pages/Games";
import GameDetails from "./components/pages/GameDetails";
import App from "./containers/App";
import { AuthProvider } from "./contexts/AuthContext";
import Login from "./components/pages/Login";

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
                path: "login",
                Component: Login
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
    <AuthProvider>
        <RouterProvider router={router} />
    </AuthProvider>
);
