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
    public class CreateRoleModel : PageModel
    {
        IPermissionService _permissionService;

        public CreateRoleModel(IPermissionService permissionService)
        {
            this._permissionService = permissionService;
        }
        [BindProperty]
        public Role Role { get; set; }
        public void OnGet()
        {
            ViewData["Permissions"] = _permissionService.GetAllPermission();
        }

        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Role.IsDelete = false;
            int roleId = _permissionService.AddRole(Role);
            _permissionService.AddPermissionToRole(roleId, SelectedPermission);


            return RedirectToPage("Index");
        }
    }
}
