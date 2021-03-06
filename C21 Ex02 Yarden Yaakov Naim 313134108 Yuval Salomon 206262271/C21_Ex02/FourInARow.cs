namespace C21_Ex02
{
    public class FourInARow
    {
        private Board m_Board;
        private Player m_Player1, m_Player2, m_CurrentPlayer;

        public FourInARow(int i_Row, int i_Col, eGameStyle i_GameStyle)
        {
            m_Board = new Board(i_Row, i_Col);
            m_Player1 = new Player(Player.ePlayerType.Player1, 'X');
            m_Player2 = i_GameStyle == eGameStyle.PlayerVsComputer ? 
                            new Player(Player.ePlayerType.Computer, 'O') : 
                            new Player(Player.ePlayerType.Player2, 'O');
        }

        public Board board
        {
            get
            {
                return this.m_Board;
            }
        }

        public Player Player1
        {
            get
            {
                return m_Player1;
            }

            set
            {
                m_Player1 = value;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }

            set
            {
                m_Player2 = value;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }

            set
            {
                m_CurrentPlayer = value;
            }
        }

        public void RoundOver(eStatesOfGame i_CurrentState, Player i_CurrentPlayer)
        {
            switch(i_CurrentState)
            {
                case eStatesOfGame.Quit:
                    {
                        if(i_CurrentPlayer == m_Player1)
                        {
                            m_Player2.Score++;
                        }
                        else
                        {
                            m_Player1.Score++;
                        }

                        break;
                    }

                case eStatesOfGame.Lose:
                    {
                        i_CurrentPlayer.Score++;
                        break;
                    }
            }
        }

        public bool IsValidInput(int i_ColumnFromUser)
        {
            return m_Board.IsValidCol(i_ColumnFromUser);
        }

        public int GetAiNextMove()
        {
            int bestScore = int.MinValue;
            int bestMove = 0;

            for(int col = 1; col <= this.m_Board.Column; col++)
            {
                if(!this.IsValidInput(col))
                {
                    continue;
                }

                m_Board.AddMove(col, this.m_CurrentPlayer.Sign, out int o_Row);
                if (this.m_Board.IsWinnerMove(o_Row, col))
                {
                    bestMove = col;
                    this.m_Board.SetCell(o_Row - 1, col - 1, ' ');
                    break;
                }

                int score = this.miniMax(this.m_Board, 5, false, col, o_Row);
                this.m_Board.SetCell(o_Row - 1, col - 1, ' ');
                if(score <= bestScore)
                {
                    continue;
                }

                bestScore = score;
                bestMove = col;
            }

            return bestMove;
        }

        private int miniMax(Board i_GameBoard, int i_Depth, bool i_IsMaximizing, int i_LastCol, int i_LastRow)
        {
            int bestScore;
           bool isPlayerWin = i_GameBoard.IsWinnerMove(i_LastRow, i_LastCol);
           bool isDraw = i_GameBoard.IsDraw();
           bool isOver = isPlayerWin || isDraw || i_Depth == 0;

           if(isOver)
           {
               if(isPlayerWin)
               {
                   bestScore = i_IsMaximizing ? -1000000 : 1000000;
               }
               else if(isDraw)
               {
                   bestScore = 0;
               }
               else 
               {
                   bestScore = i_GameBoard.ScoreOfBoard();
               }
           }
           else
           {
               if(i_IsMaximizing)
               {
                   bestScore = int.MinValue;
                   for(int col = 1; col <= i_GameBoard.Column; col++)
                   {
                       if(!IsValidInput(col))
                       {
                           continue;
                       }

                       i_GameBoard.AddMove(col, 'O', out int o_Row);
                       int score = this.miniMax(i_GameBoard, i_Depth - 1, false, col, o_Row);
                       i_GameBoard.SetCell(o_Row - 1, col - 1, ' ');
                       bestScore = System.Math.Max(bestScore, score);
                   }
               }
               else
               {
                   bestScore = int.MaxValue;
                   for(int col = 1; col <= i_GameBoard.Column; col++)
                   {
                       if(!IsValidInput(col))
                       {
                           continue;
                       }

                       i_GameBoard.AddMove(col, 'X', out int o_Row);
                       int score = this.miniMax(i_GameBoard, i_Depth - 1, true, col, o_Row);
                       i_GameBoard.SetCell(o_Row - 1, col - 1, ' ');
                       bestScore = System.Math.Min(bestScore, score);
                   }
               }
           }

           return bestScore;
        }

        public void MakeMove(int i_ColumnFromUser, Player i_Player, out int o_RowInserted)
        {
            m_Board.AddMove(i_ColumnFromUser, i_Player.Sign, out o_RowInserted);
        }

        public eStatesOfGame GetCurrentStateOfGame(int i_LastRowInserted, int i_LastColInserted)
        {
            eStatesOfGame resultState = eStatesOfGame.Continue;

            if(m_Board.IsWinnerMove(i_LastRowInserted, i_LastColInserted))
            {
                resultState = eStatesOfGame.Lose;
            }
            else if(m_Board.IsDraw())
            {
                resultState = eStatesOfGame.Draw;
            }

            return resultState;
        }

        public void ResetBoard()
        {
            this.m_Board.ClearBoard();
        }

        public void ShowBoard()
        {
            this.m_Board.PrintBoard();
        }

        public enum eGameStyle
        {
            PlayerVsPlayer = 1,
            PlayerVsComputer
        }

        public enum eStatesOfGame
        {
            Continue,
            ReTry,
            GameOver,
            Draw,
            Quit,
            Lose
        }
    }
}
