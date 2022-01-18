using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using A22_Ex05.Model;

namespace A22_Ex05.Ui
{
    public class FlowLayoutPanelColor : Form
    {
        private readonly List<Color> r_Colors;
        private readonly GameSettingsModel r_GameSettingsModel;

        public FlowLayoutPanelColor(ref GameSettingsModel io_GameSettingsModel)
        {
            r_Colors = new List<Color>()
            {
                Color.Purple,
                Color.Red,
                Color.Green,
                Color.SkyBlue,
                Color.Blue,
                Color.Yellow,
                Color.Brown,
                Color.White
            };
            r_GameSettingsModel = io_GameSettingsModel;
            initializeComponents();
        }

        private void initializeComponents()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(260, 200);
            for(int i = 0; i < 8; i++)
            {
                Button button;

                if(i <= 3)
                {
                    button = new Button()
                    {
                        Size = new Size(40, 40),
                        Location = new Point((i * 60) + 10, 10),
                        BackColor = r_Colors.ElementAt(i),
                    };
                }
                else
                {
                    button = new Button()
                    {
                        Size = new Size(40, 40),
                        Location = new Point((i * 60) - 230, 80),
                        BackColor = r_Colors.ElementAt(i),
                    };
                }

                button.Click += button_Click;
                this.Controls.Add(button);
            }
        }

        private void button_Click(object i_Sender, EventArgs i_Event)
        {
            r_GameSettingsModel.Color = ((Button)i_Sender).BackColor;
            Close();
        }
    }
}
