using Practies.Core.Services.Interface;
using Practies.DataLayer.Context;
using Practies.DataLayer.Entities.Permissions;
using Practies.DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practies.Core.Services
{
    public class PermissionService : IPermissionService
    {
        PractiesContext _context;
        public PermissionService(PractiesContext context)
        {
            this._context = context;
        }

        public void AddPermissionToRole(int roleId, List<int> permission)
        {
            foreach (var p in permission)
            {
                _context.RolePermissions.Add(new RolePermission
                {
                    PermissionId = p,
                    RpleId = roleId
                });
            }
            _context.SaveChanges();
        }

        public int AddRole(Role role)
        {
            _context.Add(role);
            _context.SaveChanges();
            return role.RoleId;
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (var rolesId in roleIds)
            {
                _context.UserRoles.Add(new UserRole
                {
                    RoleId = rolesId,
                    UserId = userId
                });

            }
            _context.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            _context.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            var role = GetRoleById(id);
            DeleteRole(role);
        }

        public void EditRolesUser(int userId, List<int> rolesId)
        {
            _context.UserRoles.Where(r => r.UserId == userId).ToList().ForEach(r => _context.UserRoles.Remove(r));

            AddRolesToUser(rolesId, userId);

        }

        public List<Permission> GetAllPermission()
        {
            return _context.Permissions.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public List<int> PermissionRole(int roleId)
        {
            return _context.RolePermissions.Where(p => p.RpleId == roleId)
               .Select(p => p.PermissionId).ToList();
        }

        public void UpdatePermission(int roleId, List<int> permissions)
        {
            _context.RolePermissions.Where(p => p.RpleId == roleId).ToList()
               .ForEach(p => _context.RolePermissions.Remove(p));

            AddPermissionToRole(roleId, permissions);
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void UpdateRole(int roleId, Role role)
        {
            var model = GetRoleById(roleId);
            model.IsDelete = role.IsDelete;
            model.RoleTitle = role.RoleTitle;
            _context.Update(model);
            _context.SaveChanges();

        }
    }
}
