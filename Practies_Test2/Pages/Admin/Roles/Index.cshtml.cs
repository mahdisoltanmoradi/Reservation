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
    public class IndexModel : PageModel
    {
        IPermissionService _permissionService;
        public IndexModel(IPermissionService permissionService)
        {
            this._permissionService = permissionService;
        }
        public List<Role> Role { get; set; }

        public void OnGet()
        {
            Role = _permissionService.GetRoles();
        }


    }
}
