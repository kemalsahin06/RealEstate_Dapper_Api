namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmenCount();
        String EmpoloyeeNameByMaxProductCount();
        String CategoryNameByMaxProductCount();
        decimal AverangeProductPriceByRent();
        decimal AverangeProductPriceBySale();
        string CityNameByMaxProductCount();
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuildingYear();
        string OldestBuildingYear();
        int ActiveEmployeeCount();
        int AverangeRoomCount();

    }
}
