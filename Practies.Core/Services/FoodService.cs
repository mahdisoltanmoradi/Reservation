using Microsoft.AspNetCore.Http;
using Practies.Core.DTOs.Foods;
using Practies.Core.Services.Interface;
using Practies.DataLayer.Context;
using Practies.DataLayer.Entities.FoodPrograms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Practies.Core.Services
{
    public class FoodService : IFoodService
    {
        private IHttpContextAccessor _HttpContextAccessor;
        PractiesContext _context;
        public FoodService(PractiesContext context, IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
            this._context = context;
        }

        public int AddFood(Food food)
        {
            _context.Add(food);
            _context.SaveChanges();
            return food.FoodId;
        }

        /// <summary>
        /// ثبت غذا
        /// </summary>
        /// <param name="food">مدل غذا</param>
        /// <returns>آیدی غذای ثبت شده</returns>
        public int AddFoodFromAdmin(Food food)
        {
            food.CreateDate = new DateTime(food.CreateDate.Year, food.CreateDate.Month, food.CreateDate.Day, new PersianCalendar());
            food.IsActive = true;
            return AddFood(food);
        }


        public InformationFoodViewModel GetFoodInformation(int foodId)
        {

            var foodID = GetFoodById(foodId);

            InformationFoodViewModel informationFood = new InformationFoodViewModel();
            informationFood.FoodName = foodID.FoodName;
            informationFood.Amount = foodID.Price;
            informationFood.dateTime = foodID.CreateDate;
            informationFood.FoodCount = foodID.Count;

            return informationFood;

        }

        public Food GetFoodById(int foodId)
        {
            return _context.Foods.Find(foodId);
        }

        public void UpdateFood(Food food)
        {
            _context.Update(food);
            _context.SaveChanges();
        }

        public void DeleteFood(int foodId)
        {
            var foodID = GetFoodById(foodId);
            _context.Remove(foodID);
            _context.SaveChanges();
        }

        public EditFoodViewModel GetFoodForShowInEdit(int foodId)
        {
            return _context.Foods.Where(f => f.FoodId == foodId)
                .Select(f => new EditFoodViewModel
                {
                    FoodId = f.FoodId,
                    FoodName = f.FoodName,
                    dateTime = f.CreateDate,
                    Amount = f.Price,
                    FoodCount = f.Count
                }).Single();

        }

        public void EditFoodFromAdmin(EditFoodViewModel editFood, int? id = null)
        {
            Food food = GetFoodById(id!=null?(int)id:editFood.FoodId);

            food.FoodName = editFood.FoodName;
            food.CreateDate = new DateTime(editFood.dateTime.Year, editFood.dateTime.Month, editFood.dateTime.Day, new PersianCalendar());
            food.Price = editFood.Amount;
            food.Count = editFood.FoodCount;

            _context.Foods.Update(food);
            _context.SaveChanges();
        }


        public List<Food> GetFoods()
        {
            return _context.Foods.ToList();
        }

        public IEnumerable<Food> IsExistFood(ExistFoodViewModel existFood)
        {
            var dateTime = new DateTime(existFood.dateTime.Year, existFood.dateTime.Month, existFood.dateTime.Day, new PersianCalendar());

            IQueryable<Food> foods = _context.Foods;

            if (!string.IsNullOrEmpty(existFood.FoodName))
            {
                foods = foods.Where(f => f.FoodName.Contains(existFood.FoodName));
            }

            return _context.Foods.Where(f => f.CreateDate == dateTime && f.FoodName == existFood.FoodName);

        }

        public IEnumerable<Food> GetFoodByData(DateTime dateTime, string foodName)
        {
            if (!string.IsNullOrEmpty(foodName))
            {
                return _context.Foods.Where(f => f.FoodName == foodName).ToList();
            }

            else if (dateTime != null && dateTime != DateTime.MinValue)
            {
                var qdateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new PersianCalendar());
                return _context.Foods.Where(f => f.CreateDate.Equals(qdateTime)).ToList();
            }

            return GetFoods();
        }



    }
}
