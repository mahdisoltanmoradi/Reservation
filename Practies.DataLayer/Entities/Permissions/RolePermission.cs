using Practies.DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practies.DataLayer.Entities.Permissions
{
    public class RolePermission
    {
        [Key]
        public int RP_Id { get; set; }
        public int PermissionId { get; set; }
        public int RpleId { get; set; }


        #region Relation
        public Role Roles { get; set; }
        public Permission Permission { get; set; }
        #endregion
    }
}
