using Microsoft.AspNetCore.Http;
using Practies.DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practies.Core.DTOs
{
    public class UserForAdminViewModel
    {
        public List<Practies.DataLayer.Entities.Users.User> Users { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class CreateUserViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0}را وارد کنید ")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کراکتر باشد.")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0}را وارد کنید ")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کراکتر باشد.")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0}را وارد کنید ")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کراکتر باشد.")]
        public string Password { get; set; }

        public IFormFile UserAvatar { get; set; }
    }

    public class EditUserViewModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0}را وارد کنید ")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کراکتر باشد.")]
        public string Email { get; set; }

        public IFormFile UserAvatar { get; set; }

        public List<int> UserRoles { get; set; }

        public string AvatarName { get; set; }
    }
}
