using System.Collections.Generic;

namespace Intelligence
{
    public class Aman
    {
        public List<IntelligenceMessage> Messages { get; set; }

        public Aman()
        {
            Messages = new List<IntelligenceMessage>();
        }

        public void AddMessage(IntelligenceMessage message)
        {
            Messages.Add(message);
        }
    }
}
