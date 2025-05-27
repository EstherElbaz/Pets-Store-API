using Microsoft.EntityFrameworkCore;
using Services;
using Repository;
using NLog.Web;
using AutoMapper;
using MyFirstWebApiSite.Middleware;
using pets.Midllewares;

var builder = WebApplication.CreateBuilder(args);
string connection = ("Data Source=srv2\\pupils;Initial Catalog=storeWebsite;Integrated Security=True;Pooling=False; TrustServerCertificate = True;");


builder.Host.UseNLog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<storeWebsiteContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("School")));

builder.Host.UseNLog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();


//midllwares
//app.UseErrorHandlingMidllware();

app.UseCachingMiddleware();

app.UseRatingMidlleware();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseDefaultFiles();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();