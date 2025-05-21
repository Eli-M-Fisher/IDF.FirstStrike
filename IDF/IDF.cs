

using System.Collections.Generic;
using IDF.StrikeUnits;

namespace IDF
{
    public class IDF
    {
        public string CommanderName { get; private set; }
        public string EstablishedDate { get; private set; }
        public List<IStrikeUnit> StrikeUnits { get; private set; }

        public IDF(string commanderName, string establishedDate)
        {
            CommanderName = commanderName;
            EstablishedDate = establishedDate;
            StrikeUnits = new List<IStrikeUnit>();
        }

        public void AddStrikeUnit(IStrikeUnit unit)
        {
            StrikeUnits.Add(unit);
        }

        public string ReportAllUnits()
        {
            var report = $"IDF Commander: {CommanderName} | Established: {EstablishedDate}\n";
            foreach (var unit in StrikeUnits)
            {
                report += unit.ReportStatus() + "\n";
            }
            return report;
        }
    }
}