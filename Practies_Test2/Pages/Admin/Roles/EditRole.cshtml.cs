using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practies.Core.Services.Interface;
using Practies.DataLayer.Entities.Users;

namespace Practies_Test2.Pages.Admin.Roles
{
    public class EditRoleModel : PageModel
    {
        IPermissionService _permissionService;
        public EditRoleModel(IPermissionService permissionService)
        {
            this._permissionService = permissionService;
        }
        [BindProperty]
        public Role Role { get; set; }
        public void OnGet(int id)
        {
            Role = _permissionService.GetRoleById(id);
            ViewData["Permissions"] = _permissionService.GetAllPermission();
            ViewData["SelectedPermission"] = _permissionService.PermissionRole(id);
        }

        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if(!ModelState.IsValid)
                return Page();
            

            _permissionService.UpdateRole(Role);
            _permissionService.UpdatePermission(Role.RoleId, SelectedPermission);

            return RedirectToPage("Index");
        }
    }
}
