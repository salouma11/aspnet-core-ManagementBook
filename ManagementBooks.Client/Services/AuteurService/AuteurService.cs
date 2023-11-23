using ManagementBooks.Classes.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;


namespace ManagementBooks.Client.Services.AuteurService
{
    public class AuteurService : IAuteurService
    {
        private readonly HttpClient _httpClient;

        public List<Auteur> auteurs { get; set; } = new List<Auteur>();
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

            auteurs = response;
            

            _navigationManager.NavigateTo("/AuteurList"); 
        }

        public async Task UpdateAuteur(Auteur aut)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Auteur/{aut.Id}", aut);
            var response = await result.Content.ReadFromJsonAsync<List<Auteur>>();

            auteurs = response;
            _navigationManager.NavigateTo("/AuteurList");
        }

        public async Task<List<Auteur>> DeleteAuteur(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Auteur/{id}");

            if (!result.IsSuccessStatusCode)
            {
                // Handle the case where associated Livres prevent deletion
                if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    //throw new InvalidOperationException("Auteur has associated Livres. Delete them first.");
                    return new List<Auteur>();
                }
                // Handle other error cases if needed

                // Return null or an empty list or handle the error as appropriate
                return null;
            }

            var response = await result.Content.ReadFromJsonAsync<List<Auteur>>();
            return response;
        }

 
    }
}
