using Practies.DataLayer.Entities.FoodPrograms;
using Practies.DataLayer.Entities.Wallets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Practies.DataLayer.Entities.Users
{
    public class User
    {
        public User()
        {

        }

        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }

        [Display(Name = "کد فعال سازی")]
        [MaxLength(50, ErrorMessage = "{0}نمیتواند بیشتر از {1}کراکتر باشد.")]
        public string ActiveCode { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "عکس کاربر")]
        public string UserAvatar { get; set; }

        [Display(Name = "تاریخ عضویت")]
        public DateTime RegisterDate { get; set; }

        public bool IsDelete { get; set; }

        #region Relations
        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<Wallet> Wallets { get; set; }
        public virtual List<Factor> Factors { get; set; }

        #endregion
    }
}
