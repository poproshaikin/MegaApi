using MegaApi.DAL;
using MegaApi.DAL.DataRepositories;
using MegaApi.DAL.DataRepositories.Images;
using MegaApi.DAL.DataRepositories.Products;
using MegaApi.DAL.DataRepositories.Vendors;
using MegaApi.Models;

var builder = WebApplication.CreateBuilder(args);

const string corsOptions = "basicCors";

// jdbc:postgresql://localhost:5432/megadb?password=15112006&user=postgres  << ----- >> do not remove, use to connect IDE 

builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<IRepository<Product>, ProductsRepository>();
builder.Services.AddScoped<IRepository<Image>,   ImagesRepository>();
builder.Services.AddScoped<IRepository<Vendor>,  VendorsRepository>();

builder.Services.AddControllers();
builder.Services.AddCors(options => {
    
    options.AddPolicy(corsOptions, policyBuilder => {
        
        policyBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors(corsOptions);
app.MapControllers();

app.Run();