namespace C21_Ex02
{
    using System;

    public static class GameLogic
    {
        public static void MakeMoveOfPlayer(Player i_Player, ref bool o_GameOver, Board i_GameBoard)
        {
            int columnFromUser = 0;
            bool isQ = false;

            UI.GetUserMove(ref columnFromUser, ref isQ);
            while(i_GameBoard.IsValidCol(columnFromUser) == false)
            {
                Console.WriteLine("The column you entered is not valid!");
                UI.GetUserMove(ref columnFromUser, ref isQ);
            }

            if (isQ == true)
            {
                o_GameOver = true;
                return;
            }

            MakeMove(columnFromUser, i_GameBoard, i_Player);
        }

        private static void MakeMove(int i_CurrentMove, Board i_GameBoard, Player i_Player)
        {
          i_GameBoard.AddMove(i_CurrentMove, i_Player.Sign);
          // i_GameBoard.check.....

        }

    }
}
