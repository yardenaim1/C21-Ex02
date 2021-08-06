namespace C21_Ex02
{
    using System;

    public class FourInARow
    {
        private Board m_Board;
        private Player m_Player1, m_Player2;

        public FourInARow()
        {
            this.m_Board = null;
            this.m_Player1 = new Player(Player.ePlayerType.Player, 'X');
            this.m_Player2 = null;
        }

        public void Run()
        {
            initGame();
            bool GameOver = false;

            int userColChoise = 0;
            while (GameOver == false)//GameOn
            {
                Ex02.ConsoleUtils.Screen.Clear();
                this.m_Board.PrintBoard();

                GameOver = UI.GetUserMove(ref userColChoise);
                GameLogic.MakeMove(userColChoise, this.m_Board, '?');
            }
        }

        private void initGame()
        {
            UI.GetBoardSize(out int rows, out int cols);
            this.m_Board = new Board(rows, cols);
            eGameStyle gameStyle = UI.GetGameStyle();
            if (gameStyle == eGameStyle.PlayerVsComputer)
            {
                this.m_Player2 = new Player(Player.ePlayerType.Computer, 'O');
            }
            else
            {
                this.m_Player2 = new Player(Player.ePlayerType.Player, 'O');
            }
        }

        public enum eGameStyle
        {
            PlayerVsPlayer = 1,
            PlayerVsComputer
        }
    }
}
