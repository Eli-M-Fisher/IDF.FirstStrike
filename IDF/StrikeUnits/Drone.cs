

using System;

namespace IDF.StrikeUnits
{
    public class Drone : IStrikeUnit
    {
        public string Name { get; private set; }
        public int AmmoCount { get; private set; }
        public int FuelLevel { get; private set; }
        public TargetType EffectiveAgainst { get; private set; }

        private const int MaxAmmo = 3;
        private const int MaxFuel = 80;

        public Drone(string name)
        {
            Name = name;
            AmmoCount = MaxAmmo;
            FuelLevel = MaxFuel;
            EffectiveAgainst = TargetType.People; // or Vehicles, could be extended with logic later
        }

        public bool CanStrike(TargetType target)
        {
            return AmmoCount > 0 && FuelLevel > 0 && 
                   (EffectiveAgainst == target || target == TargetType.Vehicles);
        }

        public void ConsumeAmmo()
        {
            if (AmmoCount > 0)
            {
                AmmoCount--;
            }
        }

        public void ConsumeFuel()
        {
            if (FuelLevel >= 5)
            {
                FuelLevel -= 5;
            }
        }

        public string ReportStatus()
        {
            return $"Drone '{Name}': Ammo = {AmmoCount}, Fuel = {FuelLevel}, Effective Against = {EffectiveAgainst}";
        }
    }
}