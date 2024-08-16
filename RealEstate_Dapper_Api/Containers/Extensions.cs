using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.CardRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper_Api.Repositories.ProductImageRepositories;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.PropertyAminityRepositories;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepositories;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddTransient<Context>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();

            services.AddTransient<IServiceRepository, ServiceRepository>();

            services.AddTransient<IBottomGridRepository, BottomGridRepository>();

            services.AddTransient<IPopularLocationRepositories, PopularLocationRepositories>();

            services.AddTransient<ITestimonialRepository, TestimonialRepository>();

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IStatisticsRepository, StatisticsRepository>();

            services.AddTransient<IContactRepository, ContactRepository>();

            services.AddTransient<IToDoListRepositories, ToDoListRepositories>();

            services.AddTransient<IStatisticRepository, StatisticRepository>();

            services.AddTransient<IChartRepository, ChartRepository>();

            services.AddTransient<ILast5ProductsRepository, Last5ProductsRepository>();

            services.AddTransient<IMessageRepository, MessageRepository>();

            services.AddTransient<IProductImagesRepository, ProductImagesRepository>();

            services.AddTransient<IAppUserRepository, AppUserRepository>();

            services.AddTransient<IPropertyAminityRepository, PropertyAminityRepository>();

            services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();

        }
    }
}
