using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDB
{
    class JClass
    {
        public string query { get; set; }
        public IntentScore topScoringIntent { get; set; }
        public List<Intent> intents { get; set; }
        public List<Entities> entities { get; set; }

        public class IntentScore
        {
            public string intent { get; set; }
            public string score { get; set; }
        }

        public class Intent
        {
            public string intent { get; set; }
            public string score { get; set; }
        }

        public class Entities
        {
            public string entity { get; set; }
            public string type { get; set; }
            public string score { get; set; }
        }
    }
}
