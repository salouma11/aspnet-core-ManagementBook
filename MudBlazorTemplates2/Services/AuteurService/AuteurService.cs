using ManagementBooks.Classes.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MudBlazorTemplates2.Services.AuteurService
{
    public class AuteurService : IAuteurService
    {
        private readonly HttpClient _httpClient;

        public List<Auteur> aut { get; set; } = new List<Auteur>();
        public NavigationManager _navigationManager { get; }

        public AuteurService(HttpClient httpClient , NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }


        public async Task<List<Auteur>> GetAllAuteurs()
        {
            return await _httpClient.GetFromJsonAsync<List<Auteur>>("api/Auteur");


        }

        public async Task<Auteur> GetAuteurById(int id)
        {
            var aut = await _httpClient.GetFromJsonAsync<Auteur>($"api/Auteur/{id}");

            return aut;
        }

        public async Task AddAuteur(Auteur auteur)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Auteur", auteur);
            var response = await result.Content.ReadFromJsonAsync<List<Auteur>>();

            aut = response;
            

            _navigationManager.NavigateTo("/AuteurList"); 
        }
    }
}
