using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GamesEthic.Server.Models.Entities;
using GamesEthic.Server.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<GamesEthicDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        await context.Database.MigrateAsync();

        // ✅ Rôles
        var roles = new[] { "Admin", "User" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // ✅ Utilisateur Admin
        var adminEmail = "admin@gamesethic.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new User
            {
                UserName = "admin",
                Email = adminEmail,
                DisplayName = "Super Admin",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "Admin123!");

            if (result.Succeeded)
                await userManager.AddToRoleAsync(adminUser, "Admin");
            else
                throw new Exception("Failed to create admin user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        // ✅ Seed d’exemple : jeu
        if (!context.Games.Any())
        {
            context.Games.Add(new Game
            {
                Name = "Legend of Code",
                ImageUrl = "Un jeu sur la programmation.",
                ReleaseDate = DateTime.UtcNow
            });

            await context.SaveChangesAsync();
        }
    }
}
