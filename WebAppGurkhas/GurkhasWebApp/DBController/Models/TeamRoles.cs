using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBController.Models
{
    public class TeamRoles
    {
        [Key]
        public int Role_Id { get; set; }  // ID único e sequencial

        [Required]
        public string Role_Name { get; set; }  // Nome do role

        [Required]
        public TeamRoleLevel Role_Level { get; set; }  // Enum para o nível do role
    }
}
