﻿using MarineWebsiteServer.WebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace MarineWebsiteServer.WebAPI.Middlewares;

public static class ExtensionMiddleware
{
    public static void CreateAdmin(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any(p => p.Email == "info@marqexmarine.com"))
            {
                AppUser user = new()
                {
                    FirstName = "Mehmet Ali",
                    LastName = "Üçer",
                    UserName = "admin",
                    Email = "info@marqexmarine.com",
                    IsDeleted = false,
                    EmailConfirmed = true,
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now,
                };

                userManager.CreateAsync(user, "Password123*").Wait();
            }
        }
    }
}
