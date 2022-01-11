using System.Collections.Generic;
using Final_Project.Enum;

namespace Final_Project.Model
{
    public class RandomGuessesModel
    {
        private readonly List<eGuessLetter> r_RandomGuessLetters;

        public RandomGuessesModel()
        {
            r_RandomGuessLetters = new List<eGuessLetter>();
        }

        public List<eGuessLetter> RandomGuessLetters
        {
            get
            {
                return r_RandomGuessLetters;
            }
        }
    }
}