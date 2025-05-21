
namespace Utils
{
    public static class RandomGenerator
    {
        public static Random _random = new Random();


        public static List<string> teroristName = new List<string>
         { "Achmead ",
            "  abbed",
            "alli",
            "mostaffa",
            "muchammd" };

        private static List<int> ranks = new List<int>
        {
            1, 2, 3, 4, 5
        };


        public static List<string> weapones = new List<string>
        {
            "M16",
            "knife",
            "gun" ,
            "AK47"
        };


        public static List<string> locations = new List<string>
        {
            "car",
            "Home",
            "mosque"
        };


        public static int GetRandomRank()
        {
            int index = _random.Next(ranks.Count);

            return ranks[index];
        }

        public static string GetRandomTeroristName()
        {
            int index = _random.Next(teroristName.Count);

            return teroristName[index];

        }


        
        public static string GetRandomLocation()
        {
            int index = _random.Next(locations.Count);

            return locations[index];

        }
         
         



    }
}

