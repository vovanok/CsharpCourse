using System;

namespace Lesson6
{
    public class TwoMatrixOperationException : Exception
    {
        public Matrix FirstMatrix { get; private set; }

        public Matrix SecondMatrix { get; private set; }

        public override string Message
        {
            get
            {
                string firstMatrixInfo = FirstMatrix != null
                    ? $"{FirstMatrix.ColCount}x{FirstMatrix.RowCount}"
                    : "не задана";

                string secondMatrixInfo = SecondMatrix != null
                    ? $"{SecondMatrix.ColCount}x{SecondMatrix.RowCount}"
                    : "не задана";

                return $"{base.Message} (первая матрица {firstMatrixInfo}, вторая матрица {secondMatrixInfo})";
            }
        }

        public TwoMatrixOperationException(string message,
            Matrix firstMatrix, Matrix secondMatrix)
            : base(message)
        {
            FirstMatrix = firstMatrix;
            SecondMatrix = secondMatrix;
        }
    }
}
