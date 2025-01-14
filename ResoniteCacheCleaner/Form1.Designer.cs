using Microsoft.VisualBasic;
using System;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ResoniteCacheCleaner
{
    partial class Form1
    {
        // Required designer variable.
        private System.ComponentModel.IContainer components = null;

        // This method is required for designer support.
        // It can be modified using the code editor.  
        // Do not modify it in the designer.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void SetDarkMode()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.LightGray;  // Setting text color

            // Change all Buttons to dark gray with white text
            this.Controls.OfType<System.Windows.Forms.Button>().ToList().ForEach(button =>
            {
                button.BackColor = Color.DarkGray;  // Dark gray button background
                button.ForeColor = Color.White;     // White button text
            });

            // Change all TextBoxes (including txtLog) to black background with white text
            this.Controls.OfType<System.Windows.Forms.TextBox>().ToList().ForEach(textBox =>
            {
                textBox.BackColor = Color.Black;   // Black background for textboxes
                textBox.ForeColor = Color.White;   // White text for textboxes
            });

            // Optionally, target specific controls like txtLog directly if you know their names
            txtLog.BackColor = Color.Black;    // Set txtLog background to black
            txtLog.ForeColor = Color.White;    // Set txtLog text to white
        }

        // Required method for Designer support.
        // Do not modify the contents of this method with the code editor.
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnStart = new System.Windows.Forms.Button();
            txtLog = new System.Windows.Forms.TextBox();
            btnCopyLog = new System.Windows.Forms.Button();
            notifyIcon = new NotifyIcon(components);
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            SetDarkMode();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Black;
            btnStart.ForeColor = Color.Green;
            btnStart.Location = new Point(9, 233);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(400, 40);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start The Cleaning Process!";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(9, 279);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(400, 168);
            txtLog.TabIndex = 1;
            txtLog.TextChanged += txtLog_TextChanged;
            // 
            // btnCopyLog
            // 
            btnCopyLog.BackColor = Color.Black;
            btnCopyLog.ForeColor = Color.White;
            btnCopyLog.Location = new Point(9, 453);
            btnCopyLog.Name = "btnCopyLog";
            btnCopyLog.Size = new Size(400, 40);
            btnCopyLog.TabIndex = 2;
            btnCopyLog.Text = "Copy Log (Usually for debuggin')";
            btnCopyLog.UseVisualStyleBackColor = false;
            btnCopyLog.Click += btnCopyLog_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Start the Cleaning Process!";
            notifyIcon.Visible = true;
            // 
            // label1
            // 
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(394, 107);
            label1.TabIndex = 0;
            label1.Text = "Thanks for using my Tool!\n\nI made this in mind of the CRAZY Cache issue for the users of Resonite to easly clean their Cache!\n\nIf there are any errors, please feel free to ping nalathethird/or add me!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(12, 116);
            label2.Name = "label2";
            label2.Size = new Size(391, 68);
            label2.TabIndex = 1;
            label2.Text = "Remember that this program WONT WORK WHEN RESONITE IS RUNNING!!!\n\nYou need to fully Exit Resonite before using!";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click_2;
            // 
            // label3
            // 
            label3.ForeColor = Color.Red;
            label3.Location = new Point(12, 200);
            label3.Name = "label3";
            label3.Size = new Size(391, 30);
            label3.TabIndex = 2;
            label3.Text = "FORCE USING WHILE RUNNING WILL BREAK YOUR GAME.\nYou've been warned!";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            ClientSize = new Size(423, 501);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btnCopyLog);
            Controls.Add(txtLog);
            Controls.Add(btnStart);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Resonite Cache Cleaner Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnCopyLog;
        private NotifyIcon notifyIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
