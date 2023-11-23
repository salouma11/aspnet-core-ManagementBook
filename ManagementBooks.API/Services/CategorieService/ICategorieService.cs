using ManagementBooks.Classes.Models;

namespace ManagementBooks.API.Services.CategorieService
{
    public interface ICategorieService
    {
        Task<List<Categorie>> GetAllCategorie();

        Task<Categorie> GetCategorieById(int id);

        Task<List<Categorie>> AddCategorie(Categorie cat);

        Task<List<Categorie>> UpdateCategorie(int id, Categorie request);

        Task<List<Categorie>> DeleteCategorie(int id);
    }
}
