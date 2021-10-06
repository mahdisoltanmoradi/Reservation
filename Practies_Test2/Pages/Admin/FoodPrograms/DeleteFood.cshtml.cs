using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practies.Core.DTOs.Foods;
using Practies.Core.Services.Interface;
using Practies.DataLayer.Entities.FoodPrograms;

namespace Practies_Test2.Pages.Admin.FoodPrograms
{
    public class DeleteFoodModel : PageModel
    {
        IFoodService _foodService;
        public DeleteFoodModel(IFoodService foodService)
        {
            this._foodService = foodService;
        }
        [BindProperty]
        public InformationFoodViewModel informationFoodViewModel { get; set; }
        public void OnGet(int id)
        {
            ViewData["FoodId"] = id;
            informationFoodViewModel = _foodService.GetFoodInformation(id);
        }

        public IActionResult OnPost(int FoodId)
        {
            _foodService.DeleteFood(FoodId);
            return RedirectToPage("Index");
        }
            
    }
}
