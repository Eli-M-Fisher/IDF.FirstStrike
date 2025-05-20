

using System;

namespace IDF.StrikeUnits
{
    public class F16 : IStrikeUnit
    {
        public string Name { get; private set; }
        public int AmmoCount { get; private set; }
        public int FuelLevel { get; private set; }
        public TargetType EffectiveAgainst { get; private set; }

        private const int MaxAmmo = 8;
        private const int MaxFuel = 100;

        public F16(string name)
        {
            Name = name;
            AmmoCount = MaxAmmo;
            FuelLevel = MaxFuel;
            EffectiveAgainst = TargetType.Buildings;
        }

        public bool CanStrike(TargetType target)
        {
            return AmmoCount > 0 && FuelLevel > 0 && EffectiveAgainst == target;
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
            if (FuelLevel >= 10)
            {
                FuelLevel -= 10;
            }
        }

        public string ReportStatus()
        {
            return $"F16 '{Name}': Ammo = {AmmoCount}, Fuel = {FuelLevel}, Effective Against = {EffectiveAgainst}";
        }
    }
}