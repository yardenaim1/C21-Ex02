namespace C21_Ex02
{
    using System;

    public class Board
    {
        private readonly int r_RowSize, r_ColSize;
        private char[,] m_Board = null;

        public int Column
        {
            get
            {
                return this.r_ColSize;
            }
        }

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
                        Console.Write("| {0} ", GetValueInCell(row - 1 , col));
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

        public void AddMove(int i_Col, char i_Sign)
        {
            int row = r_RowSize;
            bool setDone = false;

            while (row > 0 && setDone == false)
            {
                if (m_Board[row - 1, i_Col - 1] != ' ')
                {
                    row--;
                }
                else
                {
                    setCell(row - 1, i_Col - 1, i_Sign);
                    setDone = true;
                }
            }
        }

        private void setCell(int i_row, int i_Col, char i_Sign)
        {
            this.m_Board[i_row, i_Col] = i_Sign;
        }

        public bool IsValidCol(int i_Col)
        {
            return i_Col >= 1 && i_Col <= this.r_ColSize && m_Board[0, i_Col - 1] == ' ';
        }
    }
}

