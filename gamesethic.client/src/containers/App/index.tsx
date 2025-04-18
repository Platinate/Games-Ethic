import { FC, useEffect } from "react";
import "./App.css";
import { Link, Outlet, useNavigate } from "react-router";
import { NavigationMenu, NavigationMenuItem, NavigationMenuLink, NavigationMenuList, NavigationMenuTrigger, navigationMenuTriggerStyle } from "@/components/ui/navigation-menu";
import { useAuthContext } from "@/contexts/AuthContext";
import { Button } from "@/components/ui/button";

const App: FC = () => {
    const navigate = useNavigate();
    const auth = useAuthContext();

    useEffect(() => {
        auth.init();
    }, [auth.isAuthenticated])

    const onLogout = () => {
        auth.logout();
        navigate("/");
    }

    return (
        <div className="App">
            <div className="App__header">
                <NavigationMenu>
                    <NavigationMenuList>
                        <NavigationMenuItem>
                            <Link to="/">
                                <NavigationMenuLink className={navigationMenuTriggerStyle()}>Home</NavigationMenuLink>
                            </Link>
                        </NavigationMenuItem>
                        <NavigationMenuItem>
                            <Link to="Games">
                                <NavigationMenuLink className={navigationMenuTriggerStyle()}>Games</NavigationMenuLink>
                            </Link>
                        </NavigationMenuItem>
                        {auth.isAuthenticated && (
                            <NavigationMenuItem>
                                <Link to="Profile">
                                    <NavigationMenuLink className={navigationMenuTriggerStyle()}>My Profile</NavigationMenuLink>
                                </Link>
                            </NavigationMenuItem>
                        )}
                    </NavigationMenuList>
                </NavigationMenu>
                <div style={{display:"flex", alignItems: "center", gap: "8px"}}>
                    {auth.user?.username}
                    {auth.isAuthenticated ? <Button onClick={onLogout}>Logout</Button> : <Button onClick={() => navigate("/login")}>Login</Button>}
                </div>
            </div>
            <div className="App__body">
                <Outlet />
            </div>
        </div>
    );
};

export default App;
