using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WeighingManager.Helpers;

namespace TestProject
{
    [TestClass]
    public class TimeHelperUnitTests
    {
        [TestMethod]
        public void TestMonthAbbreviationToName()
        {
            List<string> months = new() { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec" };
            List<string> monthNames = new() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            for (int i = 0; i<12; i++)
            {
                string actual = TimeHelper.MonthAbbreviationToName(months[i]);
                Assert.AreEqual(monthNames[i], actual, $"Month ${months[i]} abbreviation was not mapped correctly\n");
            }
        }

        [TestMethod]
        public void TestMonthAbbreviationToNumber()
        {
            List<string> months = new() { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec" };
            List<int> monthNros = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            for (int i = 0; i < 12; i++)
            {
                int actual = TimeHelper.MonthAbbreviationToNumber(months[i]);
                Assert.AreEqual(monthNros[i], actual, $"Month ${months[i]} abbreviation was not mapped correctly\n");
            }
        }
    }
}
