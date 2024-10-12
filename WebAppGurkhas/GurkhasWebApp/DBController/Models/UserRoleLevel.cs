using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBController.Models
{
    public enum UserRoleLevel
    {
        Admin = 1,
        AdvancedUser = 2,
        User = 3,
        RestrictedGroup = 4
    }
}
