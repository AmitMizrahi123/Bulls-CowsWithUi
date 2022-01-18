
using System.Windows.Forms;

namespace Final_project.Ui
{
    partial class FormGameSettings
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
            this.m_ButtonNumberOfChances = new System.Windows.Forms.Button();
            this.m_ButtonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ButtonNumberOfChances
            // 
            this.m_ButtonNumberOfChances.Location = new System.Drawing.Point(12, 23);
            this.m_ButtonNumberOfChances.Name = "m_ButtonNumberOfChances";
            this.m_ButtonNumberOfChances.Size = new System.Drawing.Size(308, 32);
            this.m_ButtonNumberOfChances.TabIndex = 0;
            this.m_ButtonNumberOfChances.UseVisualStyleBackColor = true;
            this.m_ButtonNumberOfChances.Click += new System.EventHandler(this.buttonNumberOfChances_Click);
            // 
            // m_ButtonStart
            // 
            this.m_ButtonStart.Location = new System.Drawing.Point(205, 89);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(114, 29);
            this.m_ButtonStart.TabIndex = 1;
            this.m_ButtonStart.Text = "Start";
            this.m_ButtonStart.UseVisualStyleBackColor = true;
            this.m_ButtonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 142);
            this.Controls.Add(this.m_ButtonStart);
            this.Controls.Add(this.m_ButtonNumberOfChances);
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bool Pgia";
            this.Load += new System.EventHandler(this.formGameSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonNumberOfChances;
        private System.Windows.Forms.Button m_ButtonStart;
    }
}