using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WeighingManager.Helpers;
using WeighingManager.Models;
using WeighingManager.Services;

namespace TestProject
{
    [TestClass]
    public class TestWeightMeasurementStorageService
    {
        [TestMethod]
        public void TestAddRange()
        {
            int expected = 8;
            List<WeightMeasurement> measurements = getMeasurements();
            var measurementStorageService = new WeightMeasurementStorageService();

            measurementStorageService.AddRange(measurements);
            int actual = measurementStorageService.Measurements.Count;

            Assert.AreEqual(expected, actual, $"Expected ${expected} measurements, but found ${actual}.\n");
        }

        [TestMethod]
        public void TestAllMayMeasurements()
        {
            decimal expected = 3689;
            string actualUnit = "kg";
            List<WeightMeasurement> measurements = getMeasurements();
            var measurementStorageService = new WeightMeasurementStorageService();

            measurementStorageService.AddRange(measurements);
            WeighingSummary actual = measurementStorageService.GetFilteredMeasurements(null, null, "may");

            Assert.AreEqual(expected, actual.Weight, $"Expected ${expected} measurements, but found ${actual}.\n");
            Assert.AreEqual(actualUnit, actual.Unit.ToString(), $"Expected ${actualUnit} measurements, but found ${actual.Unit.ToString()}.\n");
        }

        [TestMethod]
        public void TestTrckOTK838MayMeasurements()
        {
            decimal expected = 2429;
            string actualUnit = "kg";
            string actualTruckId = "trckOTK838";
            List<WeightMeasurement> measurements = getMeasurements();
            var measurementStorageService = new WeightMeasurementStorageService();

            measurementStorageService.AddRange(measurements);
            WeighingSummary actual = measurementStorageService.GetFilteredMeasurements("trckOTK838", null, "may");

            Assert.AreEqual(expected, actual.Weight, $"Expected ${expected} measurements, but found ${actual}.\n");
            Assert.AreEqual(actualUnit, actual.Unit.ToString(), $"Expected ${actualUnit} measurements, but found ${actual.Unit.ToString()}.\n");
            Assert.AreEqual(actualTruckId, actual.TruckId, $"Expected ${actualTruckId} measurements, but found ${actual.TruckId}.\n");
        }

        [TestMethod]
        public void TestBsg_768JunMeasurements()
        {
            decimal expected = 2429;
            string actualUnit = "kg";
            string actualScaleId = "bsg_768";
            List<WeightMeasurement> measurements = getMeasurements();
            var measurementStorageService = new WeightMeasurementStorageService();

            measurementStorageService.AddRange(measurements);
            WeighingSummary actual = measurementStorageService.GetFilteredMeasurements(null, "bsg_768", "jun");

            Assert.AreEqual(expected, actual.Weight, $"Expected ${expected} measurements, but found ${actual}.\n");
            Assert.AreEqual(actualUnit, actual.Unit.ToString(), $"Expected ${actualUnit} measurements, but found ${actual.Unit.ToString()}.\n");
            Assert.AreEqual(actualScaleId, actual.ScaleId, $"Expected ${actualScaleId} measurements, but found ${actual.ScaleId}.\n");
        }

        [TestMethod]
        public void TestBsg_768JunMeasurementsPounds()
        {
            double expected = 5355.0283485;
            string actualUnit = "pound";
            List<WeightMeasurement> measurements = getMeasurements();
            var measurementStorageService = new WeightMeasurementStorageService();

            measurementStorageService.AddRange(measurements);
            WeighingSummary actual = measurementStorageService.GetFilteredMeasurements(null, "bsg_768", "jun", WeightUnit.pound);

            Assert.AreEqual(expected, (double)actual.Weight, 0.001, $"Expected ${expected} measurements, but found ${actual}.\n");
            Assert.AreEqual(actualUnit, actual.Unit.ToString(), $"Expected ${actualUnit} measurements, but found ${actual.Unit.ToString()}.\n");
        }


        private List<WeightMeasurement> getMeasurements()
        {

            List<WeightMeasurement> measurements = new();
            measurements.Add(new WeightMeasurement()
            {
                ScaleId = "bsg_768",
                TruckId = "trckOTK838",
                Unit = WeightUnit.kg,
                Weight = 1120,
                Time = new System.DateTime(2021, 6, 14, 12, 23, 45)
            });
            measurements.Add(new WeightMeasurement()
            {
                ScaleId = "bsg_768",
                TruckId = "trckOTK838",
                Unit = WeightUnit.kg,
                Weight = 1309,
                Time = new System.DateTime(2021, 6, 18, 10, 12, 45)
            });
            measurements.Add(new WeightMeasurement()
            {
                ScaleId = "bsg_769",
                TruckId = "trckEOO725",
                Unit = WeightUnit.ton,
                Weight = 6,
                Time = new System.DateTime(2021, 6, 15, 12, 23, 45)
            });
            measurements.Add(new WeightMeasurement()
            {
                ScaleId = "bsg_769",
                TruckId = "trckEOO725",
                Unit = WeightUnit.ton,
                Weight = 4.2M,
                Time = new System.DateTime(2021, 6, 16, 12, 23, 45)
            });

            measurements.Add(new WeightMeasurement()
            {
                ScaleId = "bsg_769",
                TruckId = "trckEOO725",
                Unit = WeightUnit.ton,
                Weight = 923,
                Time = new System.DateTime(2021, 6, 19, 14, 23, 45)
            });
            measurements.Add(new WeightMeasurement()
            {
                ScaleId = "bsg_768",
                TruckId = "trckEOO725",
                Unit = WeightUnit.pound,
                Weight = 891
            });

            measurements.Add(new WeightMeasurement() { });

            measurements.Add(new WeightMeasurement()
            {
                ScaleId = "bsg_768",
                TruckId = "trckOTK838",
                Unit = WeightUnit.kg,
                Weight = 1120,
                Time = new System.DateTime(2021, 5, 14, 12, 23, 45)
            });
            measurements.Add(new WeightMeasurement()
            {
                ScaleId = "bsg_768",
                TruckId = "trckOTK838",
                Unit = WeightUnit.kg,
                Weight = 1309,
                Time = new System.DateTime(2021, 5, 18, 10, 12, 45)
            });
            measurements.Add(new WeightMeasurement()
            {
                ScaleId = "bsg_768",
                TruckId = "trckEOO725",
                Unit = WeightUnit.kg,
                Weight = 1260,
                Time = new System.DateTime(2021, 5, 19, 10, 12, 45)
            });

            return measurements;
        }
    }
}
