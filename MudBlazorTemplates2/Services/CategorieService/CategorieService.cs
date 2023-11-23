using ManagementBooks.Classes.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MudBlazorTemplates2.Services.CategorieService
{
    public class CategorieService : ICategorieService
    {
        public List<Categorie> categories { get; set; } = new List<Categorie>();

        private readonly HttpClient _httpClient;
        public NavigationManager _navigationManager { get; }
        

        public CategorieService(HttpClient httpClient , NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }
        public async Task<List<Categorie>> GetAllCategories()
        {
            return await _httpClient.GetFromJsonAsync<List<Categorie>>("api/Categorie");
        }

        public async Task AddCategorie(Categorie cat)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Categorie", cat);
            var response = await result.Content.ReadFromJsonAsync<List<Categorie>>();
            categories = response;


            _navigationManager.NavigateTo("/categorieList");
        }

        public async Task<Categorie> GetCategorieById(int id)
        {
            var cat = await _httpClient.GetFromJsonAsync<Categorie>($"api/Categorie/{id}");

            return cat;
        }

        public async Task UpdateCategorie(Categorie categorie)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Categorie/{categorie.Id}", categorie);
            var response = await result.Content.ReadFromJsonAsync<List<Categorie>>();

            categories = response;
            _navigationManager.NavigateTo("/CategorieList");
        }

        public async Task DeleteCategorie(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Categorie/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<Categorie>>();

            categories = response;
            //heros = await _httpClient.PostAsJsonAsync("api/SuperHero", superHero).Result.Content.ReadFromJsonAsync<List<SuperHero>>();

            _navigationManager.NavigateTo("/CategorieList");
        }
    }
}
