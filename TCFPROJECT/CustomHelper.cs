using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCFPROJECT
{
    public class CustomHelper
    {
        public static String GetConstructor => Environment.CurrentDirectory + @"\connstring.txt";
    }
}