using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManagementBooks.Classes.Models
{
    public class Livre
    {

        public int Id { get; set; }

        public string NameLiv { get; set; }

        
        public int? AuteurId { get; set; }
        public Auteur Auteur { get; set; }

       public ContenueLivre ContenueLivre { get; set; }

        public List<CatLivr> CategoLivres { get; set; } = new List<CatLivr>();
       

    }
}
