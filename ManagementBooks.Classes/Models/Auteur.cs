using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementBooks.Classes.Models
{
    public class Auteur
    {
        public int Id { get; set; }

        [Required]
        public string NameAut { get; set; }

        public List<Livre> Livres { get; set; } 
    }
}
