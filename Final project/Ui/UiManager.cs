using Final_project.Logic;
using Final_project.Model;

namespace Final_project.Ui
{
    public class UiManager
    {
        private FormGameSettings m_FormGameSettings;
        private GameSettingsModel m_GameSettingsModel = new GameSettingsModel();
        private GameLogic m_GameLogic;

        public void Execute()
        {
            m_FormGameSettings = new FormGameSettings(ref m_GameSettingsModel);
            m_FormGameSettings.ShowDialog();
            if(m_GameSettingsModel.StartGame)
            {
                m_GameLogic = new GameLogic(m_GameSettingsModel.NumberOfChances);
            }
        }
    }
}
