namespace Enemies
{

        public class Terrorist
    {
        public string Name { get; set; }
        public int Rank { get; set; }

        public string Status { get; set; }

        public List<string> Weapons { get; set; }

        // property of last location for aman.
        string LasLtocation { get; set; }




        public Terrorist(string name, int rank, string status, List<string> weaponse, string lastlocation)
        {
            Name = name;
            Rank = rank;
            Status = status;
            Weapons = weaponse;
            LasLtocation = lastlocation;

        }

    }
    
}
