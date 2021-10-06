using Microsoft.AspNetCore.Mvc.Rendering;
using Practies.Core.DTOs.Foods;
using Practies.DataLayer.Entities.FoodPrograms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practies.Core.Services.Interface
{
    public interface IFoodService
    {
        int AddFood(Food food);
        int AddFoodFromAdmin(Food food);
        InformationFoodViewModel GetFoodInformation(int foodId);
        Food GetFoodById(int foodId);
        List<Food> GetFoods();
        void UpdateFood(Food food);
        void DeleteFood(int foodId);
        EditFoodViewModel GetFoodForShowInEdit(int foodId);
        void EditFoodFromAdmin(EditFoodViewModel editFood,int? id= null);




        #region FoodUserpanel
        IEnumerable<Food> IsExistFood(ExistFoodViewModel existFood);
        IEnumerable<Food> GetFoodByData(DateTime dateTime,string foodName);
        #endregion

    }
}
