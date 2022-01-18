using Final_Project.Enum;

namespace Final_Project.Model
{
    public class BoardModel
    {
        private const int k_DefaultArraySize = 4;
        private readonly int r_BoardSize;
        private readonly eGuessLetter[,] r_GuessingLetters;
        private readonly eGuessResult[,] r_GuessingResult;

        public BoardModel(int i_BoardSize)
        {
            r_BoardSize = i_BoardSize;
            r_GuessingLetters = new eGuessLetter[i_BoardSize, k_DefaultArraySize];
            r_GuessingResult = new eGuessResult[i_BoardSize, k_DefaultArraySize];
        }

        public int DefaultArraySize
        {
            get
            {
                return k_DefaultArraySize;
            }
        }

        public int BoardSize
        {
            get
            {
                return r_BoardSize;
            }
        }

        public eGuessLetter[,] GuessingLetters
        {
            get
            {
                return r_GuessingLetters;
            }
        }

        public eGuessResult[,] GuessingResult
        {
            get
            {
                return r_GuessingResult;
            }
        }
    }
}
