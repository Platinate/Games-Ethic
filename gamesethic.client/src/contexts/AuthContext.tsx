import useAuth from "@/hooks/useAuth";
import React, { createContext, useContext, ReactNode } from "react";

interface AuthState {
    isAuthenticated:boolean;
    login: (username:string,password:string) => void;
    logout: () => void;
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
