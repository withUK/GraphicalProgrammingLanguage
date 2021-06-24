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

        public MainGUI()
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                InitializeComponent();
                dc = pnlOutput.CreateGraphics();
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
    }
}
