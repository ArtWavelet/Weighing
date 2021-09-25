using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WeighingManager.Helpers;
using WeighingManager.Models;

namespace WeighingManager.Services
{
    public class WeightMeasurementStorageService
    {
        private List<WeightMeasurement> _measurements = new();
        public ReadOnlyCollection<WeightMeasurement> Measurements
        {
            get { return _measurements.AsReadOnly(); }
        }

        public bool Add(WeightMeasurement measurement)
        {
            if (measurement == null) 
                return false;

            if (string.IsNullOrWhiteSpace(measurement.ScaleId) ||
                string.IsNullOrWhiteSpace(measurement.TruckId) ||
                measurement.Weight == 0 || 
                measurement.Time == DateTime.MinValue) 
                return false;

            var existing = _measurements.Find(x => x.ScaleId == measurement.ScaleId && x.TruckId == measurement.TruckId && DateTime.Equals(measurement.Time, x.Time));
            if (existing != null)
            {
                // It should be an update to a somehow failed measurement.
                existing.Unit = measurement.Unit;
                existing.Weight = measurement.Weight;
                return false;
            }

            _measurements.Add(measurement);
            return true;
        }

        public int AddRange(List<WeightMeasurement> measurements)
        {
            int addedCount = 0;
            foreach (var measurement in measurements)
            {
                if (Add(measurement))
                    addedCount++;
            }
            return addedCount;
        }

        public WeighingSummary GetFilteredMeasurements(string truckId, string scaleId, string monthAbbr, WeightUnit unit = WeightUnit.kg)
        {
            WeighingSummary summary = new() { Unit = unit.ToString(), Month = null, ScaleId = null, TruckId = null };

            IEnumerable<WeightMeasurement> query = _measurements;
            if (truckId != null)
            {
                summary.TruckId = truckId;
                query = query.Where(x => x.TruckId == truckId);
            }
            if (scaleId != null)
            {
                summary.ScaleId = scaleId;
                query = query.Where(x => x.ScaleId == scaleId);
            }
            if (monthAbbr != null)
            {
                var monthNro = TimeHelper.MonthAbbreviationToNumber(monthAbbr);
                query = query.Where(x => x.Time.Month == monthNro);
                summary.Month = TimeHelper.MonthAbbreviationToName(monthAbbr);
            }

            summary.Weight = query.Sum(x => WeightConverter.ConvertWeight(x.Unit, unit, x.Weight));
            return summary;
        }
    }
}
