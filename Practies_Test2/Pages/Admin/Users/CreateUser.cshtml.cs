using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practies.Core.DTOs;
using Practies.Core.Services.Interface;

namespace Practies_Test2.Pages.Admin.Users
{
    public class CreateUserModel : PageModel
    {
        IUserService _userService;
        IPermissionService _permissionService;
        
        public CreateUserModel(IUserService userService,IPermissionService permissionService)
        {
            this._userService = userService;
            this._permissionService = permissionService;
        }

        [BindProperty]
        public CreateUserViewModel CreateUserViewModel { get; set; }

        public void OnGet()
        {
            ViewData["Roles"] = _permissionService.GetRoles();
        }

        public IActionResult OnPost(List<int> SelectedRoles)
        {
            if (!ModelState.IsValid)
                return Page();


            int userId = _userService.AddUserFromAdmin(CreateUserViewModel);

            //Add Roles
            _permissionService.AddRolesToUser(SelectedRoles, userId);

            return Redirect("/Admin/Users");

        }
    }
}
