using ManagementBooks.Classes.Models;

namespace MudBlazorTemplates2.Services.LivreService
{
    public interface ILivreService
    {
        List<Livre> livres { get; set; }
        List<int> catSelected { get; set; }
        Task<List<Livre>> GetAllLivres();

        Task<Livre> GetLivreById(int id);
        Task AddLivre(Livre livre);

        Task AddLivreCat(Livre livre , IEnumerable<int> catSelected, ContenueLivre cont);

        Task UpdateLivre(Livre livre);

        Task DeleteLivre(int id);
    }
}
