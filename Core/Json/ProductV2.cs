﻿namespace Core.Json
{
    public class ProductV2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public int? count { get; set; }
        public decimal[] size { get; set; }
    }
}