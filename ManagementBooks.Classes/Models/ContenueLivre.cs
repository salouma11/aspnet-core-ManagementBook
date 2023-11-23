using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementBooks.Classes.Models
{
    public class ContenueLivre
    {
        //public ContenueLivre(int nbrPages, string contenue, int livreId)
        //{
        //    NbrPages = nbrPages;
        //    Contenue = contenue;
        //    LivreId = livreId;
        //}

        public int Id { get; set; }
        public int NbrPages { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Contenue { get; set; }

        public Livre livre { get; set; }

        public int LivreId { get; set; }
    }
}
