using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadAndWriteFiles.Exercice
{
    public partial class FrmMain : Form
    {
        private string[] files = new string[] { "fruits.txt", "sports.txt", "games.txt" };
        public FrmMain()
        {
            InitializeComponent();
            cboFiles.Items.AddRange(files);
            cboFiles.SelectedIndex = 0;
        }
        private void cboFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Display the selected file's content in the listbox
            int fileIndex = cboFiles.SelectedIndex;
            lstReader.Items.Clear();
            ReadFile(files[fileIndex]);
        }

        private void ReadFile(string file)
        {
            // TODO: Read the file passed as parameter and display its content in the listbox
            if (!File.Exists(file))
                File.CreateText(file).Close();
            else
                using (var sr = File.OpenText(file))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        lstReader.Items.Add(line);
                }
        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            // TODO: Call the AppendToFile method, richTextBox should not be empty
            int fileIndex = cboFiles.SelectedIndex;
            AppendToFile(rtxWriter.Text, files[fileIndex]);
        }
        private void AppendToFile(string content, string file)
        {
            // TODO: Append the content to the file and refresh the listbox
            if (!File.Exists(file))
                File.CreateText(file).Close();
            else
            {
                using (var sw = File.AppendText(file))
                    sw.Write(content + Environment.NewLine);
                lstReader.Items.Clear();
                ReadFile(file);
            }
            //File.AppendAllText(file, content);
            //ReadFile(file);
        }

        private void btnOverride_Click(object sender, EventArgs e)
        {
            // TODO: Call the OverrideFile method, richTextBox should not be empty
            int fileIndex = cboFiles.SelectedIndex;
            OverrideFile(rtxWriter.Text, files[fileIndex]);
        }
        private void OverrideFile(string content, string file)
        {
            // TODO: Override the file's content and refresh the listbox
            int fileIndex = cboFiles.SelectedIndex;
            File.WriteAllText(files[fileIndex], rtxWriter.Text + Environment.NewLine);
            lstReader.Items.Clear();
            ReadFile(file);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // TODO: Reset the file's content to an empty string
            var fileIndex = cboFiles.SelectedIndex;
            File.WriteAllText(files[fileIndex], string.Empty);
            lstReader.Items.Clear();
        }
    }
}
