using Final_project.Model;

namespace Final_project.Ui
{
    public class UiManager
    {
        private FormGameSettings m_FormGameSettings;
        private GameSettingsModel m_GameSettingsModel = new GameSettingsModel();

        public void Execute()
        {
            m_FormGameSettings = new FormGameSettings(ref m_GameSettingsModel);
            m_FormGameSettings.ShowDialog();
        }
    }
}
