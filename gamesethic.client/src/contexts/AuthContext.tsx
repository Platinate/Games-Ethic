import useAuth from "@/hooks/useAuth";
import IUserTO from "@/models/DTOs/User/UserTO";
import React, { createContext, useContext, ReactNode } from "react";

interface AuthState {
    token: string | undefined,
    roles: string[],
    user: IUserTO | undefined,
    isAuthenticated:boolean;
    login: (username:string,password:string) => void;
    logout: () => void;
    init: () => void;
}

const AuthContext = createContext<AuthState | undefined>(undefined);

interface KeycloakProviderProps {
  children: ReactNode;
}

export const AuthProvider: React.FC<KeycloakProviderProps> = ({ children }) => {
  const auth = useAuth();

  return <AuthContext.Provider value={auth}>{children}</AuthContext.Provider>;
};

export const useAuthContext = (): AuthState => {
  const context = useContext(AuthContext);
  if (context === undefined) {
    throw new Error("useAuthContext must be used within a AuthProvider");
  }
  return context;
};
