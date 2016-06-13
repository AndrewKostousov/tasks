using System.Collections.Generic;

namespace JsonConversion
{
    public class ResultV2
    {
        public string Version { get; set; }
        public Dictionary<string, string> Constants { get; set; }
        public Dictionary<string, ProductV2> Products { get; set; }
    }
}