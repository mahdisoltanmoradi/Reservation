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
    public class EditUserModel : PageModel
    {
        IUserService _userService;
        IPermissionService _permissionService;
        public EditUserModel(IUserService userService, IPermissionService permissionService)
        {
            this._userService = userService;
            this._permissionService = permissionService;
        }
        public EditUserViewModel  EditUserViewModel { get; set; }
        public void OnGet(int id)
        {
            EditUserViewModel = _userService.GetUserForShowInEditMode(id);
            ViewData["Roles"] = _permissionService.GetRoles();
        }

        public IActionResult OnPost(List<int> SelectedRoles)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _userService.EditUserFromAdmin(EditUserViewModel);
            _permissionService.EditRolesUser(EditUserViewModel.UserId, SelectedRoles);
            return RedirectToPage("Index");
        }
    }
}
