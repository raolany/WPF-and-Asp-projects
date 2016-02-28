using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWpfApplication.Model
{
    public class RegexMask
    {
        public static string FioMask = "^[A-Z]{1}[a-z]{1,20}$";
        //public static string LoginMask = "^[(a-z)|(0-9)]{3,20}$";
        public static string LoginMask = "[a-z@.0-9]";
        public static string PasswordMask = "^[(a-z)|(0-9)]{3,20}$";
        public static string AddressMask = "^[A-Za-z\\d,.\\s]+$";
        public static string PhoneMask = "^[0-9]{7}$";
        public static string CityMask = "^[A-Z]{1}[a-z]{1,20}(\\s[A-Z]{1}[a-z]{1,20}){0,20}$";
        public static string MailMask = "^[A-Za-z0-9_]{1,10}@[A-Za-z]{1,10}.[A-Za-z]{2,3}$";
        public static string Text = "^[\\w,.\\-!'\"\\s\\n]{0,250}$";
        public static string Name = "^[A-Z]{1}[a-z]{1,20}[\\sA-Z]{0,2}[a-z]{0,20}$";
    }
}
