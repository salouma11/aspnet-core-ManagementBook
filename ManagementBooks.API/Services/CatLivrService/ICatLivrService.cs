using ManagementBooks.Classes.Models;

namespace ManagementBooks.API.Services.CatLivrService
{
    public interface ICatLivrService
    {
        Task<List<CatLivr>> GetAllCateLivr();
    }
}
