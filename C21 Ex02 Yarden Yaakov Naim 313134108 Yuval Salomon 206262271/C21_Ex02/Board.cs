namespace C21_Ex02
{
    using System;
    using System.Threading;

    public class Board // public???
    {
        public Board(int i_Rows, int i_Cols)
        {
            char[,] Board = new char[i_Rows, i_Cols];
        }

        private static void getBoardSize()
        {
            int numOfRows = 0, numOfCols = 0;
            Console.WriteLine("Please enter a desired board size ( rows and cols between 4 - 8 ):");
            Console.Write("Rows:");
            bool rowsIsNumber = int.TryParse(System.Console.ReadLine(), out numOfRows);
            while(numOfRows < 4 || numOfRows > 8 || rowsIsNumber == false)
            {
                Console.WriteLine("Please enter a number between 4 - 8 (and then press 'enter')");
                rowsIsNumber = int.TryParse(System.Console.ReadLine(), out numOfRows);
            }

            Console.Write("Cols:");
            bool colsIsNumber = int.TryParse(System.Console.ReadLine(), out numOfCols);
            while (numOfCols < 4 || numOfCols > 8 || colsIsNumber == false)
            {
                Console.WriteLine("Please enter a number between 4 - 8 (and then press 'enter')");
                colsIsNumber = int.TryParse(System.Console.ReadLine(), out numOfCols);
            }

            Board board = new Board(numOfRows, numOfCols);
        }
    }
}
