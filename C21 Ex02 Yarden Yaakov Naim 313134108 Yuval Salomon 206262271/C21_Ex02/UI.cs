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

        public static void GetUserMove(ref int o_ColumnFromUser, ref bool o_QisEntered)
        {
            Console.WriteLine("Please enter column number or Q for quit this round: ");
            string userInput = Console.ReadLine();

            while(userInput != "Q" && int.TryParse(userInput, out o_ColumnFromUser) == false)
            {
                Console.WriteLine("Invalid input, try again");
                userInput = Console.ReadLine();
            }

            if(userInput == "Q")
            {
                o_QisEntered = true;
            }
        }
    }
}
