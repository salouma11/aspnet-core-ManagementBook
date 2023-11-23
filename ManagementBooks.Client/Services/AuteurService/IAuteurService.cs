using ManagementBooks.Classes.Models;

namespace ManagementBooks.Client.Services.AuteurService
{
    public interface IAuteurService
    {
        List<Auteur> auteurs { get; set; }
        Task<List<Auteur>> GetAllAuteurs();

        Task<Auteur> GetAuteurById(int id);

        Task AddAuteur(Auteur aut);

        Task UpdateAuteur(Auteur aut);

        Task<List<Auteur>> DeleteAuteur(int id);
    }
}
