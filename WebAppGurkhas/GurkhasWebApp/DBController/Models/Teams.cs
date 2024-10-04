using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBController.Models
{
    public class Teams
    {
        [Key]
        public int Team_Id { get; set; }  // ID único e sequencial
        [Required]
        public string Team_Name { get; set; }  // Nome da equipe
        [EmailAddress]
        public string Team_Email { get; set; }  // Email da equipe
        [Phone]
        public string? Team_Phone { get; set; }  // Contacto telefónico (nullable)
        public byte[]? Team_Logo { get; set; }  // Logotipo (BLOB, nullable)
    }
}
