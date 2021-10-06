using System;
using System.Collections.Generic;
using System.Text;

namespace Practies.Core.Convertors
{
   public class FixedText
    {
        public static string FixeEmail(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
