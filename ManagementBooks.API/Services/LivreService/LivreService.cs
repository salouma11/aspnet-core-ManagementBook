using ManagementBooks.API.Data;
using ManagementBooks.Classes.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ManagementBooks.API.Services.LivreService
{
    public class LivreService : ILivreService
    {
        private readonly DataContext _context;

        public LivreService(DataContext context)
        {
            _context = context;

        }


        public async Task<List<Livre>> GetAllLivre()
        {

            //var a = await _context.Livres.Include(a => a.Auteur).ToListAsync();
            return await _context.Livres.Include(a=>a.Auteur).ToListAsync();

        }

        public async Task<List<Livre>> AddLivre(Livre livre)
        {
            _context.Livres.Add(livre);

            await _context.SaveChangesAsync();

            return await _context.Livres.ToListAsync();
        }
        //public async Task<List<Livre>> AddLivreWithCategoriesAsync(Livre livre, List<int> categoryIds, ContenueLivre cont)
        //{
            
        //    _context.Livres.Add(livre);
        //    await _context.SaveChangesAsync();

        //    //ContenueLivre cont1 = new ContenueLivre(cont.NbrPages, cont.Contenue, livre.Id);

        //    //_context.ContenueLivres.Add(cont1);

        //    await _context.SaveChangesAsync();

        //    foreach (var i in categoryIds)
        //    {
                
        //        CatLivr c = new CatLivr(livre.Id, i);
        //        _context.CatLivrs.Add(c);
        //        await _context.SaveChangesAsync();
        //    }



        //    return await  _context.Livres.ToListAsync();
        //}

        public async Task<List<Livre>> AddLivreWithAll(Livre liv)
        {
            _context.Livres.Add(liv);
            await _context.SaveChangesAsync();

            
            return await _context.Livres.ToListAsync();

        }

        public async Task<Livre> GetLivreById(int id)
        {
            var livre = await _context.Livres.Include(_ => _.Auteur).Include(_ => _.ContenueLivre).Include(_ => _.CategoLivres).FirstOrDefaultAsync(a => a.Id == id);

            if (livre is null)
            {
                return null;
            }
            return livre;
        }

        //public async Task<List<Livre>> UpdateLivre(int id, Livre request)
        //{
        //    var livre = await _context.Livres.FindAsync(id);
            
        //    if (livre is null)
        //    {
        //        return null;
        //    }

        //    livre.NameLiv = request.NameLiv;
        //    livre.AuteurId = request.AuteurId;

        //    var l = livre;


        //    await _context.SaveChangesAsync();

        //    return await _context.Livres.ToListAsync();
        //}


        public async Task<List<Livre>> UpdateLivreWithCategoriesAsync(int id, Livre request)
        {
            var livre = await _context.Livres.Include(l=>l.ContenueLivre).Include(l => l.CategoLivres).FirstOrDefaultAsync(l=>l.Id==id);



            if (livre is null)
            {
                return null;
            }

            livre.NameLiv = request.NameLiv;
            livre.AuteurId = request.AuteurId;


            livre.ContenueLivre.Contenue = request.ContenueLivre.Contenue;

            livre.CategoLivres.Clear();

            await _context.Database.ExecuteSqlRawAsync("delete from categ where idlive = @idlive", new SqlParameter("@idlive", id));

            var a = request.CategoLivres;

            livre.ContenueLivre.NbrPages = request.ContenueLivre.NbrPages;

            foreach (var newCatLivr in livre.CategoLivres)
            {
       

                bool idCategorieExists = request.CategoLivres.Any(cl => cl.CategorieId == newCatLivr.CategorieId);

                if (!idCategorieExists)
                {
                    var catLiv1 = _context.CatLivrs.FirstOrDefault(c => c.CategorieId == newCatLivr.CategorieId);
                    _context.CatLivrs.Remove(catLiv1);

                }

            }

            foreach (var newCatLivr in request.CategoLivres)
            {
              

                bool idCategorieExists = livre.CategoLivres.Any(cl => cl.CategorieId == newCatLivr.CategorieId);

                if (!idCategorieExists)
                {
                    CatLivr catlivr1 = new CatLivr(livre.Id, newCatLivr.CategorieId);
                    _context.CatLivrs.Add(catlivr1);
                   
                }


            }

        

            await _context.SaveChangesAsync();

            return await _context.Livres.ToListAsync();
        }


        public async Task<List<Livre>> DeleteLivre(int id)
        {
            var livre = await _context.Livres.FindAsync(id);
            if (livre is null)
            {
                return null;
            }

            //SuperHeros.Remove(hero);
            _context.Livres.Remove(livre);
            await _context.SaveChangesAsync();
            return await _context.Livres.ToListAsync();
        }

       
    }
}
