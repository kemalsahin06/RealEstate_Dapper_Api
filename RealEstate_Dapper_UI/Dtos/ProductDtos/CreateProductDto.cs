﻿namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public int productID { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string categoryID { get; set; }
        public string coverImage { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
    }
}
