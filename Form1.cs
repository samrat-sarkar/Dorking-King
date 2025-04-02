using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Dorking_King
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [STAThread]
        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
                result.AppendLine("site:" + richTextBox1.Text + " ");

            if (!string.IsNullOrWhiteSpace(richTextBox2.Text))
                result.AppendLine("intext:" + richTextBox2.Text + " ");

            if (!string.IsNullOrWhiteSpace(richTextBox3.Text))
                result.AppendLine("inurl:" + richTextBox3.Text + " ");

            if (!string.IsNullOrWhiteSpace(richTextBox4.Text))
                result.AppendLine("intitle:" + richTextBox4.Text + " ");

            if (!string.IsNullOrWhiteSpace(richTextBox5.Text))
                result.AppendLine(richTextBox5.Text + " ");

            StringBuilder checkedBoxes = new StringBuilder();
            for (int i = 1; i <= 37; i++)
            {
                Control control = this.Controls["checkBox" + i];
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    string[] parts = checkBox.Text.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 0)
                    {
                        checkedBoxes.AppendLine(parts[0].Trim() + " "); 
                    }
                }
            }

            if (checkedBoxes.Length > 0)
            {
                result.Append(checkedBoxes);
            }

            if (result.ToString().Length > 0)
            {
                string url = $"https://www.google.com/search?q={result.ToString()}";

                DialogResult dialogResult = MessageBox.Show($"{result.ToString()}", "Confirm Search Query",
                                                             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
            }
            else
            {
                MessageBox.Show("Invalid Input !", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();

            for (int i = 1; i <= 37; i++)
            {
                Control control = this.Controls["checkBox" + i];
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
        }

    }
}
