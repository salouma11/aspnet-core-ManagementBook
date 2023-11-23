using ManagementBooks.Classes.Models;

namespace ManagementBooks.Client.Services.LivreService
{
    public interface ILivreService
    {
        List<Livre> livres { get; set; }
        List<int> catSelected { get; set; }
        Task<List<Livre>> GetAllLivres();

        Task<Livre> GetLivreById(int id);
        Task AddLivre(Livre livre);

        Task AddLivreWithAll(Livre liv);

        Task AddLivreCat(Livre livre, IEnumerable<int> catSelected, ContenueLivre cont);

        //Task UpdateLivre(Livre livre);

        Task UpdateLivreWithCategoriesAsync(Livre request);

        Task DeleteLivre(int id);
    }
}
