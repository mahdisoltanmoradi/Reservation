
using Practies.DataLayer.Entities.FoodPrograms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practies.Core.Services.Interface
{
   public interface IFactorService
    {
        bool AddFactor(Food food,out string message);
        Factor GetFactorById(int factorId);
        List<Factor> GetFactors(int userId);
     
    }
}
