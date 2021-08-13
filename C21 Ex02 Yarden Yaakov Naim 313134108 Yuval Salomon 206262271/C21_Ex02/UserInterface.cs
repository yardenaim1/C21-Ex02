using System;
using System.Threading;

namespace C21_Ex02
{
    public class UserInterface
    {
        public void Run()
        {
            getBoardSize(out int rows, out int cols);
            FourInARow game = new FourInARow(rows, cols, getGameStyle());
            bool isGameOver = false;

            while (!isGameOver)
            {
                roundOfTheGame(ref isGameOver, game);
                game.ResetBoard();
            }
          
            Ex02.ConsoleUtils.Screen.Clear();
            gameOver(game);
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadLine();
        }

        private void roundOfTheGame(ref bool io_GameOver, FourInARow i_Game)
        {
            FourInARow.eStatesOfGame currentState = FourInARow.eStatesOfGame.Continue;
           
            i_Game.CurrentPlayer = i_Game.Player1;
            while (!io_GameOver)
            {
                int nextMove;

                Ex02.ConsoleUtils.Screen.Clear();
                i_Game.ShowBoard();
                showTurn(i_Game.CurrentPlayer);
                if (i_Game.CurrentPlayer.IsHuman())
                {
                    nextMove = getUserMove(out bool isQuit, i_Game.board);
                    if(!isQuit)
                    {
                        i_Game.MakeMove(nextMove, i_Game.CurrentPlayer, out int o_RowInserted);
                        currentState = i_Game.GetCurrentStateOfGame(o_RowInserted, nextMove);
                    }
                    else
                    {
                        currentState = FourInARow.eStatesOfGame.Quit;
                    }
                }
                else
                {
                    nextMove = i_Game.GetAiNextMove();
                    i_Game.MakeMove(nextMove, i_Game.CurrentPlayer, out int o_RowInserted);
                    currentState = i_Game.GetCurrentStateOfGame(o_RowInserted, nextMove);
                }

                io_GameOver = currentState == FourInARow.eStatesOfGame.Draw
                              || currentState == FourInARow.eStatesOfGame.Lose
                              || currentState == FourInARow.eStatesOfGame.Quit;

                if (!io_GameOver)
                {
                    i_Game.CurrentPlayer = i_Game.CurrentPlayer == i_Game.Player1 ? i_Game.Player2 : i_Game.Player1;
                }
            }

            Ex02.ConsoleUtils.Screen.Clear();
            i_Game.ShowBoard();
            endOfRound(ref currentState, i_Game);
            io_GameOver = currentState != FourInARow.eStatesOfGame.ReTry;
        }
        
        private void getBoardSize(out int o_Rows, out int o_Cols)
        {
            Console.WriteLine("Please enter a desired board size ( rows and cols between 4 - 8 ):");
            Console.Write("Rows:");
            bool rowsIsNumber = int.TryParse(Console.ReadLine(), out o_Rows);
            while (rowsIsNumber == false || Board.IsValidSize(o_Rows) == false)
            {
                Console.WriteLine("Please enter a number between 4 - 8 (and then press 'enter')");
                rowsIsNumber = int.TryParse(Console.ReadLine(), out o_Rows);
            }

            Console.Write("Cols:");
            bool colsIsNumber = int.TryParse(Console.ReadLine(), out o_Cols);
            while (colsIsNumber == false || Board.IsValidSize(o_Cols) == false)
            {
                Console.WriteLine("Please enter a number between 4 - 8 (and then press 'enter')");
                colsIsNumber = int.TryParse(Console.ReadLine(), out o_Cols);
            }
        }

        private FourInARow.eGameStyle getGameStyle()
        {
            string msg = @"Please choose game style:
1.Player vs Player
2.Player vs Computer";

            Console.WriteLine(msg);
            bool isValidInput = int.TryParse(Console.ReadLine(), out int userChoice);
            while(isValidInput == false || (userChoice != 1 && userChoice != 2))
            {
                Console.WriteLine("invalid input for game style, please try again:");
                isValidInput = int.TryParse(Console.ReadLine(), out userChoice);
            }

            return (FourInARow.eGameStyle)userChoice;
        }

