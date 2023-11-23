using ManagementBooks.Classes.Models;

namespace ManagementBooks.API.Services.LivreService
{
    public class LiverServiceMongo : ILivreService
    {
        public Task<List<Livre>> AddLivreWithAll(Livre liv)
        {
            throw new NotImplementedException();
        }

        public Task<List<Livre>> DeleteLivre(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Livre>> GetAllLivre()
        {
            throw new NotImplementedException();
        }

        public Task<Livre> GetLivreById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Livre>> UpdateLivreWithCategoriesAsync(int id, Livre request)
        {
            throw new NotImplementedException();
        }
    }
}
