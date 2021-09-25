using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeighingManager.Models;

namespace WeighingManager.Helpers
{
    public class WeightConverter
    {
        public static decimal ConvertWeight(WeightUnit from, WeightUnit to, decimal weight)
        {
            if (from == to) return weight;

            switch(from)
            {
                case WeightUnit.kg:
                    {
                        if (to == WeightUnit.pound)
                            return KgToPound(weight);
                        else if (to == WeightUnit.ton)
                            return KgToTon(weight);
                    }
                    break;
                case WeightUnit.pound:
                    {
                        if (to == WeightUnit.kg)
                            return PoundToKg(weight);
                        else if (to == WeightUnit.ton)
                            return PoundToTon(weight);
                    }
                    break;
                case WeightUnit.ton:
                    {
                        if (to == WeightUnit.pound)
                            return TonToPound(weight);
                        else if (to == WeightUnit.kg)
                            return TonToKg(weight);
                    }
                    break;
                default:
                    return 0;
            }

            return 0;
        }

        public static decimal TonToKg(decimal weight)
        {
            return weight * 1000M;
        }

        public static decimal PoundToKg(decimal weight)
        {
            return weight * 0.45359237M;
        }

        public static decimal KgToTon(decimal weight)
        {
            return weight / 1000M;
        }

        public static decimal PoundToTon(decimal weight)
        {
            return weight * 0.00045359237M;
        }

        public static decimal KgToPound(decimal weight)
        {
            return weight / 0.45359237M;
        }

        public static decimal TonToPound(decimal weight)
        {
            return weight / 0.00045359237M;
        }
    }
}
