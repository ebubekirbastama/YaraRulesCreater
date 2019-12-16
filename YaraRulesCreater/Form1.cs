using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

// Coder By& EbubekirBastama
// www.ebubekirbastama.com

namespace YaraRulesCreater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string altsatir = "\n";string tirnak = "\""; ProcessStartInfo pinfo = new ProcessStartInfo(); Process proc = new Process();
        string []veriler = {"rule","{","}","meta:","strings:", "condition:", "author = ", "description = " };OpenFileDialog op;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(
              veriler[0] + " " + textBoxX3.Text + " " + veriler[1] +
              altsatir + "      " + veriler[3] +
              altsatir + "           " + veriler[6] + "" + tirnak + textBoxX1.Text + tirnak +
              altsatir + "           " + veriler[7] + " " + tirnak + textBoxX2.Text + tirnak +
              altsatir + "      "+veriler[4] + 
              altsatir + "           "+richTextBox2.Text +
              altsatir + "      "+ veriler[5] +
              altsatir + "           "+ richTextBox3.Text + altsatir + veriler[2]
           );
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            op = new OpenFileDialog();
            if (DialogResult.OK==op.ShowDialog())
            {
                if (textBoxX4.Text!="")
                {
                    dosyaolustur(Application.StartupPath + @"/" + textBoxX3.Text + ".yar");
                    processtart(Application.StartupPath + @"/" + textBoxX3.Text + ".yar", op.FileName.ToString()+" "+textBoxX4.Text);
                }
                else
                {
                    dosyaolustur(Application.StartupPath + @"/" + textBoxX3.Text + ".yar");
                    processtart(Application.StartupPath + @"/" + textBoxX3.Text + ".yar", op.FileName.ToString());
                }
            }
        }
        void dosyaolustur(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Close();
            File.AppendAllText(filename, Environment.NewLine + richTextBox3.Text);

        }
        void processtart(string yardosyasi,string analizdosyasi)
        {
            pinfo.FileName = Application.StartupPath + @"\yara\yara64.exe";
            pinfo.Arguments = yardosyasi +" "+ analizdosyasi;
            proc.StartInfo = pinfo;
            proc.Start();
        }
    }
}
