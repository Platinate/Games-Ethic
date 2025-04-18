import IUserTO from "@/models/DTOs/User/UserTO";
import IAuthUserTO from "../models/DTOs/User/AuthUserTO";
import agent from "./axios";

const userService = {
    login: (username: string, password: string): Promise<IAuthUserTO> => agent.post("/Users/login", { username, password }),
    loadUser: () :Promise<IUserTO> => agent.get("/Users"),
}

export default userService;