using A22_Ex05.Logic;
using A22_Ex05.Model;

namespace A22_Ex05.Ui
{
    public class UiManager
    {
        private GameSettingsModel m_GameSettingsModel;
        private FormGameSettings m_FormGameSettings;
        private GameLogic m_GameLogic;
        private BoolPgia m_BoolPgia;

        public UiManager()
        {
            m_GameSettingsModel = new GameSettingsModel();
        }

        public void Execute()
        {
            m_FormGameSettings = new FormGameSettings(ref m_GameSettingsModel);
            m_FormGameSettings.ShowDialog();
            if(m_GameSettingsModel.StartGame)
            {
                m_GameLogic = new GameLogic(m_GameSettingsModel.NumberOfChances);
                m_BoolPgia = new BoolPgia(m_GameSettingsModel, m_GameLogic);
                m_BoolPgia.ShowDialog();
            }
        }
    }
}
