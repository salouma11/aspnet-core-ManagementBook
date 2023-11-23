using ManagementBooks.Classes.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

namespace MudBlazorTemplates1.Service
{
    public class LivreService : ILivreService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public List<Livre> livres { get; set; } = new List<Livre>();
        public List<int> catSelected { get; set; } = new List<int>();

        public LivreService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;

        }
        public async Task AddLivreCat(Livre livre, List<int> catSelected)
        {
            var requestBody = new
            {
                Livre = livre,
                CatSelected = catSelected
            };

            var result = await _httpClient.PostAsJsonAsync("api/Livres/AddLivreWithCat", requestBody);
            //var result = await _httpClient.PostAsJsonAsync("api/Livre", livre );

            var response = await result.Content.ReadFromJsonAsync<List<Livre>>();

            livres = response;


            _navigationManager.NavigateTo("/LivreList");
        }
    }
}
