using System;
using System.Windows.Forms;
using Final_project.Model;

namespace Final_project.Ui
{
    public partial class FormGameSettings : Form
    {
        private readonly GameSettingsModel r_GameSettingsModel;
        private const int k_MaximumNumberOfChances = 10;
        private const int k_DefaultNumberOfChances = 4;

        public FormGameSettings(ref GameSettingsModel io_GameSettingsModel)
        {
            r_GameSettingsModel = io_GameSettingsModel;
            InitializeComponent();
        }

        private void formGameSettings_Load(object i_Sender, EventArgs i_Event)
        {
            m_ButtonNumberOfChances.Text = $@"Number of changes: {r_GameSettingsModel.NumberOfChances}";
        }

        private void buttonNumberOfChances_Click(object i_Sender, EventArgs i_Event)
        {
            r_GameSettingsModel.NumberOfChances++;
            if(r_GameSettingsModel.NumberOfChances > k_MaximumNumberOfChances)
            {
                r_GameSettingsModel.NumberOfChances = k_DefaultNumberOfChances;
            }

            m_ButtonNumberOfChances.Text = $@"Number of changes: {r_GameSettingsModel.NumberOfChances}";
        }

        private void buttonStart_Click(object i_Sender, EventArgs i_Event)
        {
            r_GameSettingsModel.StartGame = true;
            Close();
        }
    }
}
