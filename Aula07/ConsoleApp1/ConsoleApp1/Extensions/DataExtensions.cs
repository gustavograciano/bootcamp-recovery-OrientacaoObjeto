using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Utils
{
    static class DataExtensions
    {
        public static string FormatarDataSistema(this DateTime data)
        {
            return data.Month + "/" + data.Year;
        }
    }
}
