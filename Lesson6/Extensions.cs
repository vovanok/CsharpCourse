using System;

namespace Lesson6
{
    public static class Extensions
    {
        private static Random random = new Random();

        public static void FillMatrixRandom(this Matrix matrix)
        {
            if (matrix == null)
                return;

            for (uint col = 0; col < matrix.ColCount; col++)
            {
                for (uint row = 0; row < matrix.RowCount; row++)
                {
                    matrix[col, row] = random.Next(0, 100);
                }
            }
        }

        public static void FillMatrixRandom(this ToeplizMatrix matrix)
        {
            if (matrix == null)
                return;

            for (uint col = 0; col < matrix.ColCount; col++)
            {
                matrix[col, 0] = random.Next(0, 100);
            }

            for (uint row = 1; row < matrix.RowCount; row++)
            {
                matrix[0, row] = random.Next(0, 100);
            }
        }
    }
}
