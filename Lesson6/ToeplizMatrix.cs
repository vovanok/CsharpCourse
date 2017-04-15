using System;

namespace Lesson6
{
    public class ToeplizMatrix : Matrix
    {
        private int[] firstRow;
        private int[] firstCol;

        public override int this[uint col, uint row]
        {
            get
            {
                uint minIndex = Math.Min(col, row);

                col -= minIndex;
                row -= minIndex;

                if ((col == 0 && row == 0) || (col > 0))
                {
                    return firstRow[col];
                }

                return firstCol[row - 1];
            }
            set
            {
                uint minIndex = Math.Min(col, row);

                col -= minIndex;
                row -= minIndex;

                if ((col == 0 && row == 0) || (col > 0))
                {
                    firstRow[col] = value;
                    return;
                }

                firstCol[row - 1] = value;
            }
        }

        public ToeplizMatrix(uint colCount, uint rowCount)
            : base(colCount, rowCount)
        {
        }

        protected override void InitData()
        {
            firstRow = new int[ColCount];
            firstCol = new int[RowCount - 1];
        }

        public override Matrix Sum(Matrix otherMatrix)
        {
            ToeplizMatrix tMat = otherMatrix as ToeplizMatrix;
            if (tMat == null)
                return base.Sum(otherMatrix);

            // TODO проверки
            ToeplizMatrix sumResult = new ToeplizMatrix(ColCount, RowCount);
            for (int col = 0; col < ColCount; col++)
            {
                sumResult.firstRow[col] = firstRow[col] + tMat.firstRow[col];
            }

            for (int row = 0; row < RowCount - 1; row++)
            {
                sumResult.firstCol[row] = firstCol[row] + tMat.firstCol[row];
            }

            return sumResult;
        }
    }
}
