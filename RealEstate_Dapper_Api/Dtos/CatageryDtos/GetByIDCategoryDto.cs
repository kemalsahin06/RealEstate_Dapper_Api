namespace RealEstate_Dapper_Api.Dtos.CatageryDtos
{
    public class GetByIDCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
