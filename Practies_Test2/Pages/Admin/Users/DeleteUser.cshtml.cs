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
    public class DeleteUserModel : PageModel
    {
        IUserService _userService;
        public DeleteUserModel(IUserService userService)
        {
            this._userService = userService;
        }

        [BindProperty]
        public InformationViewModel InformationViewModel { get; set; }
        public void OnGet(int id)
        {
            ViewData["UserId"] = id;
            InformationViewModel = _userService.GetUserInformation(id);
        }

        public IActionResult OnPost(int UserId)
        {
            _userService.DeleteUser(UserId);
            return RedirectToPage("Index");
        }
    }
}
