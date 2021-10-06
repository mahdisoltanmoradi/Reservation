using Practies.DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace Practies.DataLayer.Entities.FoodPrograms
{
    public class Factor
    {
        public Factor()
        {

        }

        [Key]
        public int FactorId { get; set; }

        [Display(Name = ("کاربر"))]
        public int User_Id { get; set; }


        [Display(Name = ("تاریخ"))]
        public DateTime dateTime { get; set; }

        [Display(Name = "جمع کل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int SumPrice { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = ("توضیح متختصر"))]
        [MaxLength(500)]
        public string Descriptio { get; set; }

        [Display(Name = ("کاربر"))]
        public int FoodId { get; set; }


        #region Relations
        public Food Food { get; set; }
        public User User { get; set; }
        public List<SalseOrderDetail> SalseOrderDetails { get; set; }
        #endregion

    }


}
