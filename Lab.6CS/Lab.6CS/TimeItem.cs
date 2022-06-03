using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._6CS
{
    [Serializable]
    class TimeItem
    {

        public int MatrixOrder;
        public int RepeatNumber;
        public long TimeCS;
        public double TimeCPP;
        public double Coefficient;

        public TimeItem(int matrixOrderValue, int repeatNumberValue, long timeNumberCsValue,
            double timeNumberCppValue)
        {
            MatrixOrder = matrixOrderValue;
            RepeatNumber = repeatNumberValue;
            TimeCS = timeNumberCsValue;
            TimeCPP = timeNumberCppValue;
            Coefficient = TimeCS / TimeCPP;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Order: {MatrixOrder}");
            builder.AppendLine($"Repeats: {RepeatNumber}");
            builder.AppendLine($"CS# ticks: {TimeCS}");
            builder.AppendLine($"C++ ticks: {TimeCPP}");
            builder.AppendLine($"C# to C++ time coefficient: {Coefficient}");

            return builder.ToString();
        }
    }
}
