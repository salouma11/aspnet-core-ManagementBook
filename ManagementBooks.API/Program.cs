using ManagementBooks.API.Data;
using ManagementBooks.API.Services.AuteurService;
using ManagementBooks.API.Services.CategorieService;
using ManagementBooks.API.Services.CatLivrService;
using ManagementBooks.API.Services.LivreService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuteurService, AuteurService>();
builder.Services.AddScoped<ILivreService, LivreService>();
builder.Services.AddScoped<ICategorieService, CategorieService>();
builder.Services.AddScoped<ICatLivrService, CatLivrService>();

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");

if (!builder.Environment.IsDevelopment())
{
    var servername = "192.168.1.1";
    ConnectionStrings.Replace("@SERVER", servername);

}

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(ConnectionStrings));

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
