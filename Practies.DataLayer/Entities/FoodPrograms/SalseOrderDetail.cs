using Practies.DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practies.DataLayer.Entities.FoodPrograms
{
    public class SalseOrderDetail
    {
        public SalseOrderDetail()
        {

        }

        [Key]
        public int OrderDetailId { get; set; }
        public int FoodId { get; set; }
        public int UserId { get; set; }

        [Display(Name = "تعداد غذا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int FoodCuont { get; set; }

        [Display(Name = "قیمت غذا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }



        #region Relation
        public Factor Factors { get; set; }

        #endregion


    }
}
