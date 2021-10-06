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
    public class ListDeleteUsersModel : PageModel
    {
        IUserService _userService;
        public ListDeleteUsersModel(IUserService userService)
        {
            this._userService = userService;
        }
        [BindProperty]
        public UserForAdminViewModel UserForAdminViewModel { get; set; }

        public void OnGet(int pageId = 1, string filterName = "", string filterEmail = "")
        {
            UserForAdminViewModel = _userService.GetDeleteUser(pageId, filterName, filterEmail);
        }
    }
}
