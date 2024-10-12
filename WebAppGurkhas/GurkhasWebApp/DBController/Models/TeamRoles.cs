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
        public int TeamRole_Id { get; set; }  // ID único e sequencial

        [Required]
        public string TeamRole_Name { get; set; }  // Nome do role

        [Required]
        public TeamRoleLevel TeamRole_Level { get; set; }  // Enum para o nível do role
    }
}
