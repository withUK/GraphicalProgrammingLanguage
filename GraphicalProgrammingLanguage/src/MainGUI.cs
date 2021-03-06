using GraphicalProgrammingLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage
{
    public partial class MainGUI : Form
    {
        // Objects
        internal CommandParser cp;
        internal ScriptParser sp;
        internal Graphics dc;
        internal Pen pen = new Pen(Color.Black, 1);
        internal Brush brush = new SolidBrush(Color.Transparent);
        internal Command currentCommand;
        internal Dictionary<string,string> currentVariables;
        internal StreamReader fileContent;

        // Properties
        internal int x = 0, y = 0;
        
        // Constructor
        public MainGUI()
        {
            InitializeComponent();
            cp = new CommandParser(this);
            sp = new ScriptParser(this);
            dc = pnlOutput.CreateGraphics();
            populateCommandUsage();
            txtLog.AppendText(Logger.LogLaunch());
        }
        // Methods
        private void btnLoad_Click(object sender, EventArgs e)
        {
            dialogueLoad.Filter = "Text Files|*.txt;*.text";
            if (dialogueLoad.ShowDialog() == DialogResult.OK)
            {
                lblFileName.Text = String.Concat(" : ", dialogueLoad.SafeFileName);
                var fileContent = new StreamReader(dialogueLoad.FileName);
                txtScript.Text = fileContent.ReadToEnd();
                txtLog.Text = Logger.Log($"{dialogueLoad.FileName} loaded.") + "\n" + txtLog.Text;
                fileContent.Dispose();
                fileContent.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dialogueSave.Filter = "Text Files|*.txt;*.text";
            if (dialogueSave.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dialogueSave.OpenFile());
                writer.Write(txtScript.Text);
                writer.Dispose();
                writer.Close();
                
                MessageBox.Show(string.Concat("File : ", dialogueSave.FileName, " has been saved successfully."));
            }
        }

        private void btnCommandLineRun_Click(object sender, EventArgs e)
        {
            cp.ExecuteCommand(txtCommandLine.Text);
        }

        private void btnScriptRun_Click(object sender, EventArgs e)
        {
            sp.ExecuteScript(txtScript.Text);
        }

        private void populateCommandUsage()
        {
            List<string> usageOutput = new List<string>();
            usageOutput = UsageCounter.GetUsageCountOutput();

            foreach (var item in usageOutput)
            {
                if (String.IsNullOrEmpty(txtCommandCount.Text))
                {
                    txtCommandCount.Text = item;
                }
                else
                {
                    txtCommandCount.Text = String.Concat(txtCommandCount.Text, "\n", item);
                }
            }
        }
    }
}