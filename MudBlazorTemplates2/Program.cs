using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudBlazorTemplates2;
using MudBlazorTemplates2.Services.AuteurService;
using MudBlazorTemplates2.Services.CategorieService;
using MudBlazorTemplates2.Services.LivreService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IAuteurService, AuteurService>();
builder.Services.AddScoped<ILivreService, LivreService>();
builder.Services.AddScoped<ICategorieService, CategorieService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7086/") });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
