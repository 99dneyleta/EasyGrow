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
                    SeaLevel = "248"
                };

                var london = new Geolocation
                {
                    Latitude = "51.5074",
                    Longitude = "0.1278",
                    SeaLevel = "35"
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
                var geo = context.Geolocations.FirstOrDefault();
                if (geo != null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = "user@gmail.com",
                        Email = "user@gmail.com",
                        GeolocationId = geo.GeolocationId
                    };

                    await userManager.CreateAsync(user, password: "Wazxsw12!");
                    await userManager.AddToRoleAsync(user, role: "user");
                }
                context.SaveChanges();

                var admin = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    GeolocationId = 2
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

            if (!context.AdditinalCriteries.Any())
            {
                var addCrit = new AdditinalCriteries();
                var groundWater = context.GroundwaterLevels.FirstOrDefault();
                addCrit.AreaSawn = 25;

                if (groundWater != null) addCrit.GroundwaterLevelId = groundWater.GroundwaterLevelId;

                context.AdditinalCriteries.Add(addCrit);
                context.SaveChanges();
            }

            if (!context.Plants.Any())
            {
                var plant = new Plant
                {
                    AdditinalCriteries = context.AdditinalCriteries.FirstOrDefault(),
                    Age = 2,
                    AmountOfFertilizingDays = 21,
                    AmountOfWater = 2,
                    Class = context.Classes.FirstOrDefault(),
                    FrequencyOfWateringDays = 2,
                    Info = "Interesting info...",
                    Name = "Tomato",
                    PhaseId = context.Phases.FirstOrDefault()?.PhaseId
                };

                context.Plants.Add(plant);
                context.SaveChanges();
            }

            if (!context.UserPlants.Any())
            {
                var userPlant = new UserPlants
                {
                    ApplicationUser = context.Users.FirstOrDefault(),
                    Plant = context.Plants.FirstOrDefault()
                };

                context.UserPlants.Add(userPlant);
                context.SaveChanges();
            }
        }
    }
}
