using System.Drawing;

namespace A22_Ex05.Model
{
    public class GameSettingsModel
    {
        public int NumberOfChances { get; set; } = 4;
        public bool StartGame { get; set; } = false;
        public int DefaultNumberOfGuessing { get; } = 4;
    }
}
