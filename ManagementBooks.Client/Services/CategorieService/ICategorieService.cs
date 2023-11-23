using ManagementBooks.Classes.Models;

namespace ManagementBooks.Client.Services.CategorieService
{
    public interface ICategorieService
    {
        List<Categorie> categories { get; set; }
        Task<List<Categorie>> GetAllCategories();

        Task AddCategorie(Categorie cat);

        Task<Categorie> GetCategorieById(int id);

        Task UpdateCategorie(Categorie categorie);

        Task DeleteCategorie(int id);
    }
}
