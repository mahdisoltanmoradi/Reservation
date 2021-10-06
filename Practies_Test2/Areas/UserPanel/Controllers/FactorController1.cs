using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practies.Core.Services.Interface;
using Practies.DataLayer.Entities.FoodPrograms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practies_Test2.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]

    public class FactorController1 : Controller
    {
        IFactorService _factorService;
        IFoodService _foodService;
        public FactorController1(IFactorService factorService,IFoodService foodService)
        {
            this._factorService = factorService;
            this._foodService = foodService;
        }

        [HttpGet("UserPanel/Factor/Create/{id}")]
        public IActionResult Create(int id)
        {
            return View(_foodService.GetFoodById(id));
        }

        
        [Route("UserPanel/Factor/CreateFactor/{id}")]

        public IActionResult CreateFactor(int id) 
        {
            string msg;
            var food = _foodService.GetFoodById(id);
            if (_factorService.AddFactor(food,out msg))
            {
                ViewBag.Message = msg;
            }
            else
            {
                return RedirectToAction("Index", "Wallet",new {message = msg });
            }

            return RedirectToAction("UserFactors", "Home");
        }

        public IActionResult ShowFactorById(int id)
        {
            return View(_factorService.GetFactorById(id));
        }


    }
}
