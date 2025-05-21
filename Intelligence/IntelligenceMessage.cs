using System;
using Enemies;

namespace Intelligence
{
    public class IntelligenceMessage
    {
        public Terrorist TerroristTarget { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
        public int ConfidenceScore { get; set; }

        public IntelligenceMessage(Terrorist terroristTarget, string location, DateTime timestamp, int confidenceScore)
        {
            TerroristTarget = terroristTarget;
            Location = location;
            Timestamp = timestamp;
            ConfidenceScore = confidenceScore;
        }
    }
}
