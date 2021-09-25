using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WeighingManager.Helpers;

namespace TestProject
{
    [TestClass]
    public class WeightConverterUnitTests
    {
        [TestMethod]
        public void TestConvertWeightKgToTon()
        {
            decimal testValue = 11100M;
            double expected = 11.1;
            decimal actual = WeightConverter.ConvertWeight(WeighingManager.Models.WeightUnit.kg, WeighingManager.Models.WeightUnit.ton, testValue);

            double dActual = (double)actual;
            Assert.AreEqual(expected, dActual, 0.001, "KgToTon convertion failed\n");
        }

        [TestMethod]
        public void TestConvertWeightKgToPound()
        {
            decimal testValue = 11100M;
            double expected = 24471.311103;
            decimal actual = WeightConverter.ConvertWeight(WeighingManager.Models.WeightUnit.kg, WeighingManager.Models.WeightUnit.pound, testValue);

            double dActual = (double)actual;
            Assert.AreEqual(expected, dActual, 0.001, "KgToPound convertion failed\n");
        }

        [TestMethod]
        public void TestConvertWeightTonToKg()
        {
            decimal testValue = 11100M;
            double expected = 11100000;
            decimal actual = WeightConverter.ConvertWeight(WeighingManager.Models.WeightUnit.ton, WeighingManager.Models.WeightUnit.kg, testValue);

            double dActual = (double)actual;
            Assert.AreEqual(expected, dActual, 0.001, "TonToKg convertion failed\n");
        }

        [TestMethod]
        public void TestConvertWeightTonToPound()
        {
            decimal testValue = 111M;
            double expected = 244713.11103;
            decimal actual = WeightConverter.ConvertWeight(WeighingManager.Models.WeightUnit.ton, WeighingManager.Models.WeightUnit.pound, testValue);

            double dActual = (double)actual;
            Assert.AreEqual(expected, dActual, 0.001, "TonToPound convertion failed\n");
        }

        [TestMethod]
        public void TestConvertWeightPoundToKg()
        {
            decimal testValue = 11100M;
            double expected = 5034.875307;
            decimal actual = WeightConverter.ConvertWeight(WeighingManager.Models.WeightUnit.pound, WeighingManager.Models.WeightUnit.kg, testValue);

            double dActual = (double)actual;
            Assert.AreEqual(expected, dActual, 0.001, "PoundToKg convertion failed\n");
        }

        [TestMethod]
        public void TestConvertWeightPoundToTon()
        {
            decimal testValue = 11100M;
            double expected = 5.034875307;
            decimal actual = WeightConverter.ConvertWeight(WeighingManager.Models.WeightUnit.pound, WeighingManager.Models.WeightUnit.ton, testValue);

            double dActual = (double)actual;
            Assert.AreEqual(expected, dActual, 0.001, "PoundToTon convertion failed\n");
        }
    }
}
