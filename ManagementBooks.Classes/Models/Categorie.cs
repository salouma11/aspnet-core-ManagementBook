using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementBooks.Classes.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        [Required]
        public string NameCat { get; set; }

        public List<CatLivr> CategoLivres { get; set; } = new List<CatLivr>();
    }
}
