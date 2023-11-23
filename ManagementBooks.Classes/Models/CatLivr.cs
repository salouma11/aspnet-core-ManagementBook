using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementBooks.Classes.Models
{
    public class CatLivr
    {
        // private int id;

        public CatLivr(int LivreId, int CategorieId)
        {
            this.LivreId = LivreId;
            this.CategorieId = CategorieId;
        }


        public int LivreId { get; set; }
        public int CategorieId { get; set; }


        public Livre Livre { get; set; }
        public Categorie Categorie { get; set; }

       
    }
}
