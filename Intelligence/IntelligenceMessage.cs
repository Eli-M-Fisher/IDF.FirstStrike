namespace Intelligence
{
    public class IntelligenceMessage
    {
        // type string?
        public string TerroristTarget { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
        public int ConfidenceScore { get; set; }

        public IntelligenceMessage(string terrorisTarget, string location, DateTime timestamp, int confidenceScore)
        {
            TerroristTarget = terrorisTarget;
            Location = location;
            Timestamp = timestamp;
            ConfidenceScore = confidenceScore;
        }
    }
}
