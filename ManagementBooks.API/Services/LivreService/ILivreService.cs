using ManagementBooks.Classes.Models;

namespace ManagementBooks.API.Services.LivreService
{
    public interface ILivreService
    {
        Task<List<Livre>> GetAllLivre();

        //Task<List<Livre>> AddLivre(Livre aut);

        //Task<List<Livre>>  AddLivreWithCategoriesAsync(Livre livre, List<int> categoryIds , ContenueLivre cont);

        Task<List<Livre>> AddLivreWithAll(Livre liv);
        Task<List<Livre>> UpdateLivreWithCategoriesAsync(int id, Livre request);

        Task<Livre> GetLivreById(int id);

        //Task<List<Livre>> UpdateLivre(int id, Livre request);

        Task<List<Livre>> DeleteLivre(int id);
    }
}
