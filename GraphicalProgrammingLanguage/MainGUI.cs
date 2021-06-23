using System;
using System.IO;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                InitializeComponent();
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
    }
}
