using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWpfApplication.Core
{
    public class ErrorList
    {
        public static string Login = "Login has only small english letters and digits, min length - 3, max - 20\n" +
                                    "Example : andre, jhon123, alexsandra666";
        public static string Password = "Login has only small english letters and digits, min length - 3, max - 20\n" +
                                        "Example : 45785qwe, 451we45";
        public static string Name = "Name has only english letters and begins with an uppercase letter\n" +
                                    "Example : Andre, Jhon, Alexsandra";
        public static string Surname = "Surname has only english letters and begins with an uppercase letter\n" +
                                        "Example : Fury, Anderson, Petrov";
        public static string PatronymicName = "Name has only english letters and begins with an uppercase letter\n" +
                                    "Example : Viktorovich, Petrovich";
        public static string Age = "Age can not be less than 1 and more than 100";
        public static string AgeNotNumber = "Age must be a number";
        public static string Address = "Addres";
        public static string Phone = "Phone number has 7 numbers\n" +
                                    "Example : 1234567";
        public static string City = "City has only english letters\n" +
                                    "Example : Kyiv, London, New York";
        public static string Mail = "It`s not a mail address\n" +
                                    "Example : example@example.com";

        public static string Hours = "Enter time in minutes";
        public static readonly string Price = "Enter price, 0 - free";
        public static readonly string OnlyText = "In the text must be only latin letters, digits and signs(,.-!;'\")";
        public static readonly string ClientMax = "Max number of members can not be less than 2 and more than 30";
    }
}
