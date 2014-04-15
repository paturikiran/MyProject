using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDR.Web
{
    public static class Extensions
    {

         public static string  GetDefaultDate(this DateTime? value)
         {
             return value == null ? DateTime.Now.ToShortDateString() : value.ToString();
         }
    }
}