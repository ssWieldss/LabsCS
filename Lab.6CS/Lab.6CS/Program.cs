using System;
using System.IO;
using System.Runtime.InteropServices;


//На чем остановился: не считается время на ++, неправильный подсчет в CS, код надо рефакторить, ибо палевно 

namespace Lab._6CS
{
    internal class Program
    {
            private const string PathDll = "c:\\Users\\egor1\\source\\repos\\Lab.6CS\\Lab.6CS\\x64\\Debug\\Dll1.dll";

        [DllImport(PathDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern double repeat_solve_byCPP(int matrix_order, int repeat_count);

        [DllImport(PathDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern void solve_matrix_byCPP(int matrixOrder, double[] diagonalAValue, double[] diagonalBValue,
    double[] diagonalCValue, double[] constant_terms, double[] result);

        public static void Main(string[] args)
        {
            //1 пункт задания 

            int matrixOrder = 4;
            double[] second_diag = new double[] { 567.2 , 123.9, 12.1, 54.6 };
            double[] first_diag = new double[] { 1.234, 5.23, 8.27 };
            double[] third_diag = new double[] { 54.32, 23.9, 66.56 };
            double[] constantTerms = new double[] { 12.1430, 13.0897, 13.6744, 13.8972 };


            Matrix matrix = new Matrix(matrixOrder, first_diag, second_diag, third_diag);

            double[] solveCS = matrix.Solve(constantTerms);
            Console.WriteLine("C#: ");
            Console.WriteLine(matrix);

            Console.Write("Constant terms: ");
            foreach (var element in constantTerms)
                Console.Write(element + " ");
            Console.Write(Environment.NewLine);

            Console.Write("Solutions: ");
            foreach (var element in solveCS)
                Console.Write(element + " ");
            Console.WriteLine(Environment.NewLine);


            //2 пункт задания 

            double[] resultCPP = new double[matrixOrder];
            solve_matrix_byCPP(matrixOrder, first_diag, second_diag, third_diag, constantTerms, resultCPP);
            Console.WriteLine("C++: ");
            Console.Write("Решения той же матрицы на другом языке: ");
            foreach (var element in resultCPP)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine(Environment.NewLine);


            //3 пункт задания 

            TimesList timesList = new();
            string filename;

            Console.Write("Введите имя файла: ");
            filename = Console.ReadLine();
            FileInfo fileInfo = new FileInfo(filename);

            try
            {
                if (fileInfo.Exists)
                {
                    timesList.Load(filename);
                    Console.WriteLine("Загружен:");
                    Console.WriteLine(timesList);
                    Console.Write(Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("Файл не найден, создаем...");
                    fileInfo.Create().Close();
                    Console.Write(Environment.NewLine);
                }


                //4 пункт задания

                bool endProgram;
                string userEnter;
                int matrixOrderValue, repetitionsNumber;


                Console.WriteLine("Введите \"Q\" для выхода или \"C\" для продолжение");
                userEnter = Console.ReadLine();
                switch (userEnter)
                {
                    case "Q":
                        endProgram = true;
                        break;
                    case "C":
                        endProgram = false;
                        break;
                    default:
                        endProgram = true;
                        break;
                }

                while (!endProgram)
                {
                    Console.WriteLine("Введите ранг матрицы:");
                    if (!Int32.TryParse(Console.ReadLine(), out matrixOrderValue))
                    {
                        Console.WriteLine("Неверное число ранга матрицы!");
                        endProgram = true;
                        break;
                    }


                    Console.WriteLine("Введите количество повторений(Чтобы получить реальные данные, нужно указывать " +
                        "большие числа, так как C++ очень быстро считает маленькие матрицы и программа выдает 0)");

                    if (!Int32.TryParse(Console.ReadLine(), out repetitionsNumber))
                    {
                        Console.WriteLine("Неверное число повторений!");
                        endProgram = true;
                        break;
                    }

                    long csTimeValue = Matrix.repeatSolveByCS(matrixOrderValue, repetitionsNumber);
                   
                    double cppTimeValue = repeat_solve_byCPP(matrixOrderValue, repetitionsNumber);

                    TimeItem newTimeItem = new TimeItem(matrixOrderValue, repetitionsNumber, csTimeValue, cppTimeValue);
                    timesList.Add(newTimeItem);

                    Console.WriteLine("Выполненно!" + Environment.NewLine);
                    endProgram = true;
                }

                //5 пункт задания
                Console.Write(Environment.NewLine);
                Console.WriteLine("Все расчеты: ");
                Console.Write(timesList.ToString());
                timesList.Save(filename);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
