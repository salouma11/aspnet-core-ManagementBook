using ManagementBooks.API.Data;
using ManagementBooks.Classes.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementBooks.API.Services.CategorieService
{
    public class CategorieService : ICategorieService
    {
        private readonly DataContext _context;

        public CategorieService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Categorie>> AddCategorie(Categorie cat)
        {
            _context.Categories.Add(cat);
            await _context.SaveChangesAsync();

            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Categorie>> DeleteCategorie(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat is null)
            {
                return null;
            }


            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Categorie>> GetAllCategorie()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Categorie> GetCategorieById(int id)
        {
            var cat = await _context.Categories.FirstOrDefaultAsync(a => a.Id == id);

            if (cat is null)
            {
                return null;
            }
            return cat;
        }

        public async Task<List<Categorie>> UpdateCategorie(int id, Categorie request)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat is null)
            {
                return null;
            }

            cat.NameCat = request.NameCat;
            


            await _context.SaveChangesAsync();

            return await _context.Categories.ToListAsync();
        }
    }
}
