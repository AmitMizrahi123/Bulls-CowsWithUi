using System;
using System.Windows.Forms;
using Final_project.Model;

namespace Final_project.Ui
{
    public partial class FormGameSettings : Form
    {
        private readonly GameSettingsModel r_GameSettingsModel;

        public FormGameSettings(ref GameSettingsModel i_GameSettingsModel)
        {
            r_GameSettingsModel = i_GameSettingsModel;
            InitializeComponent();
        }

        private void formGameSettings_Load(object sender, EventArgs e)
        {
            m_ButtonNumberOfChances.Text = $@"Number of changes: {r_GameSettingsModel.NumberOfChances}";
        }

        private void buttonNumberOfChances_Click(object sender, EventArgs e)
        {
            r_GameSettingsModel.NumberOfChances++;
            if(r_GameSettingsModel.NumberOfChances > 10)
            {
                r_GameSettingsModel.NumberOfChances = 4;
            }

            m_ButtonNumberOfChances.Text = $@"Number of changes: {r_GameSettingsModel.NumberOfChances}";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            r_GameSettingsModel.StartGame = true;
            Close();
        }
    }
}
