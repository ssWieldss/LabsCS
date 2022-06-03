using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab._6CS
{
    public class Matrix
    {

        private double[] first_diag;

        private double[] second_diag;

        private double[] third_diag;

        private int matrix_Order;

        public double[] FirstDiag { get => first_diag; set => first_diag = value; }

        public double[] SecondDiag { get => second_diag; set => second_diag = value; }

        public double[] ThirdDiag { get => third_diag; set => third_diag = value; }

        public int MatrixOrder { get => matrix_Order; set => matrix_Order = value; }

        public Matrix(int matrixOrder)
        {
            var randVar = new Random();

            MatrixOrder = matrixOrder;

            first_diag = new double[matrixOrder - 1];
            second_diag = new double[matrixOrder];
            third_diag = new double[matrixOrder - 1];

            for (int i = 0; i < matrixOrder; i++)
            {
                SecondDiag[i] = randVar.NextDouble() * 5;

                if (i != matrixOrder - 1)
                {
                    FirstDiag[i] = randVar.NextDouble() * 2;
                    ThirdDiag[i] = randVar.NextDouble() * 3;
                }
            }
                

        }

        public Matrix(int matrixOrder, double[] first_diagVal,
            double[] second_diagVal, double[] third_diagVal)
        {
            MatrixOrder = matrixOrder;

            first_diag = new double[matrixOrder - 1];
            second_diag = new double[matrixOrder];
            third_diag = new double[matrixOrder - 1];

            for (int i = 0; i < matrixOrder; i++)
            {
                SecondDiag[i] = second_diagVal[i];

                if (i != matrixOrder - 1)
                {
                    FirstDiag[i] = first_diagVal[i];
                    ThirdDiag[i] = third_diagVal[i];
                }
            }
        }

        public double[] Solve(double[] constants)
        {
            int i;
            double[] beta = new double[MatrixOrder];
            double[] gamma = new double[MatrixOrder];
            double[] result = new double[MatrixOrder];

            beta[0] = ThirdDiag[0] / -SecondDiag[0];
            gamma[0] = constants[0] / SecondDiag[0];

            for (i = 1; i < MatrixOrder - 1; i++)
            {
                beta[i] = ThirdDiag[i] / (-SecondDiag[i] - FirstDiag[i - 1] * beta[i - 1]);

                gamma[i] = (constants[i] - FirstDiag[i - 1] * gamma[i - 1]) /
                    (SecondDiag[i] - FirstDiag[i - 1] * beta[i - 1]);
            }

            beta[MatrixOrder - 1] = 0;

            gamma[MatrixOrder - 1] = (constants[MatrixOrder - 1] -
                FirstDiag[MatrixOrder - 2] * gamma[MatrixOrder - 2]) /
                (SecondDiag[MatrixOrder - 1]
                    - FirstDiag[MatrixOrder - 2] * beta[MatrixOrder - 2]);

            result[MatrixOrder - 1] = gamma[MatrixOrder - 1];

            for (i = MatrixOrder - 1; i > 0; i--)
            {
                result[i - 1] = gamma[i - 1] - beta[i - 1] * result[i];
            }

            return result;
        }

        public static long repeatSolveByCS(int matrixOrder, int repeatCount)
        {
            Matrix matrix = new Matrix(matrixOrder);
            double[] constants = new double[matrixOrder];
            var randVar = new Random();

            for (int i = 0; i < matrixOrder; i++)
                constants[i] = randVar.NextDouble() * 10 + 10;

            var stopWatch = Stopwatch.StartNew();

            for (int i = 0; i < repeatCount; i++)
                matrix.Solve(constants);

            stopWatch.Stop();

            return stopWatch.ElapsedTicks;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("A: ");
            foreach (var element in FirstDiag)
                builder.Append(element + ", ");
            builder.Append(Environment.NewLine);

            builder.Append("B: ");
            foreach (var element in SecondDiag)
                builder.Append(element + ", ");
            builder.Append(Environment.NewLine);

            builder.Append("C: ");
            foreach (var element in ThirdDiag)
                builder.Append(element + ", ");

            return builder.ToString();
        }

    }
}
