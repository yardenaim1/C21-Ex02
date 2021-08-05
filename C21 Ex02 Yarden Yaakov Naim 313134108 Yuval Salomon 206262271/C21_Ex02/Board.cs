namespace C21_Ex02
{
    using System;

    public class Board // public???
    {
        private readonly int r_RowSize, r_ColSize;
        private char[,] m_Board = null;

        public Board(int i_Rows, int i_Cols)
        {
            r_ColSize = i_Cols;
            r_RowSize = i_Rows;
            m_Board = new char[i_Rows, i_Cols];

            for (int i = 0; i < i_Rows; i++)
            {
                for (int j = 0; j < i_Cols; j++)
                {
                    m_Board[i, j] = ' ';
                }
            }
        }

        public void PrintBoard()
        {
            for(int row = 0; row <= r_RowSize; row++)
            {
               for(int col = 0; col < r_ColSize; col++)
               {
                    if (row == 0)
                    {
                        Console.Write("  {0} ", col + 1);
                    }
                    else
                    {
                        Console.Write("| {0} ", GetValueInCell(row - 1, col));
                        if(col == this.r_ColSize - 1)
                        {
                            Console.Write("|");
                        }
                    }
               }

               Console.WriteLine();
               if(row != 0)
               {
                   string sepLine = "====";
                   for(int i = 0; i < this.r_ColSize; i++)
                   {
                       Console.Write(sepLine);
                   }

                   Console.WriteLine("=");
               }
            }
        }

        public static bool IsValidSize(int i_size)
        {
            return i_size >= 4 && i_size <= 8;
        }

        public char GetValueInCell(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col];
        }
    }
}
