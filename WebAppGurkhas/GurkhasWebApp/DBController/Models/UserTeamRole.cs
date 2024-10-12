using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBController.Models
{
    public class UserTeamRole
    {
        [Key]
        public int Id { get; set; }  // ID único e sequencial

        [Required]
        public int User_Id { get; set; }  // ID do usuário
        public Users User { get; set; }  // Propriedade de navegação para o usuário

        [Required]
        public int Team_Id { get; set; }  // ID da equipe
        public Teams Team { get; set; }  // Propriedade de navegação para a equipe

        [Required]
        public int TeamRole_Id { get; set; }  // ID do papel na equipe
        public TeamRoles TeamRole { get; set; }  // Propriedade de navegação para o role
    }
}
