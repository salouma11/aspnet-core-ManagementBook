using ManagementBooks.Client;
using ManagementBooks.Client.Services.AuteurService;
using ManagementBooks.Client.Services.CategorieService;
using ManagementBooks.Client.Services.LivreService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
//using static MudBlazor.CategoryTypes;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IAuteurService, AuteurService>();
builder.Services.AddScoped<ILivreService, LivreService>();
builder.Services.AddScoped<ICategorieService, CategorieService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7086/") });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
