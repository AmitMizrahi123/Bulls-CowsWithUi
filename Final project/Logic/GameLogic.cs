using System;
using System.Collections.Generic;
using System.Drawing;
using Final_Project.Enum;
using Final_Project.Model;

namespace Final_project.Logic
{
    public class GameLogic
    {
        private const int k_MaximumRandomNumber = 7;
        private const char k_UpdateConvertingChar = 'A';
        private readonly RandomGuessesModel r_RandomGuessesModel;
        private readonly BoardModel r_BoardModel;
        private readonly Random r_Random;

        public GameLogic(int i_NumberOfChances)
        {
            r_Random = new Random();
            r_RandomGuessesModel = new RandomGuessesModel();
            r_BoardModel = new BoardModel(i_NumberOfChances);
            initializeGame();
        }

        private void initializeGame()
        {
            generateGuessingComputer();
        }

        private void generateGuessingComputer()
        {
            while (r_RandomGuessesModel.RandomGuessLetters.Count != r_BoardModel.DefaultArraySize)
            {
                eGuessLetter randomGuessLetter = getRandomGuessLetter();

                while (checkIfLetterInGuessingList(randomGuessLetter))
                {
                    randomGuessLetter = getRandomGuessLetter();
                }

                r_RandomGuessesModel.RandomGuessLetters.Add(randomGuessLetter);
            }
        }

        private eGuessLetter getRandomGuessLetter()
        {
            int guessingNumberFromComputer = r_Random.Next(k_MaximumRandomNumber);
            char guessingCharFromComputer = Convert.ToChar(guessingNumberFromComputer + k_UpdateConvertingChar);
            return (eGuessLetter)guessingCharFromComputer;
        }

        private bool checkIfLetterInGuessingList(eGuessLetter i_RandomGuessLetter)
        {
            return r_RandomGuessesModel.RandomGuessLetters.Contains(i_RandomGuessLetter);
        }

        public void InsertToGuessingLetters(List<Color> i_Color, int i_Index)
        {
            int index = 0;

            foreach(Color color in i_Color)
            {
                eGuessLetter guessLetter = convertColorToGuessLetterEnum(color);

                r_BoardModel.GuessingLetters[i_Index, index++] = guessLetter;
            }
        }

        private eGuessLetter convertColorToGuessLetterEnum(Color i_Color)
        {
            eGuessLetter guessLetter;

            switch(i_Color.Name)
            {
                case "Purple":
                    guessLetter = eGuessLetter.A;
                    break;
                case "Red":
                    guessLetter = eGuessLetter.B;
                    break;
                case "Green":
                    guessLetter = eGuessLetter.C;
                    break;
                case "SkyBlue":
                    guessLetter = eGuessLetter.D;
                    break;
                case "Blue":
                    guessLetter = eGuessLetter.E;
                    break;
                case "Yellow":
                    guessLetter = eGuessLetter.F;
                    break;
                case "Brown":
                    guessLetter = eGuessLetter.G;
                    break;
                case "White":
                    guessLetter = eGuessLetter.H;
                    break;
                default:
                    guessLetter = eGuessLetter.NotValid;
                    break;
            }

            return guessLetter;
        }

        public void ComparisonRandomGuessesToUserGuesses(int i_Index)
        {
            int guessingResultIndex = 0;

            for (int j = 0; j < r_BoardModel.DefaultArraySize; j++)
            {
                if (checkIfUserGuessEqualsToRandomGuesses(r_BoardModel, r_RandomGuessesModel.RandomGuessLetters, i_Index, j))
                {
                    r_BoardModel.GuessingResult[i_Index, guessingResultIndex++] = eGuessResult.V;
                }
            }

            for (int i = 0; i < r_RandomGuessesModel.RandomGuessLetters.Count; i++)
            {
                for (int j = 0; j < r_BoardModel.DefaultArraySize; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    eGuessLetter guessLetterFromUser = r_BoardModel.GuessingLetters[i_Index, j];
                    eGuessLetter letterFromComputer = r_RandomGuessesModel.RandomGuessLetters[i];

                    if (checkIfUserGuessEqualToRandomGuess(guessLetterFromUser, letterFromComputer))
                    {
                        r_BoardModel.GuessingResult[i_Index, guessingResultIndex++] = eGuessResult.X;
                    }
                }
            }
        }

        private bool checkIfUserGuessEqualsToRandomGuesses(BoardModel i_BoardModel, List<eGuessLetter> i_RandomGuessesNumbers, int i_Row, int i_Col)
        {
            return i_BoardModel.GuessingLetters[i_Row, i_Col].Equals(i_RandomGuessesNumbers[i_Col]);
        }

        private bool checkIfUserGuessEqualToRandomGuess(eGuessLetter i_UserGuess, eGuessLetter i_RandomGuess)
        {
            return i_UserGuess.Equals(i_RandomGuess);
        }

        public List<Color> GetGuessResultsInColors(int i_Index)
        {
            List<Color> colors = new List<Color>();

            for(int i = 0; i < r_BoardModel.DefaultArraySize; i++)
            {
                Color color = convertGuessResultEnumToColor(r_BoardModel.GuessingResult[i_Index, i]);

                colors.Add(color);
            }

            return colors;
        }

        private Color convertGuessResultEnumToColor(eGuessResult i_GuessResult)
        {
            Color color;

            switch(i_GuessResult)
            {
                case (eGuessResult.V):
                    color = Color.Black;
                    break;
                case eGuessResult.X:
                    color = Color.Yellow;
                    break;
                default:
                    color = Color.Empty;
                    break;
            }

            return color;
        }

        public bool IsWinner(int i_Index)
        {
            bool isWinner = true;

            for (int i = 0; i < 4; i++)
            {
                if (r_BoardModel.GuessingResult[i_Index, i] != eGuessResult.V)
                {
                    isWinner = false;
                    break;
                }
            }

            return isWinner;
        }

        public bool GameOver(int i_ButtonPressedCount)
        {
            return i_ButtonPressedCount.Equals(r_BoardModel.BoardSize);
        }

        public List<Color> GetRandomResultInColor()
        {
            List<Color> colors = new List<Color>();

            foreach(eGuessLetter randomGuessLetter in r_RandomGuessesModel.RandomGuessLetters)
            {
                Color color = convertRandomGuessLetterEnumToColor(randomGuessLetter);

                colors.Add(color);
            }

            return colors;
        }

        private Color convertRandomGuessLetterEnumToColor(eGuessLetter randomGuessLetter)
        {
            Color color = new Color();

            switch (randomGuessLetter)
            {
                case eGuessLetter.A:
                    color = Color.Purple;
                    break;
                case eGuessLetter.B:
                    color = Color.Red;
                    break;
                case eGuessLetter.C:
                    color = Color.Green;
                    break;
                case eGuessLetter.D:
                    color = Color.SkyBlue;
                    break;
                case eGuessLetter.E:
                    color = Color.Blue;
                    break;
                case eGuessLetter.F:
                    color = Color.Yellow;
                    break;
                case eGuessLetter.G:
                    color = Color.Brown;
                    break;
                case eGuessLetter.H:
                    color = Color.White;
                    break;
            }

            return color;
        }
    }
}
