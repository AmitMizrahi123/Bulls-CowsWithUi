using System;
using Final_Project.Enum;
using Final_Project.Model;

namespace Final_project.Logic
{
    public class GameLogic
    {
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
            int guessingNumberFromComputer = r_Random.Next(7);
            char guessingCharFromComputer = Convert.ToChar(guessingNumberFromComputer + 'A');
            return (eGuessLetter)guessingCharFromComputer;
        }

        private bool checkIfLetterInGuessingList(eGuessLetter i_RandomGuessLetter)
        {
            return r_RandomGuessesModel.RandomGuessLetters.Contains(i_RandomGuessLetter);
        }
    }
}
