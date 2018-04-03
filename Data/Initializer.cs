using System;
using System.Linq;
using System.Threading.Tasks;
using EasyGrow.Helpers;
using EasyGrow.Models;
using Microsoft.AspNetCore.Identity;


namespace EasyGrow.Data
{
    public class Initializer
    {
        public static async Task InitializeAsync(PlantContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("admin");
            if (adminRole == null)
            {
                adminRole = new IdentityRole("admin");
                await roleManager.CreateAsync(adminRole);
            }

            var userRole = await roleManager.FindByNameAsync("user");
            if (userRole == null)
            {
                userRole = new IdentityRole("user");
                await roleManager.CreateAsync(userRole);
            }

            if (!context.Geolocations.Any())
            {
                var chernivtsi = new Geolocation
                {
                    Latitude = "48.2921",
                    Longitude = "25.9358",
                };

                var london = new Geolocation
                {
                    Latitude = "51.5074",
                    Longitude = "0.1278",
                };

                context.Geolocations.AddRange(chernivtsi, london);
                context.SaveChanges();
            }

            if (!context.Phases.Any())
            {
                var planting = new Phase
                {
                    Duration = 1,
                    Name = "Planting"
                };

                var vegetative = new Phase
                {
                    Duration = 14,
                    Name = "Vegetative"
                };

                var firstFlowering = new Phase
                {
                    Duration = 15,
                    Name = "First Flowering"
                };

                context.Phases.AddRange(planting, vegetative, firstFlowering);
                context.SaveChanges();
            }

            if (!context.GroundwaterLevels.Any())
            {
                var first = new GroundwaterLevel
                {
                    Name = "1"
                };

                var second = new GroundwaterLevel
                {
                    Name = "2"
                };


                var third = new GroundwaterLevel
                {
                    Name = "3"
                };

                context.GroundwaterLevels.AddRange(first, second, third);
                context.SaveChanges();
            }

            if (!context.Classes.Any())
            {
                var vegetable = new Class
                {
                    Name = "vegetable"
                };

                context.Classes.Add(vegetable);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com"
                };

                await userManager.CreateAsync(user, password: "Wazxsw12!");
                await userManager.AddToRoleAsync(user, role: "user");

                context.SaveChanges();

                var admin = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                };
                try
                {
                    await userManager.CreateAsync(admin, password: "Wazxsw12!");
                    await userManager.AddToRoleAsync(admin, role: "admin");
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.BadRequest, LogCategory.Warning,
                        "Init db " + ex));
                }
            }

            if (!context.AdditionalCriteries.Any())
            {
                var addCrit = new AdditionalCriteries();
                var groundWater = context.GroundwaterLevels.FirstOrDefault();
                addCrit.AreaSawn = 25;

                if (groundWater != null) addCrit.GroundwaterLevelId = groundWater.GroundwaterLevelId;

                context.AdditionalCriteries.Add(addCrit);
                context.SaveChanges();
            }

            if (!context.Plants.Any())
            {
                var plant = new Plant
                {
                    AdditionalCriteries = context.AdditionalCriteries.FirstOrDefault(),
                    Age = 2,
                    AmountOfFertilizingDays = 21,
                    AmountOfWater = 2,
                    Class = context.Classes.FirstOrDefault(),
                    FrequencyOfWateringDays = 2,
                    Info = "Interesting info...",
                    Name = "Tomato"
                };

                context.Plants.Add(plant);
                context.SaveChanges();
            }

            if (!context.UserPlantPhaseGeo.Any())
            {
                var userPlantPhaseGeo = new UserPlantPhaseGeo
                {
                    ApplicationUser = context.Users.FirstOrDefault(),
                    Plant = context.Plants.FirstOrDefault(),
                    Phase = context.Phases.FirstOrDefault(),
                    Geolocation = context.Geolocations.FirstOrDefault()
                };

                context.UserPlantPhaseGeo.Add(userPlantPhaseGeo);
                context.SaveChanges();
            }
        }
    }
}
