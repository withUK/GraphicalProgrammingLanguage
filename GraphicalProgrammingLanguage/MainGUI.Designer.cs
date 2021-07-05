
namespace GraphicalProgrammingLanguage
{
    partial class MainGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.txtScript = new System.Windows.Forms.RichTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.lblCommandLine = new System.Windows.Forms.Label();
            this.lblScript = new System.Windows.Forms.Label();
            this.pnlOutput = new System.Windows.Forms.Panel();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnCommandLineRun = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnScriptRun = new System.Windows.Forms.Button();
            this.gbxCommands = new System.Windows.Forms.GroupBox();
            this.txtCommands = new System.Windows.Forms.RichTextBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.dialogueLoad = new System.Windows.Forms.OpenFileDialog();
            this.lblFileName = new System.Windows.Forms.Label();
            this.gbxLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.txtCommandCount = new System.Windows.Forms.RichTextBox();
            this.gbxCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.gbxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtScript
            // 
            this.txtScript.Location = new System.Drawing.Point(34, 39);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(550, 400);
            this.txtScript.TabIndex = 0;
            this.txtScript.Text = "";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Bahnschrift Light", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(383, 718);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(792, 60);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Graphical Programming Language";
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.Location = new System.Drawing.Point(34, 515);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.Size = new System.Drawing.Size(450, 27);
            this.txtCommandLine.TabIndex = 2;
            // 
            // lblCommandLine
            // 
            this.lblCommandLine.AutoSize = true;
            this.lblCommandLine.Location = new System.Drawing.Point(34, 492);
            this.lblCommandLine.Name = "lblCommandLine";
            this.lblCommandLine.Size = new System.Drawing.Size(106, 20);
            this.lblCommandLine.TabIndex = 3;
            this.lblCommandLine.Text = "Command line";
            // 
            // lblScript
            // 
            this.lblScript.AutoSize = true;
            this.lblScript.Location = new System.Drawing.Point(34, 16);
            this.lblScript.Name = "lblScript";
            this.lblScript.Size = new System.Drawing.Size(47, 20);
            this.lblScript.TabIndex = 4;
            this.lblScript.Text = "Script";
            // 
            // pnlOutput
            // 
            this.pnlOutput.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOutput.Location = new System.Drawing.Point(625, 39);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(550, 400);
            this.pnlOutput.TabIndex = 5;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(625, 16);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(55, 20);
            this.lblOutput.TabIndex = 6;
            this.lblOutput.Text = "Output";
            // 
            // btnCommandLineRun
            // 
            this.btnCommandLineRun.Location = new System.Drawing.Point(490, 514);
            this.btnCommandLineRun.Name = "btnCommandLineRun";
            this.btnCommandLineRun.Size = new System.Drawing.Size(94, 29);
            this.btnCommandLineRun.TabIndex = 8;
            this.btnCommandLineRun.Text = "Run";
            this.btnCommandLineRun.UseVisualStyleBackColor = true;
            this.btnCommandLineRun.Click += new System.EventHandler(this.btnCommandLineRun_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(34, 445);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(134, 445);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnScriptRun
            // 
            this.btnScriptRun.Location = new System.Drawing.Point(490, 445);
            this.btnScriptRun.Name = "btnScriptRun";
            this.btnScriptRun.Size = new System.Drawing.Size(94, 29);
            this.btnScriptRun.TabIndex = 13;
            this.btnScriptRun.Text = "Run";
            this.btnScriptRun.UseVisualStyleBackColor = true;
            // 
            // gbxCommands
            // 
            this.gbxCommands.Controls.Add(this.txtCommandCount);
            this.gbxCommands.Controls.Add(this.txtCommands);
            this.gbxCommands.Location = new System.Drawing.Point(625, 449);
            this.gbxCommands.Name = "gbxCommands";
            this.gbxCommands.Size = new System.Drawing.Size(550, 250);
            this.gbxCommands.TabIndex = 14;
            this.gbxCommands.TabStop = false;
            this.gbxCommands.Text = "Popular commands";
            // 
            // txtCommands
            // 
            this.txtCommands.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommands.Location = new System.Drawing.Point(3, 23);
            this.txtCommands.Name = "txtCommands";
            this.txtCommands.Size = new System.Drawing.Size(544, 224);
            this.txtCommands.TabIndex = 0;
            this.txtCommands.Text = "";
            // 
            // logo
            // 
            this.logo.Image = global::GraphicalProgrammingLanguage.Properties.Resources.gpl_logo_vsml1;
            this.logo.Location = new System.Drawing.Point(300, 707);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(88, 85);
            this.logo.TabIndex = 15;
            this.logo.TabStop = false;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(87, 16);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFileName.Size = new System.Drawing.Size(0, 20);
            this.lblFileName.TabIndex = 16;
            this.lblFileName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gbxLog
            // 
            this.gbxLog.Controls.Add(this.txtLog);
            this.gbxLog.Location = new System.Drawing.Point(34, 549);
            this.gbxLog.Name = "gbxLog";
            this.gbxLog.Size = new System.Drawing.Size(550, 147);
            this.gbxLog.TabIndex = 17;
            this.gbxLog.TabStop = false;
            this.gbxLog.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Menu;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 23);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(544, 121);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // txtCommandCount
            // 
            this.txtCommandCount.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCommandCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCommandCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommandCount.Location = new System.Drawing.Point(3, 23);
            this.txtCommandCount.Name = "txtCommandCount";
            this.txtCommandCount.Size = new System.Drawing.Size(544, 224);
            this.txtCommandCount.TabIndex = 1;
            this.txtCommandCount.Text = "";
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1212, 804);
            this.Controls.Add(this.gbxLog);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.gbxCommands);
            this.Controls.Add(this.btnScriptRun);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCommandLineRun);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.pnlOutput);
            this.Controls.Add(this.lblScript);
            this.Controls.Add(this.lblCommandLine);
            this.Controls.Add(this.txtCommandLine);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtScript);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainGUI";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Graphical Programming Language";
            this.gbxCommands.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.gbxLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtScript;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCommandLine;
        private System.Windows.Forms.Label lblScript;
        private System.Windows.Forms.Panel pnlOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnCommandLineRun;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnScriptRun;
        private System.Windows.Forms.GroupBox gbxCommands;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.OpenFileDialog dialogueLoad;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.GroupBox gbxLog;
        private System.Windows.Forms.RichTextBox txtCommands;
        internal System.Windows.Forms.TextBox txtCommandLine;
        internal System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.RichTextBox txtCommandCount;
    }
}

