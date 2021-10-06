using Practies.DataLayer.Entities.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practies.DataLayer.Entities.Users
{
    public class Role
    {
        public Role()
        {

        }

        [Key]
        public int RoleId { get; set; }

        [Display(Name = ("نقش کاربر"))]
        public string RoleTitle { get; set; }

        public bool IsDelete { get; set; }

        #region Relations
        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<RolePermission> RolePermissions { get; set; }
        #endregion

    }


}
