import gameService from "@/api/gameService";
import GameCard from "@/components/molecules/GameCard";
import IGameTO from "@/models/DTOs/Game/GameTO";
import { FC, useEffect, useState } from "react";
import "./Games.css"
import IPage from "@/models/generic/Page";
import GameTO from "@/models/DTOs/Game/GameTO";

const Games: FC = () => {
  const [currentPage, setCurrentPage] = useState<IPage<GameTO>>({data: [], index: 1, size: 0, totalPages: 0});

  useEffect(() => {
    const loadData = async () => {
      const page = await gameService.getGames();
      setCurrentPage(page);
    }
    loadData();
  }, [])

  return <div className="Games">
    <div className="Games__searchBar">

    </div>
    <div className="Games__list">
      {currentPage.data.map((game) => <GameCard game={game}/>)}
    </div>
  </div>;
};

export default Games;