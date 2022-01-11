using System.Windows.Forms;

namespace Final_project.Ui
{
    public class ButtonsBoard : Button
    {
        private readonly int r_ButtonNumber;

        public ButtonsBoard(int i_Number)
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
