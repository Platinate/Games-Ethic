using GamesEthic.Server.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamesEthic.Server.Data
{
    public class GamesEthicDbContext : IdentityDbContext<User>
    {
        public DbSet<Game> Games { get; set; }

        public string DbPath { get; }

        public GamesEthicDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "gamesEthic.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
