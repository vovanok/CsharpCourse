using System;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = 50;

            Matrix matrix1 = new Matrix(n, n);
            matrix1.FillMatrixRandom();
            Console.WriteLine(matrix1);

            Matrix matrix2 = new Matrix(n, n);
            matrix2.FillMatrixRandom();
            Console.WriteLine(matrix2);

            ToeplizMatrix tMatrix1 = new ToeplizMatrix(n, n);
            tMatrix1.FillMatrixRandom();
            Console.WriteLine(tMatrix1);

            ToeplizMatrix tMatrix2 = new ToeplizMatrix(n, n);
            tMatrix2.FillMatrixRandom();
            Console.WriteLine(tMatrix2);

            try
            {
                DateTime starttime = DateTime.Now;
                Console.WriteLine(matrix1.Sum(matrix2));
                Console.WriteLine(DateTime.Now - starttime);

                starttime = DateTime.Now;
                Console.WriteLine(tMatrix1.Sum(tMatrix2));
                Console.WriteLine(DateTime.Now - starttime);
            }
            catch (TwoMatrixOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
