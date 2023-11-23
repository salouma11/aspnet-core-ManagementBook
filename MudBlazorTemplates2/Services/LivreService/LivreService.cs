using ManagementBooks.Classes.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;


namespace MudBlazorTemplates2.Services.LivreService
{
    public class LivreService : ILivreService
    {
        private readonly HttpClient _httpClient;
        private  readonly NavigationManager _navigationManager;

        public List<Livre> livres { get; set; } = new List<Livre>();
        public List<int> catSelected { get; set; } = new List<int>();

        public LivreService(HttpClient httpClient , NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;

        }

        public async Task<List<Livre>> GetAllLivres()
        {
            return await _httpClient.GetFromJsonAsync<List<Livre>>("api/Livre");
        }

        public async Task AddLivre(Livre livre)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Livre", livre);
            
            var response = await result.Content.ReadFromJsonAsync<List<Livre>>();

            livres = response;


            _navigationManager.NavigateTo("/LivreList");
        }

        public async Task AddLivreCat(Livre livre, IEnumerable<int> catSelected , ContenueLivre cont)
        {
            var requestBody = new
            {
                Livre = livre,
                CatSelected = catSelected,
                Cont=cont
            };

            var result = await _httpClient.PostAsJsonAsync("api/Livre", requestBody);
            //var result = await _httpClient.PostAsJsonAsync("api/Livre", livre );

            var response = await result.Content.ReadFromJsonAsync<List<Livre>>();

            livres = response;


            _navigationManager.NavigateTo("/LivreList");
        }

        public async Task<Livre> GetLivreById(int id)
        {
            var livre = await _httpClient.GetFromJsonAsync<Livre>($"api/Livre/{id}");

            return livre;
        }

        public async Task UpdateLivre(Livre livre)
        {
          
                var result = await _httpClient.PutAsJsonAsync($"api/Livre/{livre.Id}", livre);
                var response = await result.Content.ReadFromJsonAsync<List<Livre>>();

                livres = response;
                _navigationManager.NavigateTo("/LivreList");
            
        }

        public async Task DeleteLivre(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Livre/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<Livre>>();

            livres = response;
           

            _navigationManager.NavigateTo("/LivreList");
        }

        //public Task AddLivreCat(Livre livre, List<int> catSelected)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
