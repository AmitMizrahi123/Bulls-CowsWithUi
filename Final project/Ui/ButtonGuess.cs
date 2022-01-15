using System.Windows.Forms;

namespace Final_project.Ui
{
    public class ButtonGuess : Button
    {
        private readonly int r_ButtonNumber;
        private readonly int r_ButtonIndex;

        public ButtonGuess(int i_ButtonNumber, int i_ButtonIndex)
        {
            r_ButtonNumber = i_ButtonNumber;
            r_ButtonIndex = i_ButtonIndex;
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
