using System.Windows.Forms;

namespace Final_project.Ui
{
    public class ButtonsEndGuessing : Button
    {
        private readonly int r_ButtonNumber;

        public ButtonsEndGuessing(int i_Number)
        {
            r_ButtonNumber = i_Number;
        }

        public int ButtonNumber
        {
            get
            {
                return r_ButtonNumber;
            }
        }
    }
}
