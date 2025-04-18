import { Button } from "@/components/ui/button";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import GameTO from "@/models/DTOs/Game/GameTO";
import { Check } from "lucide-react";
import { FC } from "react";

interface IProps {
    game: GameTO;
}

const GameCard: FC<IProps> = ({ game }) => {
    return (
        <Card>
            <CardHeader>
                <CardTitle>{game.name}</CardTitle>
            </CardHeader>
            <CardContent>
            </CardContent>
            <CardFooter>
                <Button className="w-full">
                    <Check /> Mark all as read
                </Button>
            </CardFooter>
        </Card>)
}

export default GameCard;