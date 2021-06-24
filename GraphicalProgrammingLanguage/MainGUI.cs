using GraphicalProgrammingLanguage.Factories;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage
{
    public partial class MainGUI : Form
    {
        private Graphics dc;
        private ShapeFactory shapeFactory;

        public MainGUI()
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                InitializeComponent();
                dc = pnlOutput.CreateGraphics();
                shapeFactory = new ShapeFactory();
                txtLog.AppendText(Logger.Log("Application started", w));
            }
        }

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
                    txtLog.Text = Logger.Log($"{dialogueLoad.FileName} loaded.", w) + "\n" + txtLog.Text;
                }
            }
        }

        private void btnCommandLineRun_Click(object sender, EventArgs e)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                if (!String.IsNullOrEmpty(txtCommandLine.Text))
                {
                    string command = txtCommandLine.Text.Trim();

                    string[] commandComponents = command.Split("(");

                    string commandName = commandComponents[0].ToLower();
                    string commandVariables = String.Concat("(", commandComponents[1]);

                    object[] variables = commandVariables.Substring(1, commandVariables.Length - 2).Split(",");

                    if (commandName.Equals("draw"))
                    {
                        var shape = shapeFactory.getShape(variables[1].ToString());
                    }
                }
            }
        }
    }
}
