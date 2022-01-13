using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Final_project.Logic;
using Final_project.Model;

namespace Final_project.Ui
{
    public partial class BoolPgia : Form
    {
        private readonly GameSettingsModel r_GameSettingsModel;
        private Button[,] m_BoardButtons;
        private Button[] m_ButtonEndGuessing;
        private Button[,] m_ButtonGuessingResults;

        public BoolPgia(ref GameSettingsModel io_GameSettingsModel, GameLogic i_GameLogic)
        {
            r_GameSettingsModel = io_GameSettingsModel;
            InitializeComponent();
            initializeBoard();
        }

        private void initializeBoard()
        {
            generateButtonGuess();
            generateButtonEndGuessing();
            generateButtonGuessingResult();
        }

        private void generateButtonGuess()
        {
            m_BoardButtons = new Button[r_GameSettingsModel.NumberOfChances, r_GameSettingsModel.DefaultNumberOfGuessing];
            for(int i = 0; i < r_GameSettingsModel.NumberOfChances; i++)
            {
                this.Height += 65;

                for (int j = 0; j < r_GameSettingsModel.DefaultNumberOfGuessing; j++)
                {
                    m_BoardButtons[i, j] = new Button()
                    {
                       Size = new Size(50, 50),
                       Location = new Point((j * 56) + 12, (i * 70) + 80),
                       ForeColor = Color.Black,
                    };

                    m_BoardButtons[i, j].Click += buttonBoard_Click;
                    this.Controls.Add(m_BoardButtons[i, j]);
                }
            }
        }

        private void generateButtonEndGuessing()
        {
            m_ButtonEndGuessing = new Button[r_GameSettingsModel.NumberOfChances];
            for(int i = 0; i < r_GameSettingsModel.NumberOfChances; i++)
            {
                m_ButtonEndGuessing[i] = new Button()
                {
                    Size = new Size(50, 30),
                    Location = new Point(250, (i * 70) + 100),
                    Text = @"-->>",
                    Enabled = false
                };

                this.Controls.Add(m_ButtonEndGuessing[i]);
            }
        }

        private void generateButtonGuessingResult()
        {
            m_ButtonGuessingResults = new Button[r_GameSettingsModel.NumberOfChances, r_GameSettingsModel.DefaultNumberOfGuessing];
            for (int i = 0; i < r_GameSettingsModel.NumberOfChances; i++)
            {
                for (int j = 0; j < r_GameSettingsModel.DefaultNumberOfGuessing; j++)
                {
                    if(j <= 1)
                    {
                        m_ButtonGuessingResults[i, j] = new Button()
                        {
                            Size = new Size(20, 20),
                            Location = new Point((j * 30) + 320, (i * 70) + 110),
                            ForeColor = Color.Black,
                            Enabled = false
                        };
                    }
                    else
                    {
                        m_ButtonGuessingResults[i, j] = new Button()
                        {
                            Size = new Size(20, 20),
                            Location = new Point((j * 30) + 260, (i * 70) + 80),
                            ForeColor = Color.Black,
                            Enabled = false
                        };
                    }

                    this.Controls.Add(m_ButtonGuessingResults[i, j]);
                }
            }
        }

        private void buttonBoard_Click(object i_Sender, EventArgs i_Event)
        {
            FlowLayoutPanelColor flowLayoutPanelColor = new FlowLayoutPanelColor(r_GameSettingsModel);
            Button button = (Button)i_Sender;
            
            flowLayoutPanelColor.ShowDialog();
        }
    }
}
