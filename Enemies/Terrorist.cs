using System.Collections.Generic;
using Core;

namespace Enemies
{
    public class Terrorist
    {
        public string Name { get; set; }
        public int Rank { get; set; } // 1 to 5
        public Status Status { get; set; } // Alive or Dead
        public List<WeaponType> Weapons { get; set; }

        public Terrorist(string name, int rank, Status status, List<WeaponType> weapons)
        {
            Name = name;
            Rank = rank;
            Status = status;
            Weapons = weapons;
        }
    }
}
