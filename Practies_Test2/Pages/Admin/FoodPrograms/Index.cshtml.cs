using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practies.Core.Services.Interface;
using Practies.DataLayer.Entities.FoodPrograms;

namespace Practies_Test2.Pages.Admin.FoodPrograms
{
    public class IndexModel : PageModel
    {
        IFoodService _foodService;
        public IndexModel(IFoodService foodService)
        {
            this._foodService = foodService;
        }

        public List<Food> Foods { get; set; }
        public void OnGet()
        {
            Foods = _foodService.GetFoods();
        }
    }
}
