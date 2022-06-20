using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MIS.Application.Helpers
{
   public static class PhoneNumberValidator
    {
        public static bool IsPhoneValid(string phone)
        {
            return Regex.IsMatch(phone, "[0-9]{9}");
        }
    }
}
