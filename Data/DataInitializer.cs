using System;
using System.Collections.Generic;
using IDF;
using IDF.StrikeUnits;
using Enemies;
using Intelligence;
using Core; // Make sure the namespace Core exists and contains Status and WeaponType
using Utils; // Ensure this namespace contains RandomGenerator

namespace Data
{
    public static class DataInitializer
    {
        public static IDF.IDF InitializeIDF()
        {
            var idf = new IDF.IDF("General Kochavi", "1948");

            idf.AddStrikeUnit(new F16("Falcon-1"));
            idf.AddStrikeUnit(new Drone("Zik-Alpha"));
            idf.AddStrikeUnit(new Artillery("Thunder-7"));

            return idf;
        }

        public static Hamas InitializeHamas()
        {
            var hamas = new Hamas("Yahya Sinwar", new DateTime(1987, 12, 14), new List<Terrorist>());

            for (int i = 0; i < 6; i++)
            {
                string name = $"Terrorist-{i + 1}";
                int rank = RandomGenerator.GetRandomRank();
                Status status = Status.Alive;
                var weapons = new List<WeaponType>
                {
                    RandomGenerator.GetRandomWeapon(),
                    RandomGenerator.GetRandomWeapon()
                };

                var terrorist = new Terrorist(name, rank, status, weapons);
                hamas.Terrorists.Add(terrorist);
            }

            return hamas;
        }

        public static Aman InitializeAman(List<Terrorist> terrorists)
        {
            var aman = new Aman();

            var random = new Random();
            for (int i = 0; i < 12; i++)
            {
                var terrorist = terrorists[random.Next(terrorists.Count)];
                string location = RandomGenerator.GetRandomLocation();
                DateTime timestamp = DateTime.Now.AddMinutes(-random.Next(60, 1440));
                int confidence = random.Next(50, 100);

                var intel = new IntelligenceMessage(terrorist, location, timestamp, confidence);
                aman.AddMessage(intel);
            }

            return aman;
        }
    }
}
