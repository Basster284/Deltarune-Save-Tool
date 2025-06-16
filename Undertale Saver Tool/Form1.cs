using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Globalization;
using System.Threading;

namespace Undertale_Saver_Tool
{
    public partial class Form1 : Form
    {

        bool import = false;
        string UtsFile;
        string[] file0;
        string[] file9;
        string[] undertaleINI;

        public Form1()
        {
            InitializeComponent();

            panel1.Visible = false;
            textBox2.Text = Undertale_Saver_Tool.Properties.Settings.Default.save_path;

            textBox3.Text = Undertale_Saver_Tool.Properties.Settings.Default.Undertale_path;

            if (File.Exists(textBox2.Text + @"\data.txt") != false)
            {
                listBox1.Items.Clear();
                var lines = File.ReadAllLines(textBox2.Text + @"\data.txt");
                listBox1.Items.AddRange(lines);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("https://t.me/RazrabotchikProgramm");
            MessageBox.Show("Link copied!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Undertale_Saver_Tool.Properties.Settings.Default.save_path = textBox2.Text;
            Undertale_Saver_Tool.Properties.Settings.Default.Save();

            Application.Restart();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            textBox2.Text = folderBrowserDialog1.SelectedPath;
            Undertale_Saver_Tool.Properties.Settings.Default.Undertale_path = textBox2.Text;
            Undertale_Saver_Tool.Properties.Settings.Default.Save();

            if (!File.Exists(textBox2.Text + @"\data.txt"))
            {
                File.WriteAllText(textBox2.Text + @"\data.txt", "");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Undertale|*.exe";
            openFileDialog2.ShowDialog();

            textBox3.Text = openFileDialog2.FileName;
            Undertale_Saver_Tool.Properties.Settings.Default.Undertale_path = textBox3.Text;
            Undertale_Saver_Tool.Properties.Settings.Default.Save();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start(textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (import == true)
            {
                Directory.CreateDirectory(textBox2.Text + @"\" + textBox1.Text + @"\");


                string[] AllLines = UtsFile.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                file0 = AllLines.Take(549).ToArray();
                undertaleINI = AllLines.Skip(549).Take(19).ToArray();
                file9 = AllLines.Skip(568).Take(549).ToArray();

                string directory = textBox2.Text + @"\" + textBox1.Text + @"\";
                File.WriteAllLines(directory + @"\file0", file0);
                File.WriteAllLines(directory + @"\undertale.ini", undertaleINI);
                File.WriteAllLines(directory + @"\file9", file9);

                listBox1.Items.Add(textBox1.Text);
                panel1.Visible = false;

                var items = listBox1.Items.Cast<string>().ToArray();
                File.WriteAllLines(textBox2.Text + @"\data.txt", items);
                label2.Text = "Imported!";
            }
            else
            {
                listBox1.Items.Add(textBox1.Text);
                panel1.Visible = false;

                Directory.CreateDirectory(textBox2.Text + @"\" + textBox1.Text + @"\");

                File.Copy(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\file0", textBox2.Text + @"\" + textBox1.Text + @"\" + "file0");
                File.Copy(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\file9", textBox2.Text + @"\" + textBox1.Text + @"\" + "file9");
                File.Copy(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\undertale.ini", textBox2.Text + @"\" + textBox1.Text + @"\" + "undertale.ini");

                textBox1.Text = "";
                label2.Text = "Created!";

                var items = listBox1.Items.Cast<string>().ToArray();
                File.WriteAllLines(textBox2.Text + @"\data.txt", items);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label2.Text = "New save creating...";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            File.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\file0");
            File.Copy(textBox2.Text + @"\" + listBox1.SelectedItem + @"\file0", System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\file0");

            File.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\file9");
            File.Copy(textBox2.Text + @"\" + listBox1.SelectedItem + @"\file9", System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\file9");

            File.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\undertale.ini");
            File.Copy(textBox2.Text + @"\" + listBox1.SelectedItem + @"\undertale.ini", System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\undertale.ini");

            label2.Text = "Loaded!";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            File.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\file0");
            File.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\file9");
            File.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UNDERTALE\undertale.ini");

            label2.Text = "Reseted!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.Delete(textBox2.Text + @"\" + listBox1.SelectedItem + @"\file0");
            File.Delete(textBox2.Text + @"\" + listBox1.SelectedItem + @"\undertale.ini");
            File.Delete(textBox2.Text + @"\" + listBox1.SelectedItem + @"\file9");
            Directory.Delete(textBox2.Text + @"\" + listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);

            var items = listBox1.Items.Cast<string>().ToArray();
            File.WriteAllLines(textBox2.Text + @"\data.txt", items);

            label2.Text = "Deleted!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Undertale Saver Tool — файл экспорта|*.ust";


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file0 = File.ReadAllText(textBox2.Text + @"\" + listBox1.SelectedItem + @"\file0");
                string undertaleINI = File.ReadAllText(textBox2.Text + @"\" + listBox1.SelectedItem + @"\undertale.ini");
                string file9 = File.ReadAllText(textBox2.Text + @"\" + listBox1.SelectedItem + @"\file9");
                File.WriteAllText(saveFileDialog1.FileName, file0 + "\n" + undertaleINI + "\n" + file9);

                label2.Text = "Exported!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Undertale Saver Tool — файл экспорта|*.ust";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                UtsFile = File.ReadAllText(openFileDialog1.FileName);

                panel1.Show();
                import = true;
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undertale_Saver_Tool.Properties.Settings.Default.Language = "en-US";
            Undertale_Saver_Tool.Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undertale_Saver_Tool.Properties.Settings.Default.Language = "ru";
            Undertale_Saver_Tool.Properties.Settings.Default.Save();
            Application.Restart();
        }
    }
}
