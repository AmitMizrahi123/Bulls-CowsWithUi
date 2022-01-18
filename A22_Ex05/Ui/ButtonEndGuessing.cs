using System.Windows.Forms;

namespace A22_Ex05.Ui
{
    public class ButtonEndGuessing : Button
    {
        private readonly int r_ButtonIndex;
        private static int s_CountButtonPressed;

        public ButtonEndGuessing(int i_ButtonIndex)
        {
            r_ButtonIndex = i_ButtonIndex;
        }

        public int ButtonIndex
        {
            get
            {
                return r_ButtonIndex;
            }
        }

        public int CountButtonPressed
        {
            get
            {
                return s_CountButtonPressed;
            }
            set
            {
                s_CountButtonPressed = value;
            }
        }
    }
}
