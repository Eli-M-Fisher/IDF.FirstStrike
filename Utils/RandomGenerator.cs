using System;
using Core;

namespace Utils
{
    public static class RandomGenerator
    {
        private static readonly Random _random = new Random();

        public static WeaponType GetRandomWeapon()
        {
            Array values = Enum.GetValues(typeof(WeaponType));
            return (WeaponType)values.GetValue(_random.Next(values.Length));
        }

        public static int GetRandomRank()
        {
            return _random.Next(1, 6); // 1 to 5
        }

        public static string GetRandomLocation()
        {
            string[] locations = { "home", "car", "outside" };
            return locations[_random.Next(locations.Length)];
        }
    }
}
