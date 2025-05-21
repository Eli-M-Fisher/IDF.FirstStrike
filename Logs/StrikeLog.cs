

using System;
using System.Collections.Generic;
using Enemies;

namespace Logs
{
    public class StrikeLogEntry
    {
        public Terrorist Target { get; set; }
        public string OfficerName { get; set; }
        public string UnitName { get; set; }
        public DateTime TimeOfStrike { get; set; }
        public bool WasSuccessful { get; set; }
        public string AdditionalNotes { get; set; }

        public StrikeLogEntry(Terrorist target, string officerName, string unitName, DateTime timeOfStrike, bool wasSuccessful, string additionalNotes)
        {
            Target = target;
            OfficerName = officerName;
            UnitName = unitName;
            TimeOfStrike = timeOfStrike;
            WasSuccessful = wasSuccessful;
            AdditionalNotes = additionalNotes;
        }

        public override string ToString()
        {
            string status = WasSuccessful ? "Success" : "Failed";
            return $"{TimeOfStrike}: {UnitName} targeted {Target.Name} | Officer: {OfficerName} | Status: {status} | Notes: {AdditionalNotes}";
        }
    }

    public class StrikeLog
    {
        private readonly List<StrikeLogEntry> _entries;

        public StrikeLog()
        {
            _entries = new List<StrikeLogEntry>();
        }

        public void AddEntry(StrikeLogEntry entry)
        {
            _entries.Add(entry);
        }

        public string GenerateReport()
        {
            if (_entries.Count == 0)
                return "No strikes recorded.";

            string report = "=== Strike Log Report ===\n";
            foreach (var entry in _entries)
            {
                report += entry.ToString() + "\n";
            }
            return report;
        }
    }
}