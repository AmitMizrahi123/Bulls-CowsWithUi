using System.Windows.Forms;

namespace Final_project.Ui
{
    public class ButtonEndGuessing : Button
    {
        private readonly int r_ButtonIndex;

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
    }
}
