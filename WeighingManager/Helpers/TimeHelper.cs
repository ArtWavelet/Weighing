using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeighingManager.Helpers
{
    public class TimeHelper
    {
        public static string MonthAbbreviationToName(string abbr)
        {
            string result = "";

            switch (abbr.ToLower())
            {
                case "jan":
                    result = "January";
                    break;
                case "feb":
                    result = "February";
                    break;
                case "mar":
                    result = "March";
                    break;
                case "apr":
                    result = "April";
                    break;
                case "may":
                    result = "May";
                    break;
                case "jun":
                    result = "June";
                    break;
                case "jul":
                    result = "July";
                    break;
                case "aug":
                    result = "August";
                    break;
                case "sep":
                case "sept":
                    result = "September";
                    break;
                case "oct":
                    result = "October";
                    break;
                case "nov":
                    result = "November";
                    break;
                case "dec":
                    result = "December";
                    break;
                default:
                    result = "";
                    break;
            }

            return result;
        }

        public static int MonthAbbreviationToNumber(string abbr)
        {
            int result = 0;

            switch (abbr.ToLower())
            {
                case "jan":
                    result = 1;
                    break;
                case "feb":
                    result = 2;
                    break;
                case "mar":
                    result = 3;
                    break;
                case "apr":
                    result = 4;
                    break;
                case "may":
                    result = 5;
                    break;
                case "jun":
                    result = 6;
                    break;
                case "jul":
                    result = 7;
                    break;
                case "aug":
                    result = 8;
                    break;
                case "sep":
                case "sept":
                    result = 9;
                    break;
                case "oct":
                    result = 10;
                    break;
                case "nov":
                    result = 11;
                    break;
                case "dec":
                    result = 12;
                    break;
                default:
                    result = 0;
                    break;
            }

            return result;
        }
    }
}
