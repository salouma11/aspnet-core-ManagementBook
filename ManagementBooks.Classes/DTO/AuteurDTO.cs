using ManagementBooks.Classes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementBooks.Classes.DTO
{
    public class AuteurDTO
    {
        public int Id { get; set; }

        [Required]
        public string NameAut { get; set; }

        public List<Livre> Livres { get; set; }
    }
}
