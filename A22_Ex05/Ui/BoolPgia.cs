using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using A22_Ex05.Logic;
using A22_Ex05.Model;

namespace A22_Ex05.Ui
{
    public partial class BoolPgia : Form
    {
        private static int s_NumberOfChance;
        private const int k_AddingHeight = 65;
        private const string k_ButtonCancelName = "0";
        private readonly GameLogic r_GameLogic;
        private readonly GameSettingsModel r_GameSettingsModel;
        private List<List<Color>> m_ButtonColorsPressed;
        private ButtonGuess[,] m_ButtonsGuess;
        private ButtonEndGuessing[] m_ButtonEndGuessing;
        private Button[,] m_ButtonGuessingResults;

        public BoolPgia(GameSettingsModel i_GameSettingsModel, GameLogic i_GameLogic)
        {
            r_GameLogic = i_GameLogic;
            r_GameSettingsModel = i_GameSettingsModel;
            initializeButtonColorsPressedMatrix(r_GameSettingsModel.NumberOfChances);
            InitializeComponent();
            initializeBoard();
        }

        private void initializeButtonColorsPressedMatrix(int i_NumberOfChances)
        {
            m_ButtonColorsPressed = new List<List<Color>>();
            for (int i = 0; i < i_NumberOfChances; i++)
            {
                m_ButtonColorsPressed.Add(new List<Color>());
            }
        }

        private void initializeBoard()
        {
            generateButtonGuess();
            generateButtonEndGuessing();
            generateButtonGuessingResult();
        }

