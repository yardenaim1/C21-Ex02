namespace C21_Ex02
{
    public class Player
    {
        private ePlayerType m_PlayerType;
        private char m_Sign;
        private int m_Score = 0;

        public Player(ePlayerType i_Type, char i_Sign)
        {
            m_PlayerType = i_Type;
            m_Sign = i_Sign;
        }

        public ePlayerType PlayerType
        {
            get
            {
                return m_PlayerType;
            }

            set
            {
                m_PlayerType = value;
            }
        }

        public char Sign
        {
            get
            {
                return m_Sign;
            }
            
            set
            {
                m_Sign = value;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
            
            set
            {
                m_Score = value;
            }
        }

        public bool IsHuman()
        {
            return this.PlayerType == ePlayerType.Player1 || this.PlayerType == ePlayerType.Player2;
        }

        public enum ePlayerType
        {
            Player1,
            Player2,
            Computer
        }
    }
}
