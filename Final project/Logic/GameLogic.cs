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

        public void InsertToGuessingList(List<Color> i_Color, int i_Index)
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
                case "BlueSky":
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
    }
}
