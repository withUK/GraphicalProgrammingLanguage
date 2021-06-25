using GraphicalProgrammingLanguage.Factories;
using GraphicalProgrammingLanguage.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage
{
    public partial class MainGUI : Form
    {
        // Objects
        private Graphics dc;
        private ShapeFactory shapeFactory = new ShapeFactory();
        private Pen pen = new Pen(Color.Black, 1);
        private Brush brush;

        // Properties
        private int x = 0, y = 0;
        
        // Constructor
        public MainGUI()
        {
            InitializeComponent();
            dc = pnlOutput.CreateGraphics();
            txtLog.AppendText(Logger.Log("Application started"));
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
            string input = txtCommandLine.Text;
            int startIndex = input.IndexOf("(");
            int endIndex = input.LastIndexOf(")");
            Dictionary<string, string> variableDict = new Dictionary<string, string>();

            string variableString = input.Substring(startIndex + 1, endIndex - startIndex - 1);
            string[] variables = variableString.Split(",");

            foreach (var item in variables)
            {
                string[] split = item.Split("=");
                variableDict.Add(split[0], split[1]);
            }

            Shape shape = shapeFactory.getShape(variableDict.GetValueOrDefault("name"));
            shape.set(variableDict);
            shape.draw(dc);
        }
    }
}