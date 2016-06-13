using System.Collections.Generic;

namespace JsonConversion
{
    public class ResultV2
    {
        public string Version { get; set; }
        public Dictionary<string, Product> Products { get; set; }
    }
}