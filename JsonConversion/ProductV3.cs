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
        public decimal l { get; set; }
        public decimal w { get; set; }
        public decimal h { get; set; }
    }
}