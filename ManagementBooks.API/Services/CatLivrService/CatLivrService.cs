using ManagementBooks.API.Data;
using ManagementBooks.Classes.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementBooks.API.Services.CatLivrService
{
    public class CatLivrService : ICatLivrService
    {
        private readonly DataContext _context;

        public CatLivrService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<CatLivr>> GetAllCateLivr()
        {
            return await _context.CatLivrs.Include(_ => _.Categorie).Include(_=>_.Livre).ToListAsync();
        }
    }
}
