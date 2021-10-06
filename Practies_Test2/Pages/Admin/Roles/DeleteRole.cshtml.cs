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
    public class DeleteRoleModel : PageModel
    {
        IPermissionService _permissionService;
        public DeleteRoleModel(IPermissionService permissionService)
        {
            this._permissionService = permissionService;
        }
        [BindProperty]
        public Role Role { get; set; }
        public void OnGet(int id)
        {
            Role = _permissionService.GetRoleById(id);
        }

        public IActionResult OnPost()
        {

            _permissionService.DeleteRole(Role);
            return RedirectToPage("Index");
        }
    }
}
