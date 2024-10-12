using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBController.Models
{
    public class UserRoles
    {
        [Key]
        public int UserRole_Id { get; set; }  // ID único e sequencial

        [Required]
        public string UserRole_Name { get; set; }  // Nome do role (ex: "Admin", "User")

        [Required]
        public UserRoleLevel UserRole_Level { get; set; }  // Enum para o nível do role
    }
}
