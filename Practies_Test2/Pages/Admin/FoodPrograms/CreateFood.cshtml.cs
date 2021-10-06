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
    public class CreateFoodModel : PageModel
    {
        IFoodService _foodService;
        public CreateFoodModel(IFoodService foodService)
        {
            this._foodService = foodService;
        }

        [BindProperty]
        public Food Food { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
                return Page();


            _foodService.AddFoodFromAdmin(Food);
            return RedirectToPage("Index");
        }
    }
}
