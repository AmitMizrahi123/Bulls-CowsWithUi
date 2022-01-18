using System.Collections.Generic;
using A22_Ex05.Enum;

namespace A22_Ex05.Model
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