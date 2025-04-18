import { FC } from "react";
import "./App.css";
import { Link, Outlet } from "react-router";
import { NavigationMenu, NavigationMenuItem, NavigationMenuLink, NavigationMenuList, NavigationMenuTrigger, navigationMenuTriggerStyle } from "@/components/ui/navigation-menu";
import { useAuthContext } from "@/contexts/AuthContext";

const App: FC = () => {
  const auth = useAuthContext();
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
            <NavigationMenuItem>
              {auth.isAuthenticated && (
                <Link to="Profile">
                  <NavigationMenuLink className={navigationMenuTriggerStyle()}>My Profile</NavigationMenuLink>
                </Link>
              )}{auth.isAuthenticated ? <NavigationMenuLink  onClick={() => auth.logout()} className={navigationMenuTriggerStyle()}>Logout</NavigationMenuLink > : <NavigationMenuLink className={navigationMenuTriggerStyle()}  onClick={() => auth.login("", "")}>Login</NavigationMenuLink >} 
            </NavigationMenuItem>
          </NavigationMenuList>
        </NavigationMenu>
      </div>
      <div className="App__body">
        <Outlet />
      </div>
    </div>
  );
};

export default App;
