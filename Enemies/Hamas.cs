namespace Enemies
{
    public class Hamas
    {
        public string CommanderName { get; set; }
        public DateTime DateOfFormation { get; set; }
        public List<Terrorist> Terrorists { get; set; }

        public Hamas(string commanderName, DateTime dateOfFormation, List<Terrorist> terrorists)
        {
            CommanderName = commanderName;
            DateOfFormation = dateOfFormation;
            Terrorists = terrorists;
        }
    }
}