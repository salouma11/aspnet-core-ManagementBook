using ManagementBooks.Classes.Models;

namespace ManagementBooks.API.Services.AuteurService
{
    public interface IAuteurService
    {
        Task<List<Auteur>> GetAllAuteur();

        Task<Auteur> GetAuteurById(int id);

        Task<List<Auteur>> AddAuteur(Auteur aut);

        Task<List<Auteur>> UpdateAuteur(int id, Auteur request);

        Task<List<Auteur>> DeleteAuteur(int id);
    }
}
