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
                Geolocation chernivtsi = new Geolocation();
                chernivtsi.Latitude = "48.2921";
                chernivtsi.Longitude = "25.9358";
                chernivtsi.SeaLevel = "248";

                Geolocation london = new Geolocation();
                london.Latitude = "51.5074";
                london.Longitude = "0.1278";
                london.SeaLevel = "35";

                context.Geolocations.AddRange(chernivtsi, london);
                context.SaveChanges();
            }

            if (!context.Phases.Any())
            {
                Phase planting = new Phase();
                planting.Duration = 1;
                planting.Name = "Planting";

                Phase vegetative = new Phase();
                vegetative.Duration = 14;
                vegetative.Name = "Vegetative";

                Phase firstFlowering = new Phase();
                firstFlowering.Duration = 15;
                firstFlowering.Name = "First Flowering";

                context.Phases.AddRange(planting, vegetative, firstFlowering);
                context.SaveChanges();
            }

            if (!context.GroundwaterLevels.Any())
            {
                GroundwaterLevel first = new GroundwaterLevel();
                first.Name = "1";

                GroundwaterLevel second = new GroundwaterLevel();
                first.Name = "2";

                GroundwaterLevel third = new GroundwaterLevel();
                first.Name = "3";

                context.GroundwaterLevels.AddRange(first, second, third);
                context.SaveChanges();
            }

            if (!context.Classes.Any())
            {
                Class vegetable = new Class();
                vegetable.Name = "vegetable";

                context.Classes.Add(vegetable);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var geo = context.Geolocations.FirstOrDefault();
                var user = new ApplicationUser
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com",
                    GeolocationId = geo.GeolocationId
                };

                var result = await userManager.CreateAsync(user, password: "Wazxsw12!");
                await userManager.AddToRoleAsync(user, role: "user");
                context.SaveChanges();

                var admin = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    GeolocationId = 2
                };
                try
                {
                    result = await userManager.CreateAsync(admin, password: "Wazxsw12!");
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
                addCrit.GroundwaterLevelId = groundWater.GroundwaterLevelId;

                context.AdditinalCriteries.Add(addCrit);
                context.SaveChanges();
            }

            if (!context.Plants.Any())
            {
                var plant = new Plant();
                plant.AdditinalCriteries = context.AdditinalCriteries.FirstOrDefault();
                plant.Age = 2;
                plant.AmountOfFertilizingDays = 21;
                plant.AmountOfWater = 2;
                plant.Class = context.Classes.FirstOrDefault();
                plant.FrequencyOfWateringDays = 2;
                plant.Info = "Interesting info...";
                plant.Name = "Tomato";
                plant.PhaseId = context.Phases.FirstOrDefault().PhaseId;

                context.Plants.Add(plant);
                context.SaveChanges();
            }

            if (!context.UserPlants.Any())
            {
                UserPlants UserPlant = new UserPlants();
                UserPlant.ApplicationUser = context.Users.FirstOrDefault();
                UserPlant.Plant = context.Plants.FirstOrDefault();

                context.UserPlants.Add(UserPlant);
                context.SaveChanges();
            }
        }
    }
}
