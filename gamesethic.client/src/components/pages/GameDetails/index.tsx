import { FC } from "react";
import { useParams } from "react-router";

const GameDetails: FC = () => {
  const { id } = useParams();
  return <h1>GAME DETAILS: {id}</h1>;
};

export default GameDetails;
