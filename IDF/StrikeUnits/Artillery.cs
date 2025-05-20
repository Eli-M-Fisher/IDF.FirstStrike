

using System;

namespace IDF.StrikeUnits
{
    public class Artillery : IStrikeUnit
    {
        public string Name { get; private set; }
        public int AmmoCount { get; private set; }
        public int FuelLevel { get; private set; }
        public TargetType EffectiveAgainst { get; private set; }

        private const int MaxAmmo = 40;
        private const int MaxFuel = 60;

        public Artillery(string name)
        {
            Name = name;
            AmmoCount = MaxAmmo;
            FuelLevel = MaxFuel;
            EffectiveAgainst = TargetType.OpenArea;
        }

        public bool CanStrike(TargetType target)
        {
            return AmmoCount > 0 && FuelLevel > 0 && EffectiveAgainst == target;
        }

        public void ConsumeAmmo()
        {
            if (AmmoCount >= 3)
            {
                AmmoCount -= 3; // Can strike 2–3 targets simultaneously
            }
            else if (AmmoCount > 0)
            {
                AmmoCount = 0;
            }
        }

        public void ConsumeFuel()
        {
            if (FuelLevel >= 7)
            {
                FuelLevel -= 7;
            }
        }

        public string ReportStatus()
        {
            return $"Artillery '{Name}': Ammo = {AmmoCount}, Fuel = {FuelLevel}, Effective Against = {EffectiveAgainst}";
        }
    }
}