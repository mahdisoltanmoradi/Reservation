using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PaginationAspDotNetCore2;
using Practies.Core.DTOs;
using Practies.Core.DTOs.Foods;
using Practies.Core.Services.Interface;
using Practies.DataLayer.Entities.FoodPrograms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Practies_Test2.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {

        IUserService _userService;
        IFoodService _foodService;
        IFactorService _factorService;
        private int _UserId;
        public HomeController(IUserService useerService, IFoodService foodService,IFactorService factorService, IHttpContextAccessor httpContext)
        {
            this._factorService = factorService;
            this._userService = useerService;
            this._foodService = foodService;
            _UserId = Convert.ToInt32(httpContext.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.NameIdentifier)?.Value);
        }


        public IActionResult Index()            
        {
            return View(_userService.GetUserInformation(_UserId));
        }

        [Route("UserPanel/EdidProfile")]
        public IActionResult EditProfile()
        {
            return View(_userService.GetDataForEditProfileUser(User.Identity.Name));
        }

        [HttpPost]
        [Route("UserPanel/EdidProfile")]
        public IActionResult EditProfile(EditProfileViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }
            _userService.EditProfile(User.Identity.Name, edit);

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Login?EditProfile=true");
        }



        [HttpGet]
        public IActionResult Foods(ExistFoodViewModel existFood, int page = 1, int pageSize = 10)
        {

            var list = PagedList<Food>.ToPagedList(_foodService.GetFoodByData(existFood.dateTime, existFood.FoodName), page, pageSize);
            ViewBag.CurrentPage = list.CurrentPage;
            ViewBag.TotalPages = list.TotalPages;
            ViewBag.GetFood = list;
            ViewBag.HasNext = list.HasNext;
            ViewBag.HasPrevious = list.HasPrevious;
            return View(list);
        }

        [HttpGet]
        [Route("UserPanel/UserFactors")]
        public IActionResult UserFactors()
        { 
            return View(_factorService.GetFactors(_UserId));
        }
    }
}
