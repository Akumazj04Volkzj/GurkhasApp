using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBController.Models
{
    public class Users
    {
        [Key]
        public int User_Id { get; set; }  // ID único e sequencial
        [Required]
        public string User_Name { get; set; }  // Nome do utilizador
        [EmailAddress]
        public string User_Email { get; set; }  // Email do utilizador
        [Phone]
        public string? User_PhoneNumber { get; set; }  // Contacto telefónico (nullable)
        // Relacionamento opcional com a equipe (nullable)
        public int? User_TeamId { get; set; }
        public Teams? User_Team { get; set; }  // Propriedade de navegação para a entidade Team
    }
}