        private void generateButtonGuess()
        {
            int numberOfChances = r_GameSettingsModel.NumberOfChances;
            int defaultNumberOfGuessing = r_GameSettingsModel.DefaultNumberOfGuessing;

            m_ButtonsGuess = new ButtonGuess[numberOfChances, defaultNumberOfGuessing];
            for(int i = 0; i < numberOfChances; i++)
            {
                this.Height += k_AddingHeight;

                for (int j = 0; j < defaultNumberOfGuessing; j++)
                {
                    m_ButtonsGuess[i, j] = new ButtonGuess(i, j)
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
            int numberOfChances = r_GameSettingsModel.NumberOfChances;

            m_ButtonEndGuessing = new ButtonEndGuessing[numberOfChances];
            for(int i = 0; i < numberOfChances; i++)
            {
                m_ButtonEndGuessing[i] = new ButtonEndGuessing(i)
                {
                    Size = new Size(50, 30),
                    Location = new Point(250, (i * 70) + 100),
                    Text = @"-->>",
                    Enabled = false
                };

                m_ButtonEndGuessing[i].Click += buttonEndGuessing_Click;
                this.Controls.Add(m_ButtonEndGuessing[i]);
            }
        }

        private void generateButtonGuessingResult()
        {
            int numberOfChances = r_GameSettingsModel.NumberOfChances;
            int defaultNumberOfGuessing = r_GameSettingsModel.DefaultNumberOfGuessing;

            m_ButtonGuessingResults = new Button[numberOfChances, defaultNumberOfGuessing];
            for (int i = 0; i < numberOfChances; i++)
            {
                for (int j = 0; j < defaultNumberOfGuessing; j++)
                {
                    if(j <= 1)
                    {
                        m_ButtonGuessingResults[i, j] = new Button()
                        {
                            Size = new Size(20, 20),
                            Location = new Point((j * 30) + 320, (i * 70) + 80),
                            Enabled = false
                        };
                    }
                    else
                    {
                        m_ButtonGuessingResults[i, j] = new Button()
                        {
                            Size = new Size(20, 20),
                            Location = new Point((j * 30) + 260, (i * 70) + 110),
                            Enabled = false
                        };
                    }

                    this.Controls.Add(m_ButtonGuessingResults[i, j]);
                }
            }
        }

        private void buttonGuess_Click(object i_Sender, EventArgs i_Event)
        {
            ButtonGuess button = (ButtonGuess)i_Sender;
            int buttonIndex = button.ButtonIndex;
            int buttonNumber = button.ButtonNumber;

            if(availableRowOptionToGuess(buttonIndex))
            {
                FlowLayoutPanelColor flowLayoutPanelColor = new FlowLayoutPanelColor();

                flowLayoutPanelColor.ShowDialog();
                if(!userClickOnCancelButton(flowLayoutPanelColor.Color.Name))
                {
                    if (!userEnterColorThatAlreadyPick(buttonIndex, flowLayoutPanelColor.Color))
                    {
                        if (userEnterFourGuesses(buttonIndex) || userChangeColorThatHeAlreadyPick(buttonIndex, buttonNumber))
                        {
                            m_ButtonColorsPressed[buttonIndex].Remove(button.BackColor);
                        }

                        button.BackColor = flowLayoutPanelColor.Color;
                        m_ButtonColorsPressed[buttonIndex].Add(flowLayoutPanelColor.Color);
                        if (userEnterFourGuesses(buttonIndex) && !isButtonEndGuessingEnable(buttonIndex))
                        {
                            m_ButtonEndGuessing[buttonIndex].Enabled = true;
                        }
                    }
                }
            }
        }

        private bool availableRowOptionToGuess(int i_ButtonIndex)
        {
            return i_ButtonIndex.Equals(s_NumberOfChance);
        }

        private bool userClickOnCancelButton(string i_ButtonBackColorName)
        {
            return i_ButtonBackColorName.Equals(k_ButtonCancelName);
        }

        private bool userChangeColorThatHeAlreadyPick(int i_ButtonIndex, int i_ButtonNumber)
        {
            try
            {
                return !m_ButtonColorsPressed[i_ButtonIndex][i_ButtonNumber].Equals(null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool userEnterFourGuesses(int i_Index)
        {
            return m_ButtonColorsPressed[i_Index].Count.Equals(4);
        }

        private bool userEnterColorThatAlreadyPick(int i_Index, Color i_Color)
        {
            return m_ButtonColorsPressed[i_Index].Contains(i_Color);
        }

        private bool isButtonEndGuessingEnable(int i_Index)
        {
            return m_ButtonEndGuessing[i_Index].Enabled;
        }

        private void buttonEndGuessing_Click(object i_Sender, EventArgs i_Event)
        {
            ButtonEndGuessing button = (ButtonEndGuessing)i_Sender;
            int buttonIndex = button.ButtonIndex;

            s_NumberOfChance++;
            button.Enabled = false;
            button.CountButtonPressed++;
            insertToGuessingLetters(m_ButtonColorsPressed[buttonIndex], buttonIndex);
            comparisonRandomGuessesToUserGuesses(buttonIndex);
            updateButtonGuessingResult(buttonIndex);
            disableUserGuessing(buttonIndex);
            gameOver(button.CountButtonPressed, buttonIndex);
        }

        private void insertToGuessingLetters(List<Color> i_ColorsToInsert, int i_ButtonIndex)
        {
            r_GameLogic.InsertToGuessingLetters(i_ColorsToInsert, i_ButtonIndex);
        }

        private void comparisonRandomGuessesToUserGuesses(int i_ButtonIndex)
        {
            r_GameLogic.ComparisonRandomGuessesToUserGuesses(i_ButtonIndex);
        }

        private bool winner(int i_ButtonIndex)
        {
            return r_GameLogic.IsWinner(i_ButtonIndex);
        }

        private bool endGuessing(int i_ButtonPressedCount)
        {
            return r_GameLogic.GameOver(i_ButtonPressedCount);
        }

        private void gameOver(int i_ButtonPressedCount, int i_ButtonIndex)
        {
            if(endGuessing(i_ButtonPressedCount) || winner(i_ButtonIndex))
            {
                List<Color> colors = r_GameLogic.GetRandomResultInColor();

                for (int i = 0; i < r_GameSettingsModel.DefaultNumberOfGuessing; i++)
                {
                    this.Controls[i].BackColor = colors[i];
                }

                for(int i = i_ButtonIndex; i < r_GameSettingsModel.NumberOfChances; i++)
                {
                    for(int j = 0; j < r_GameSettingsModel.DefaultNumberOfGuessing; j++)
                    {
                        m_ButtonsGuess[i, j].Enabled = false;
                    }
                }
            }
        }

        private void disableUserGuessing(int i_ButtonIndex)
        {
            for(int i = 0; i < r_GameSettingsModel.DefaultNumberOfGuessing; i++)
            {
                m_ButtonsGuess[i_ButtonIndex, i].Enabled = false;
            }
        }

        private void updateButtonGuessingResult(int i_ButtonIndex)
        {
            int index = 0;
            List<Color> colors = r_GameLogic.GetGuessResultsInColors(i_ButtonIndex);
            
            foreach(Color color in colors)
            {
                if(!color.Name.Equals(k_ButtonCancelName))
                {
                    m_ButtonGuessingResults[i_ButtonIndex, index++].BackColor = color;
                }
                else
                {
                    m_ButtonGuessingResults[i_ButtonIndex, index++].BackColor = Color.Empty;
                }
            }
        }
    }
}
