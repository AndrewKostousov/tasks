namespace JsonConversion
{
    public class ProductV3
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal? price { get; set; }
        public int? count { get; set; }
        public Dimensions dimensions { get; set; }
    }

    public class Dimensions
    {
        public int l { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }
}