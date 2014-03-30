using System.Collections.Generic;

namespace MerchantsGuide.Models
{
    public class Variables
    {
        public IDictionary<string, string> QuestionsAndAnswers { get; set; }
        public IDictionary<string, string> IntergalacticMissingValues { get; set; }
        public IDictionary<string, string> IntergalacticRomanValues { get; set; }
        public IDictionary<string, double> IntergalacticDecimalValues { get; set; }
        public IDictionary<string, double> ElementValues { get; set; }

        public Variables()
        {
            QuestionsAndAnswers = new Dictionary<string, string>();
            IntergalacticMissingValues = new Dictionary<string, string>();
            IntergalacticRomanValues = new Dictionary<string, string>();
            IntergalacticDecimalValues = new Dictionary<string, double>();
            ElementValues = new Dictionary<string, double>();
        }
    }
}