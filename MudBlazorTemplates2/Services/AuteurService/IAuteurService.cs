using ManagementBooks.Classes.Models;

namespace MudBlazorTemplates2.Services.AuteurService
{
    public interface IAuteurService
    {
        List<Auteur> aut { get; set; }
        Task<List<Auteur>> GetAllAuteurs();

        Task<Auteur> GetAuteurById(int id);

        Task AddAuteur(Auteur aut);
    }
}
