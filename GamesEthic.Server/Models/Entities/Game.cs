
namespace GamesEthic.Server.Models.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; internal set; }
    }
}
