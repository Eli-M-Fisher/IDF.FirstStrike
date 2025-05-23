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
            var log = new Logs.StrikeLog();

            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("==== IDF Operation – First Strike ====");
                Console.WriteLine("1. Analyze Intelligence");
                Console.WriteLine("2. Show Strike Unit Status");
                Console.WriteLine("3. Identify Most Dangerous Terrorist");
                Console.WriteLine("4. Recommend Strike");
                Console.WriteLine("5. Show Strike Log Report");
                Console.WriteLine("6. Search for Terrorist");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine($"Total Intel Messages: {aman.Messages.Count}");
                        var mostReported = strikeService.GetMostReportedTerrorist(hamas.Terrorists);
                        if (mostReported != null)
                        {
                            int count = aman.Messages.Count(m => m.TerroristTarget == mostReported);
                            Console.WriteLine($"Most Reported Terrorist: {mostReported.Name} ({count} reports)");
                        }
                        break;
                    case "2":
                        Console.WriteLine(idf.ReportAllUnits());
                        break;
                    case "3":
                        var dangerous = strikeService.GetMostDangerousTerrorist(hamas.Terrorists);
                        if (dangerous != null)
                        {
                            Console.WriteLine($"Most Dangerous Terrorist:");
                            Console.WriteLine($"- Name: {dangerous.Name}");
                            Console.WriteLine($"- Rank: {dangerous.Rank}");
                            Console.WriteLine($"- Weapons: {string.Join(", ", dangerous.Weapons)}");
                            int score = strikeService.GetTerroristQualityScore(dangerous);
                            Console.WriteLine($"- Quality Score: {score}");

                            var lastIntel = strikeService.GetLatestIntel(dangerous);
                            if (lastIntel != null)
                            {
                                Console.WriteLine($"- Last Known Location: {lastIntel.Location} at {lastIntel.Timestamp}");
                                Console.WriteLine($"- Intel Confidence: {lastIntel.ConfidenceScore}");
                            }
                            else
                            {
                                Console.WriteLine("- No recent intelligence available.");
                            }
                        }
                        break;
                    case "4":
                        var target = strikeService.GetMostDangerousTerrorist(hamas.Terrorists);
                        var intel = strikeService.GetLatestIntel(target);
                        if (target != null && intel != null)
                        {
                            var unit = strikeService.RecommendStrikeUnit(ConvertLocationToTargetType(intel.Location));
                            if (unit != null)
                            {
                                unit.ConsumeAmmo();
                                unit.ConsumeFuel();

                                bool success = new Random().Next(100) < intel.ConfidenceScore;

                                log.AddEntry(new Logs.StrikeLogEntry(
                                    target,
                                    "Commander Israel",
                                    unit.Name,
                                    DateTime.Now,
                                    success,
                                    $"Location: {intel.Location}, Confidence: {intel.ConfidenceScore}"
                                ));

                                Console.WriteLine($"Strike executed on {target.Name} using {unit.Name}.");
                                Console.WriteLine($"Result: {(success ? "SUCCESS" : "FAILURE")}");
                            }
                            else
                            {
                                Console.WriteLine("No suitable unit available for this strike.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No valid target or intelligence available.");
                        }
                        break;
                    case "5":
                        Console.WriteLine(log.GenerateReport());
                        break;
                    case "6":
                        Console.Write("Search by name or weapon? (name/weapon): ");
                        string choice = Console.ReadLine()?.Trim().ToLower();

                        if (choice == "name")
                        {
                            Console.Write("Enter name to search: ");
                            string name = Console.ReadLine();
                            string result = SearchingService.SearchTerroristByName(hamas.Terrorists, name);
                            Console.WriteLine(result);
                        }
                        else if (choice == "weapon")
                        {
                            Console.Write("Enter weapon type (e.g., AK47, M16): ");
                            string weaponInput = Console.ReadLine();
                            var matches = SearchingService.TerroristsByWeaponType(hamas.Terrorists, weaponInput);
                            if (matches.Count > 0)
                            {
                                Console.WriteLine("Matching terrorists:");
                                foreach (var name in matches)
                                {
                                    Console.WriteLine($"- {name}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No terrorists found with that weapon.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid search option.");
                        }
                        break;
                    case "7":
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

            } while (input != "7");
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