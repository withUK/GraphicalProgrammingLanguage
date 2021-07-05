using GraphicalProgrammingLanguage.Commands;
using GraphicalProgrammingLanguage.Data;
using GraphicalProgrammingLanguage.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage
{
    public partial class MainGUI : Form
    {
        // Objects
        internal CommandParser cp;
        internal Graphics dc;
        internal Pen pen = new Pen(Color.Black, 1);
        internal Brush brush = new SolidBrush(Color.Transparent);
        internal Command currentCommand;
        internal Dictionary<string,string> currentVariables;

        // Properties
        internal int x = 0, y = 0;
        
        // Constructor
        public MainGUI()
        {
            InitializeComponent();
            cp = new CommandParser(this);
            dc = pnlOutput.CreateGraphics();
            getData();
            txtLog.AppendText(Logger.LogLaunch());
        }
        // Methods
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                dialogueLoad.Filter = "Text Files|*.txt;*.text";
                if (dialogueLoad.ShowDialog() == DialogResult.OK)
                {
                    lblFileName.Text = String.Concat(" : ", dialogueLoad.SafeFileName);
                    var fileContent = new StreamReader(dialogueLoad.FileName);
                    txtScript.Text = fileContent.ReadToEnd();
                    txtLog.Text = Logger.Log($"{dialogueLoad.FileName} loaded.") + "\n" + txtLog.Text;
                }
            }
        }

        private void btnCommandLineRun_Click(object sender, EventArgs e)
        {
            cp.parseCommand(txtCommandLine.Text);
        }

        private void getData()
        {
            CommandsContext db = new CommandsContext();

            List<CommandUsageCount> count = new List<CommandUsageCount>();

            foreach (var item in db.CommandUsage)
            {
                count.Add(item);
            }

            count = count.OrderByDescending(c => c.UsageCount).ToList();

            foreach (var item in count)
            {
                if (String.IsNullOrEmpty(txtCommandCount.Text))
                {
                    txtCommandCount.Text = String.Concat("  ", item.CommandName);
                }
                else
                {
                    txtCommandCount.Text = String.Concat(txtCommandCount.Text, "\n", "  ", item.CommandName);
                }
            }
        }
    }
}