namespace Enemies
{
    public class Hamas
    {
        public string CommanderName { get; set; }

        // mשybe latter we will change the type of this prpoperty
        public string DateOfFormition { get; set; }

        public List<Terorrist> Terorrists { get; set; }

        public Hamas(string commanderName, string dateOfFormition, List<Terorrist> terorist)
        {
            CommanderName = commanderName;
            DateOfFormition = dateOfFormition;
            Terorrists = terorist;
        }
    }
}