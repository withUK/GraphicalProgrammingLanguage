﻿using GraphicalProgrammingLanguage.Commands;
using GraphicalProgrammingLanguage.Factories;
using GraphicalProgrammingLanguage.Shapes;
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
                w.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            dialogueSave.Filter = "Text Files|*.txt;*.text";
            if (dialogueSave.ShowDialog() == DialogResult.OK)
            {
                if (dialogueSave.OpenFile() != null)
                {
                    StreamWriter txt = new StreamWriter(dialogueSave.FileName);
                    txt.Write(txtScript.Text);
                    txt.Close();
                }
                
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    txtLog.Text = Logger.Log($"{dialogueSave.FileName} saved.", w) + "\n" + txtLog.Text;
                }
            }
        }

        private void btnCommandLineRun_Click(object sender, EventArgs e)
        {
            cp.parseCommand(txtCommandLine.Text);
        }
    }
}