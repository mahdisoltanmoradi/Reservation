﻿using Microsoft.AspNetCore.Mvc;
using Practies.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practies_Test2.Controllers
{
    public class HomeController : Controller
    {
        IUserService _userService;
        public HomeController(IUserService userService)
        {
            this._userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("OnlinePayment/{id}")]
        public IActionResult onlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
              HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
              && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                var wallet = _userService.GetWalletByWalletId(id);

                var payment = new ZarinpalSandbox.Payment(wallet.Amount);

                var res = payment.Verification(authority).Result;

                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;
                    wallet.IsPay = true;
                    _userService.UpdateWallet(wallet);
                }

            }

            return View();
        }
    }
}
