
using Microsoft.AspNetCore.Http;
using Practies.DataLayer.Entities.FoodPrograms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practies.Core.DTOs
{
    public class InformationViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Wallet { get; set; }
        public List<Factor> TodayFood { get; set; }
    }

    public class SideBarUserPanelViewModel
    {
        public string UserName { get; set; }
        public string ImageName { get; set; }
        public DateTime RegisterDate { get; set; }
    }


    public class EditProfileViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        public IFormFile UserAvatar { get; set; }

        public string AvatarName { get; set; }

    }

}
