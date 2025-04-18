import GameTO from "@/models/DTOs/Game/GameTO";
import agent from "./axios";
import IPage from "@/models/generic/Page";

const gameService = {
    getGames: () : Promise<IPage<GameTO>> => agent.get("/Games")
}

export default gameService;