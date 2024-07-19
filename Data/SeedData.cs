using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<Korisnik> userManager)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roleNames = { "Admin", "Korisnik" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Create an admin user if it doesn't exist
        if (userManager.FindByNameAsync("admin").Result == null)
        {
            Korisnik user = new Korisnik
            {
                UserName = "admin",
                Email = "admin@example.com"
            };

            IdentityResult result = userManager.CreateAsync(user, "!Aleksa123").Result;
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
