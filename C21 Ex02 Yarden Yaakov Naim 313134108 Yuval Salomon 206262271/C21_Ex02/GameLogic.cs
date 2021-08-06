namespace C21_Ex02
{
    public static class GameLogic
    {
        public static bool MakeMove(int i_CurrentMove, Board i_GameBoard, char i_PlayerSign)
        {
            return (i_GameBoard.AddMove(i_CurrentMove, i_PlayerSign));
        }
    }
}
