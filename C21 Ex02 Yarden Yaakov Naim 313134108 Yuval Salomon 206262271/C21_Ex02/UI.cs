namespace C21_Ex02
{
    using System;

    public static class UI
    {
        public static void GetBoardSize(out int o_Rows, out int o_Cols)
        {
            Console.WriteLine("Please enter a desired board size ( rows and cols between 4 - 8 ):");
            Console.Write("Rows:");
            bool rowsIsNumber = int.TryParse(System.Console.ReadLine(), out o_Rows);
            while (rowsIsNumber == false || Board.IsValidSize((o_Rows)) == false)
            {
                Console.WriteLine("Please enter a number between 4 - 8 (and then press 'enter')");
                rowsIsNumber = int.TryParse(System.Console.ReadLine(), out o_Rows);
            }

            Console.Write("Cols:");
            bool colsIsNumber = int.TryParse(System.Console.ReadLine(), out o_Cols);
            while (colsIsNumber == false || Board.IsValidSize((o_Cols)) == false)
            {
                Console.WriteLine("Please enter a number between 4 - 8 (and then press 'enter')");
                colsIsNumber = int.TryParse(System.Console.ReadLine(), out o_Cols);
            }
        }

        public static FourInARow.eGameStyle GetGameStyle()
        {
            string msg = String.Format
            (@"Please choose game style:
1.Player vs Player
2.Player vs Computer");

            Console.WriteLine(msg);
            bool isValidInput = int.TryParse(Console.ReadLine(), out int userChoice);

            while(isValidInput == false || (userChoice != 1 && userChoice != 2))
            {
                Console.WriteLine("invalid input for game style, please try again:");
                isValidInput = int.TryParse(Console.ReadLine(), out userChoice);
            }

            return (FourInARow.eGameStyle)userChoice;
        }

        public static bool GetUserMove(ref int io_CurrentPlay)
        {
            Console.WriteLine(String.Format(@"
Select the column into which you want to toss your coin."));
            string userInput = Console.ReadLine();
            if(userInput != "Q")
            {
                bool isValidCol = int.TryParse(userInput, out io_CurrentPlay);
                while (isValidCol == false || io_CurrentPlay < 1 || io_CurrentPlay > 8 || userInput.Equals("Q"))
                {
                    Console.WriteLine("invalid col, please try again");
                    userInput = Console.ReadLine();
                    isValidCol = int.TryParse(userInput, out io_CurrentPlay);
                }
            }
            else
            {
                // end round
            }

            return userInput.Equals("Q");
        }
    }
}
