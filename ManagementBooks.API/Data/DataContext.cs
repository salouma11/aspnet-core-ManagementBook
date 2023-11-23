using ManagementBooks.Classes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;


namespace ManagementBooks.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Auteur> Auteurs { get; set; } 
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<CatLivr> CatLivrs { get; set; }

        public DbSet<Client> clients { get; set; }

        public DbSet<ContenueLivre>? ContenueLivres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Livre>()
            .HasOne(l => l.ContenueLivre)
            .WithOne(c => c.livre)
            .HasForeignKey<ContenueLivre>(c => c.LivreId);


            modelBuilder.Entity<Auteur>()
                .HasMany(a => a.Livres)
                .WithOne(l => l.Auteur)
                .HasForeignKey(l => l.AuteurId);

            // Many-to-many relationship between Livre and Categorie through CatLivr
            modelBuilder.Entity<CatLivr>()
                .HasKey(cl => new { cl.LivreId, cl.CategorieId });

            modelBuilder.Entity<CatLivr>()
                .HasOne(cl => cl.Livre)
                .WithMany(l => l.CategoLivres)
                .HasForeignKey(cl => cl.LivreId);


            modelBuilder.Entity<CatLivr>()
               .HasOne(cl => cl.Categorie)
               .WithMany(l => l.CategoLivres)
               .HasForeignKey(cl => cl.CategorieId);

        }

    }
}
