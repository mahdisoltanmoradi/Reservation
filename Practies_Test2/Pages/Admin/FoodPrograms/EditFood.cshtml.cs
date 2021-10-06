using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practies.Core.DTOs.Foods;
using Practies.Core.Services.Interface;

namespace Practies_Test2.Pages.Admin.FoodPrograms
{
    public class EditFoodModel : PageModel
    {
        IFoodService _foodService;
        public EditFoodModel(IFoodService foodService)
        {
            this._foodService = foodService;
        }

        [BindProperty]
        public EditFoodViewModel EditFoodViewModel { get; set; }
        public void OnGet(int id)
        {
            EditFoodViewModel = _foodService.GetFoodForShowInEdit(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _foodService.EditFoodFromAdmin(EditFoodViewModel);
            return RedirectToPage("Index");
        }
            

    }
}
