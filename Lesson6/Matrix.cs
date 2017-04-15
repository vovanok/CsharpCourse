using System;
using System.Text;

namespace Lesson6
{
    public class Matrix
    {
        private int[,] data;

        public virtual int this[uint col, uint row]
        {
            get { return data[col, row]; }
            set { data[col, row] = value; }
        }

        public uint ColCount { get; private set; }
        public uint RowCount { get; private set; }

        public Matrix(uint colCount, uint rowCount)
        {
            ColCount = colCount;
            RowCount = rowCount;

            InitData();
        }

        protected virtual void InitData()
        {
            data = new int[ColCount, RowCount];
        }

        public virtual Matrix Sum(Matrix otherMatrix)
        {
            if (otherMatrix == null)
            {
                throw new Exception("Вторая матрица не задана");
            }

            if (ColCount != otherMatrix.ColCount ||
                RowCount != otherMatrix.RowCount)
            {
                throw new TwoMatrixOperationException(
                    "Размеры матриц не одинаковы",
                    this, otherMatrix);
            }

            Matrix sumResult = new Matrix(ColCount, RowCount);

            for (uint col = 0; col < ColCount; col++)
            {
                for (uint row = 0; row < RowCount; row++)
                {
                    sumResult[col, row] = this[col, row] + otherMatrix[col, row];
                }
            }

            return sumResult;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (uint row = 0; row < RowCount; row++)
            {
                for (uint col = 0; col < ColCount; col++)
                {
                    sb.Append(this[col, row]);
                    if (col != ColCount - 1)
                        sb.Append("\t");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}