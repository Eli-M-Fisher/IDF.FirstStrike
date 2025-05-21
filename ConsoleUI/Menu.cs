


using System;
using Data;
using Services;
using Enemies;
using Intelligence;
using IDF;

namespace ConsoleUI
{
    public static class Menu
    {
        public static void Start()
        {
            // Initialize system
            var idf = DataInitializer.InitializeIDF();
            var hamas = DataInitializer.InitializeHamas();
            var aman = DataInitializer.InitializeAman(hamas.Terrorists);
            var strikeService = new StrikeService(idf.StrikeUnits, aman.Messages);

            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("==== IDF Operation – First Strike ====");
                Console.WriteLine("1. Analyze Intelligence");
                Console.WriteLine("2. Show Strike Unit Status");
                Console.WriteLine("3. Identify Most Dangerous Terrorist");
                Console.WriteLine("4. Recommend Strike");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine($"Total Intel Messages: {aman.Messages.Count}");
                        break;
                    case "2":
                        Console.WriteLine(idf.ReportAllUnits());
                        break;
                    case "3":
                        var dangerous = strikeService.GetMostDangerousTerrorist(hamas.Terrorists);
                        if (dangerous != null)
                            Console.WriteLine($"Most Dangerous: {dangerous.Name}, Rank {dangerous.Rank}");
                        break;
                    case "4":
                        var target = strikeService.GetMostDangerousTerrorist(hamas.Terrorists);
                        var intel = strikeService.GetLatestIntel(target);
                        if (intel != null)
                        {
                            var unit = strikeService.RecommendStrikeUnit(ConvertLocationToTargetType(intel.Location));
                            Console.WriteLine(unit != null
                                ? $"Recommended Unit: {unit.Name}"
                                : "No suitable unit available.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

            } while (input != "5");
        }

        private static IDF.StrikeUnits.TargetType ConvertLocationToTargetType(string location)
        {
            return location switch
            {
                "home" => IDF.StrikeUnits.TargetType.Buildings,
                "car" => IDF.StrikeUnits.TargetType.Vehicles,
                "outside" => IDF.StrikeUnits.TargetType.OpenArea,
                _ => IDF.StrikeUnits.TargetType.People
            };
        }
    }
}