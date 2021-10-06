using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practies.Core.DTOs.User
{
   public class RolesViewModel
    {
        [Display(Name = ("نقش کاربر"))]
        public string RoleTitle { get; set; }

        public bool IsDelete { get; set; }
    }
}
