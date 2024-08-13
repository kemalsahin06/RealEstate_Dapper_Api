using RealEstate_Dapper_Api.Hubs;
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
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();

builder.Services.AddTransient<IServiceRepository, ServiceRepository>();

builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();

builder.Services.AddTransient<IPopularLocationRepositories, PopularLocationRepositories>();

builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();

builder.Services.AddTransient<IContactRepository, ContactRepository>();

builder.Services.AddTransient<IToDoListRepositories, ToDoListRepositories>();

builder.Services.AddTransient<IStatisticRepository, StatisticRepository>();

builder.Services.AddTransient<IChartRepository, ChartRepository>();

builder.Services.AddTransient<ILast5ProductsRepository, Last5ProductsRepository>();

builder.Services.AddTransient<IMessageRepository, MessageRepository>();

builder.Services.AddTransient<IProductImagesRepository, ProductImagesRepository>();

builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();

builder.Services.AddTransient<IPropertyAminityRepository, PropertyAminityRepository>();




// signalR KULLANIRKEN D�GER KULLANICILARA ketki izni veriyoruz

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});


builder.Services.AddHttpClient();// bunuda ekledim
builder.Services.AddSignalR();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy"); // signal ar � burda �ag�rd�k

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// SignalR Hub mapping
app.MapHub<SignalRHub>("/Hubs/SignalRHub");// signalr yap�land�rma direkt istekte bulunmak i�in

app.Run();
