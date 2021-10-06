using Practies.Core.DTOs.User;
using Practies.DataLayer.Entities.Permissions;
using Practies.DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practies.Core.Services.Interface
{
    public interface IPermissionService
    {
        #region Roles
        List<Role> GetRoles();
        Role GetRoleById(int roleId);
        void UpdateRole(Role role);
        void UpdateRole(int roleId, Role role);
        void DeleteRole(Role role);
        void DeleteRole(int id);
        int AddRole(Role role);
        void AddRolesToUser(List<int> roleIds,int userId);
        void EditRolesUser(int userId, List<int> rolesId);
       
        #endregion

        #region Permission
        List<Permission> GetAllPermission();
        void AddPermissionToRole(int roleId, List<int> permission);
        List<int> PermissionRole(int roleId);
        void UpdatePermission(int roleId, List<int> permissions);
        #endregion
    }
}
