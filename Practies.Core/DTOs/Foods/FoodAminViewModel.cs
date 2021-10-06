using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Practies.Core.DTOs.Foods
{

    public class InformationFoodViewModel
    {

        [Display(Name = ("نام غذا"))]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FoodName { get; set; }

        [Display(Name = ("تاریخ"))]
        [Column(TypeName = "datetime")]
        public DateTime dateTime { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }

        [Display(Name = "تعداد غذا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int FoodCount { get; set; }
    }

    public class EditFoodViewModel
    {
        public int FoodId { get; set; }

        public string FoodName { get; set; }

        [Display(Name = ("تاریخ"))]
        [Column(TypeName = "datetime")]
        public DateTime dateTime { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }

        [Display(Name = "تعداد غذا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int FoodCount { get; set; }
    }

    public class ExistFoodViewModel
    {

        [Display(Name = ("نام غذا"))]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FoodName { get; set; }

        [Display(Name = ("تاریخ"))]
        public DateTime dateTime { get; set; }
    }

}
