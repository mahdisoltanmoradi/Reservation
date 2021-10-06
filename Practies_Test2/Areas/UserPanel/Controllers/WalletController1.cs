using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practies.Core.DTOs;
using Practies.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practies_Test2.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class WalletController1 : Controller
    {
        IUserService _userService;
        public WalletController1(IUserService userService)
        {
            this._userService = userService;
        }

        [Route("UserPanel/Wallet")]
        public IActionResult Index(string message =null)
        {
            ViewBag.Message = message;
            ViewBag.GetWallets = _userService.GetWalletUser(User.Identity.Name);
            return View();
        }

        [Route("UserPanel/Wallet")]
        [HttpPost]
        public IActionResult Index(ChargeWalletViewModel charge)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.GetWallets = _userService.GetWalletUser(User.Identity.Name);
                return View(charge);
            }

            int walletId = _userService.ChargeWallet(User.Identity.Name, charge.Amount, "شارژ حساب");

            #region Online Payment
            var payment = new ZarinpalSandbox.Payment(charge.Amount);

            var res = payment.PaymentRequest("شارژ کیف پول", "http://localhost:6616/OnlinePayment/" + walletId);

            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            #endregion
            return null;

        }
    }
}
