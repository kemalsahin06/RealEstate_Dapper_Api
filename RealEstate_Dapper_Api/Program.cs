using RealEstate_Dapper_Api.Containers;
using RealEstate_Dapper_Api.Hubs;
using RealEstate_Dapper_Api.Models.DapperContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.ContainerDependencies();


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
