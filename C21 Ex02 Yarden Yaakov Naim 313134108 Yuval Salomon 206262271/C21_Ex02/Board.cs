namespace C21_Ex02
{
    using System;

    public class Board
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

        public bool AddMove(int i_Col, char i_Sign)
        {
            bool addedMove = false;

            if (checkValidCol(i_Col) == true)
            {
                int row = r_RowSize;
                bool setDone = false;
                while (row > 0 && setDone == false)
                {
                    if (this.m_Board[row - 1, i_Col - 1] != ' ')
                    {
                        row--;
                    }
                    else
                    {
                        setCell(row - 1, i_Col - 1, i_Sign);
                        setDone = true;
                        /*if (winnerCheckLine(i_Sign) || winnerCheckCol(i_Sign, i_Col - 1) || winnerCheckDiagonal(i_Sign))
                        {
                            Ex02.ConsoleUtils.Screen.Clear();
                            PrintBoard();
                            if (i_Sign == 'X')
                            {
                                Console.WriteLine("Player number 1 won! :)");
                            }
                            else
                            {
                                Console.WriteLine("Player number 2 won! :)");
                            }

                            //return false; היה ככה בפרויקט מסמסטר א'
                        }*/
                        //return true;היה ככה בפרויקט מסמסטר א'
                    }
                }

                addedMove = true;
            }
            else
            {
                Console.WriteLine("The column you entered is full");
                addedMove = false;
            }

            return addedMove;
        }

        private void setCell(int i_row, int i_Col, char i_Sign)
        {
            this.m_Board[i_row, i_Col] = i_Sign;
        }

        private bool checkValidCol(int i_Col)
        {
            return this.m_Board[0, i_Col] == ' ';
        }
    }
}
