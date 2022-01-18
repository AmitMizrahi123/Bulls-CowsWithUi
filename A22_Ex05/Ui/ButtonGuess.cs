using System.Windows.Forms;

namespace A22_Ex05.Ui
{
    public class ButtonGuess : Button
    {
        private readonly int r_ButtonIndex;
        private readonly int r_ButtonNumber;

        public ButtonGuess(int i_ButtonIndex, int i_ButtonNumber)
        {
            r_ButtonIndex = i_ButtonIndex;
            r_ButtonNumber = i_ButtonNumber;
        }

        public int ButtonNumber
        {
            get
            {
                return r_ButtonNumber;
            }
        }

        public int ButtonIndex
        {
            get
            {
                return r_ButtonIndex;
            }
        }
    }
}
