using ManagementBooks.API.Data;
using ManagementBooks.Classes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ManagementBooks.API.Services.AuteurService
{
    public class AuteurService : IAuteurService
    {
        private readonly DataContext _context;

        public AuteurService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Auteur>> AddAuteur(Auteur aut)
        {
            _context.Auteurs.Add(aut);
            await _context.SaveChangesAsync();
            
            return await _context.Auteurs.ToListAsync();
        }

        public async Task<List<Auteur>> DeleteAuteur(int id)
        {
            var aut = await _context.Auteurs.FindAsync(id);
            if (aut is null)
            {
                return null;
            }

            List<Livre> auteursLivres = await _context.Livres.Where(a => a.AuteurId == id).ToListAsync();

            if (auteursLivres.Count > 0)
            {
                return new List<Auteur>();
            }
            

            _context.Auteurs.Remove(aut);
            await _context.SaveChangesAsync();
            return await _context.Auteurs.ToListAsync();
        }

        public async Task<List<Auteur>> GetAllAuteur()
        {

            return await _context.Auteurs.Include(_ => _.Livres).ToListAsync();

        }

        public async Task<Auteur> GetAuteurById(int id)
        {
            var auteur = await _context.Auteurs.Include(_=>_.Livres).FirstOrDefaultAsync(a => a.Id == id);

            if (auteur is null)
            {
                return null;
            }
            return auteur;

        }

        public async Task<List<Auteur>> UpdateAuteur(int id, Auteur request)
        {
            var auteur = await _context.Auteurs.FindAsync(id);
            if (auteur is null)
            {
                return null;
            }

            auteur.NameAut = request.NameAut;


            await _context.SaveChangesAsync();

            return await _context.Auteurs.ToListAsync();
        }


       

    }
}
