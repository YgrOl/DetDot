using System;
using System.Linq;
using DetailService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DetailService.Data
{
    public static class PrepDb
    {
       public static void PrepPopulation(IApplicationBuilder app, bool isProd)
       {
        using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
       }

       private static void SeedData(AppDbContext context, bool isProd)
       {

        if(isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }
            
            if (!context.Details.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Details.AddRange(
                    new Detail() {Name = "Труба",Type= "Труби", Description= "Труба — довгий порожнистий предмет або пристрій, звичайно кільцевого перерізу, призначений для переміщення рідини, пари, газу та інше."},
                    new Detail() {Name = "Сальниковий защільнювач",Type= "Ущільнювальні пристрої", Description= "Сальниковий защільнювач-защільнювач рухомих з'єднань деталей з метою герметизації щілин між рухомими і нерухомими деталями; забезпечується податливими елементами, що одягають на вал (шток), або набивками, що закладаються у виточки чи заглибини кришок, корпусів та інших деталей."},
                    new Detail() {Name = "Дверне клепало",Type= "Фурнітура", Description= "Клепа́ло-зовнішнє знаряддя на дверях, призначене для людей, що перебувають за межами будинку, сповіщати стуком господарів про свою присутність і бажання увійти у приміщення."}
                );
                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
       }
    }
}