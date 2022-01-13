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
        private GameSettingsModel m_GameSettingsModel;
        private Button[,] m_ButtonsGuess;
        private Button[] m_ButtonEndGuessing;
        private Button[,] m_ButtonGuessingResults;

        public BoolPgia(GameSettingsModel i_GameSettingsModel)
        {
            m_GameSettingsModel = i_GameSettingsModel;
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
            m_ButtonsGuess = new Button[m_GameSettingsModel.NumberOfChances, m_GameSettingsModel.DefaultNumberOfGuessing];
            for(int i = 0; i < m_GameSettingsModel.NumberOfChances; i++)
            {
                this.Height += 65;

                for (int j = 0; j < m_GameSettingsModel.DefaultNumberOfGuessing; j++)
                {
                    m_ButtonsGuess[i, j] = new Button()
                    {
                       Size = new Size(50, 50),
                       Location = new Point((j * 56) + 12, (i * 70) + 80)
                    };

                    m_ButtonsGuess[i, j].Click += buttonGuess_Click;
                    this.Controls.Add(m_ButtonsGuess[i, j]);
                }
            }
        }

        private void generateButtonEndGuessing()
        {
            m_ButtonEndGuessing = new Button[m_GameSettingsModel.NumberOfChances];
            for(int i = 0; i < m_GameSettingsModel.NumberOfChances; i++)
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
            m_ButtonGuessingResults = new Button[m_GameSettingsModel.NumberOfChances, m_GameSettingsModel.DefaultNumberOfGuessing];
            for (int i = 0; i < m_GameSettingsModel.NumberOfChances; i++)
            {
                for (int j = 0; j < m_GameSettingsModel.DefaultNumberOfGuessing; j++)
                {
                    if(j <= 1)
                    {
                        m_ButtonGuessingResults[i, j] = new Button()
                        {
                            Size = new Size(20, 20),
                            Location = new Point((j * 30) + 320, (i * 70) + 110),
                            Enabled = false
                        };
                    }
                    else
                    {
                        m_ButtonGuessingResults[i, j] = new Button()
                        {
                            Size = new Size(20, 20),
                            Location = new Point((j * 30) + 260, (i * 70) + 80),
                            Enabled = false
                        };
                    }

                    this.Controls.Add(m_ButtonGuessingResults[i, j]);
                }
            }
        }

        private void buttonGuess_Click(object i_Sender, EventArgs i_Event)
        {
            FlowLayoutPanelColor flowLayoutPanelColor = new FlowLayoutPanelColor(ref m_GameSettingsModel);
            Button button = (Button)i_Sender;
            
            flowLayoutPanelColor.ShowDialog();
            button.BackColor = m_GameSettingsModel.Color;
        }
    }
}
