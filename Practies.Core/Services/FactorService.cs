using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Practies.Core.Services.Interface;
using Practies.DataLayer.Context;
using Practies.DataLayer.Entities.FoodPrograms;
using Practies.DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Practies.Core.Services
{
    public class FactorService : IFactorService
    {
        PractiesContext _context;
        IHttpContextAccessor _httpContext;
        private readonly IUserService _userService;

        public FactorService(PractiesContext context, IHttpContextAccessor httpContext, IUserService userService)
        {
            this._context = context;
            this._httpContext = httpContext;
            this._userService = userService;
        }


        public bool AddFactor(Food food,out string message)
        {


            int wallet =_userService.BalanceUserWallet(_httpContext.HttpContext.User.Identity.Name);

            Factor factor = new Factor()
            {
                User_Id = Convert.ToInt32(_httpContext.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.NameIdentifier)?.Value),
                dateTime = DateTime.Now,
                SumPrice = food.Price,
                Descriptio = food.Description,
                FoodId = food.FoodId,
            };

            if (food.Price <= wallet)
            {
                _context.Factors.Add(factor);
                _context.Wallets.Add(new DataLayer.Entities.Wallets.Wallet
                {
                    Amount = food.Price,
                    Description = "خرید غذا",
                    TypeId = 2,
                    UserId = Convert.ToInt32(_httpContext.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.NameIdentifier)?.Value),

                });
                _context.SaveChanges();
                message = "انجام شد";
                return true;
            }
            else
            {
                message = "موجودی کافی نیست";
                return false;
            }

        }

        public Factor GetFactorById(int factorId)
        {
            return _context.Factors.Include(f => f.Food).Include(f => f.User).SingleOrDefault(f => f.FactorId == factorId);
        }

        public List<Factor> GetFactors(int userId)
        {
            Factor factor = new Factor()
            {
                User_Id = Convert.ToInt32(_httpContext.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.NameIdentifier)?.Value),

            };
            return _context.Factors.Include(f => f.Food).Include(f => f.User).Where(f => f.User_Id == userId).ToList();
        }
    }
}
