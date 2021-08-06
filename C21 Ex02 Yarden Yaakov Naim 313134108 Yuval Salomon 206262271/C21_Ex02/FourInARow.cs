namespace C21_Ex02
{
    using System;

    public class FourInARow
    {
        private Board m_Board;
        private Player m_Player1, m_Player2, m_CurrentPlayer;

        public FourInARow()
        {
            this.m_Board = null;
            this.m_Player1 = new Player(Player.ePlayerType.Player, 'X');
            this.m_Player2 = null;
        }

        public void Run()
        {
            initGame();
            bool gameOver = false;
            int userColChoise = 0;
            
            this.m_CurrentPlayer = this.m_Player1;
            while (gameOver == false)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                this.m_Board.PrintBoard();
               
                //player
                if(this.m_CurrentPlayer.PlayerType == Player.ePlayerType.Player)
                {
                    GameLogic.MakeMoveOfPlayer(m_CurrentPlayer, ref gameOver, m_Board);
                }
                // computer plays
                else
                {
                   // GameLogic.MakeMoveOfComputer(this.m_CurrentPlayer, ref gameOver);
                }

                if(this.m_CurrentPlayer == this.m_Player1)
                {
                    this.m_CurrentPlayer = this.m_Player2;
                }
                else
                {
                    this.m_CurrentPlayer = this.m_Player1;
                }
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
