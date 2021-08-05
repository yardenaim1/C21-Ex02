namespace C21_Ex02
{
    public class Player
    {
        private ePlayerType m_Type;

        private char m_Sign;

        private int m_Score;

        public Player(ePlayerType i_Type, char i_Sign)
        {
            this.m_Type = i_Type;
            this.m_Sign = i_Sign;
        }

        public ePlayerType PlayerType
        {
            get
            {
                return m_Type;
            }

            set
            {
                m_Type = value;
            }
        }

        public char Sign
        {
            get
            {
                return this.m_Sign;
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
                return this.m_Score;
            }

            set
            {
                this.m_Score = value;
            }
        }

        public enum ePlayerType
        {
            Player = 1,
            Computer
        }
    }
}
