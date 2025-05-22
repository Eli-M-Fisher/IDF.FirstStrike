using Core;
using Enemies;
using System;

public static class SearchingService
{
    public static string SearchTerroristByName(List<Terrorist> terrorists, string name)
    {
        foreach (var terrorist in terrorists)
        {
            if (terrorist.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            {
                return $"The name '{name}' is in the list of terrorists.";
            }
        }
        return $"The name '{name}' was not found in the terrorist list.";
    }

    public static List<string> TerroristsByWeaponType(List<Terrorist> terrorists, string weaponTypeString)
    {
        var terroristsByWeaponType = new List<string>();

        bool parsed = Enum.TryParse(weaponTypeString, ignoreCase: true, out WeaponType weaponEnum);
        if (!parsed) return terroristsByWeaponType;

        foreach (var terrorist in terrorists)
        {
            if (terrorist.Weapons.Contains(weaponEnum))
            {
                terroristsByWeaponType.Add(terrorist.Name);
            }
        }

        return terroristsByWeaponType;
    }
}