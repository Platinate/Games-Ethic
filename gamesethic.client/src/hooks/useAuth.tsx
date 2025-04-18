import { useState } from "react";
import { jwtDecode } from "jwt-decode";
import userService from "../api/userService";
import CONSTANTS from "../constants";
import IUserTO from "@/models/DTOs/User/UserTO";

export type JwtPayload = {
    sub: string;
    email: string;
    name: string;
    role: string; // string si un seul rôle, tableau si plusieurs
    exp: number;
    iss: string;
    aud: string;
  };

const useAuth = () => {
    const [token, setToken] = useState<string | undefined>(undefined);
    const [email, setEmail] = useState<string | undefined>(undefined);
    const [roles, setRoles] = useState<string[]>([]);
    const [user, setUser] = useState<IUserTO | undefined>(undefined);
    const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);

    const init = async () => {
        const token = localStorage.getItem(CONSTANTS.ACCESS_TOKEN);
        if(!token) return;
        setIsAuthenticated(true);
        setToken(token);
        const user = await userService.loadUser();
        setUser(user);
        setRoles(user.roles);
    }

    const login = async (username: string, password: string) => {
        const authUser = await userService.login(username, password);
        localStorage.setItem(CONSTANTS.ACCESS_TOKEN, authUser.token);
        setIsAuthenticated(true);
        setToken(authUser.token);
        const user = await userService.loadUser();
        setUser(user);
        setRoles(user.roles);
    };

    const logout = () => {
        setIsAuthenticated(false);
        setToken(undefined);
        setEmail(undefined);
        setUser(undefined);
        setRoles([]);
        localStorage.removeItem(CONSTANTS.ACCESS_TOKEN);
    };

    return {
        isAuthenticated,
        token,
        roles,
        user,
        login,
        logout,
        init
    };
};

export default useAuth;
