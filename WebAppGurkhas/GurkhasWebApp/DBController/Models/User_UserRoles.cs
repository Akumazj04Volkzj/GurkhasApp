using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBController.Models
{
    public class User_UserRoles
    {
        [Key]
        public int Id { get; set; }  // ID único e sequencial

        [Required]
        public int User_Id { get; set; }  // ID do utilizador
        public Users User { get; set; }  // Propriedade de navegação para o usuário

        [Required]
        public int UserRole_Id { get; set; }  // ID do papel de utilizador
        public UserRoles UserRole { get; set; }  // Propriedade de navegação para o role de utilizador
    }
}
