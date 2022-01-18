
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Final_project.Ui
{
    partial class BoolPgia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_ButtonGuess1 = new System.Windows.Forms.Button();
            this.m_ButtonGuess2 = new System.Windows.Forms.Button();
            this.m_ButtonGuess3 = new System.Windows.Forms.Button();
            this.m_ButtonGuess4 = new System.Windows.Forms.Button();
            m_ButtonsGuessing = new List<Button>();
            this.SuspendLayout();
            // 
            // m_ButtonGuess1
            // 
            this.m_ButtonGuess1.BackColor = System.Drawing.Color.Black;
            this.m_ButtonGuess1.Location = new System.Drawing.Point(16, 15);
            this.m_ButtonGuess1.Margin = new System.Windows.Forms.Padding(4);
            this.m_ButtonGuess1.Name = "m_ButtonGuess1";
            this.m_ButtonGuess1.Size = new System.Drawing.Size(67, 62);
            this.m_ButtonGuess1.TabIndex = 0;
            this.m_ButtonGuess1.UseVisualStyleBackColor = false;
            // 
            // m_ButtonGuess2
            // 
            this.m_ButtonGuess2.BackColor = System.Drawing.Color.Black;
            this.m_ButtonGuess2.Location = new System.Drawing.Point(91, 15);
            this.m_ButtonGuess2.Margin = new System.Windows.Forms.Padding(4);
            this.m_ButtonGuess2.Name = "m_ButtonGuess2";
            this.m_ButtonGuess2.Size = new System.Drawing.Size(67, 62);
            this.m_ButtonGuess2.TabIndex = 1;
            this.m_ButtonGuess2.UseVisualStyleBackColor = false;
            // 
            // m_ButtonGuess3
            // 
            this.m_ButtonGuess3.BackColor = System.Drawing.Color.Black;
            this.m_ButtonGuess3.Location = new System.Drawing.Point(165, 15);
            this.m_ButtonGuess3.Margin = new System.Windows.Forms.Padding(4);
            this.m_ButtonGuess3.Name = "m_ButtonGuess3";
            this.m_ButtonGuess3.Size = new System.Drawing.Size(67, 62);
            this.m_ButtonGuess3.TabIndex = 3;
            this.m_ButtonGuess3.UseVisualStyleBackColor = false;
            // 
            // m_ButtonGuess4
            // 
            this.m_ButtonGuess4.BackColor = System.Drawing.Color.Black;
            this.m_ButtonGuess4.Location = new System.Drawing.Point(240, 15);
            this.m_ButtonGuess4.Margin = new System.Windows.Forms.Padding(4);
            this.m_ButtonGuess4.Name = "m_ButtonGuess4";
            this.m_ButtonGuess4.Size = new System.Drawing.Size(67, 62);
            this.m_ButtonGuess4.TabIndex = 2;
            this.m_ButtonGuess4.UseVisualStyleBackColor = false;
            // 
            // BoolPgia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 185);
            this.Controls.Add(this.m_ButtonGuess3);
            this.Controls.Add(this.m_ButtonGuess4);
            this.Controls.Add(this.m_ButtonGuess2);
            this.Controls.Add(this.m_ButtonGuess1);
            this.m_ButtonsGuessing.Add(this.m_ButtonGuess1);
            this.m_ButtonsGuessing.Add(this.m_ButtonGuess2);
            this.m_ButtonsGuessing.Add(this.m_ButtonGuess3);
            this.m_ButtonsGuessing.Add(this.m_ButtonGuess4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BoolPgia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bool Pgia";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonGuess1;
        private System.Windows.Forms.Button m_ButtonGuess2;
        private System.Windows.Forms.Button m_ButtonGuess3;
        private System.Windows.Forms.Button m_ButtonGuess4;
        private List<Button> m_ButtonsGuessing;
    }
}