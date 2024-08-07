namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string title { get; set; }
        public int price { get; set; }
        public string city { get; set; }
        public string coverImage { get; set; }
        public string address { get; set; }
        public string desciription { get; set; }
        public string type { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime AdvertisementDate { get; set; }

        public string district { get; set; }
        public bool productStatus { get; set; }
        public int ProductCategory { get; set; }
        public int EmployeeID { get; set; }
    }
}
