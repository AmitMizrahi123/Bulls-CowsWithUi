using System.Drawing;

namespace Final_project.Model
{
    public class GameSettingsModel
    {
        public int NumberOfChances { get; set; } = 4;

        public bool StartGame { get; set; } = false;

        public int DefaultNumberOfGuessing { get; } = 4;

        public Color Color { get; set; }
    }
}
