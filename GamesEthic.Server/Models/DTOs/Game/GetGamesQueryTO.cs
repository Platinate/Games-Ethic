namespace GamesEthic.Server.Models.DTOs.Game
{
    public sealed class GetGamesQueryTO
    {
        public string? Name { get; set; }
        public int Index { get; set; } = 1;
        public int Size { get; set; } = 50;
    }
}
