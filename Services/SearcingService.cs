using Core;
using Enemies;

public static class SearchingService
{
    public static string SearchTeroristByName(List<Terrorist> terrorists, string name)
    {
        foreach (var terorist in terrorists)
        {
            if (terorist.Name == name)
            {
                string result = "$teh name you entered is in the list of tsrrorist";
                return result;
            }
        }
        return "the name you enterd not in terrorist list";


    }

    public static List<string> TeroristsByWeponType(List<Terrorist> terrorists, string weaponTypeString)
    {
        var terroristsByWeaponType = new List<string>();


        WeaponType weaponEnum = (WeaponType)Enum.Parse(typeof(WeaponType), weaponTypeString, ignoreCase: true);

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