        private int getUserMove(out bool o_QisEntered, Board i_GameBoard)
        {
            int columnFromUser;
           
            o_QisEntered = false;
            Console.WriteLine("Please enter column number or Q for quit this round: ");
            string userInput = Console.ReadLine();

            while((userInput != "Q" && !int.TryParse(userInput, out columnFromUser)) ||
                  (int.TryParse(userInput, out columnFromUser) && !i_GameBoard.IsValidCol(columnFromUser)))
            {
                if(int.TryParse(userInput, out columnFromUser) && !i_GameBoard.IsValidCol(columnFromUser))
                {
                    Console.WriteLine("The column you entered is not valid!");
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }

                userInput = Console.ReadLine();
            }

            if(userInput == "Q")
            {
                o_QisEntered = true;
            }

            return columnFromUser;
        }

        private void endOfRound(ref FourInARow.eStatesOfGame i_CurrentState, FourInARow i_Game)
        {
            i_Game.RoundOver(i_CurrentState, i_Game.CurrentPlayer);
            switch(i_CurrentState)
            {
                case FourInARow.eStatesOfGame.Quit:
                    {
                        quit(i_Game.CurrentPlayer.PlayerType);
                        break;
                    }

                case FourInARow.eStatesOfGame.Draw:
                    {
                        draw();
                        break;
                    }

                case FourInARow.eStatesOfGame.Lose:
                    {
                        lose(i_Game.CurrentPlayer.PlayerType);
                        break;
                    }
            }

            showScore(i_Game.Player1, i_Game.Player2);
            i_CurrentState = anotherRoundQuery() ? FourInARow.eStatesOfGame.ReTry : FourInARow.eStatesOfGame.GameOver;
        }

        private void lose(Player.ePlayerType i_WinnerPlayerType)
        {
            Console.WriteLine(i_WinnerPlayerType + " win!");
        }

        private void draw()
        {
            Console.WriteLine("Its a Draw!");
        }

        private void quit(Player.ePlayerType i_QuitPlayerType)
        {
            Console.WriteLine(i_QuitPlayerType + " quit!");
        }

        private bool anotherRoundQuery()
        {
            int userChoice;

        Console.WriteLine(@"Do you want to continue playing?
1. Yes
2. No");
            while(!int.TryParse(Console.ReadLine(), out userChoice) || (userChoice < 1 || userChoice > 2))
            {
                Console.WriteLine("invalid choice, Please try again");
            }

            return userChoice == 1;
        }

        private void showScore(Player i_Player1, Player i_Player2)
        {
Console.WriteLine( 
    @"Score:
=======
{0} - {1}
{2} - {3}",
    i_Player1.PlayerType,
    i_Player1.Score,
    i_Player2.PlayerType,
    i_Player2.Score);
        }

        private void showTurn(Player i_CurrentPlayer)
        {
            switch(i_CurrentPlayer.PlayerType)
            {
                case Player.ePlayerType.Player1:
                    {
                        Console.WriteLine("Player 1 turn");
                        break;
                    }

                case Player.ePlayerType.Player2:
                    {
                        Console.WriteLine("Player 2 turn");
                        break;
                    }

                case Player.ePlayerType.Computer:
                    {
                        Console.WriteLine("Computer  turn:");
                        Console.WriteLine("Computer thinking...");
                        Thread.Sleep(400);
                        break;
                    }
            }
        }

        private void gameOver(FourInARow i_Game)
        {
            Player winnerPlayer = i_Game.Player1.Score > i_Game.Player2.Score ? i_Game.Player1 : i_Game.Player2;
            Player loserPlayer = winnerPlayer == i_Game.Player1 ? i_Game.Player2 : i_Game.Player1;
           
            Console.WriteLine("Game Over!");
            if(i_Game.Player1.Score == i_Game.Player2.Score)
            {
                Console.WriteLine("It's a Draw!");
            }
            else
            {
                Console.WriteLine(
                @"The Winner is:
{0} with  {1} points
{2} Good luck next time!",
                    winnerPlayer.PlayerType,
                    winnerPlayer.Score,
                    loserPlayer.PlayerType);
            }
        }
    }
}
