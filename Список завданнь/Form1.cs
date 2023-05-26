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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static Список_завданнь.Form1;

namespace Список_завданнь
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Password
        {
            public string password;
            public Password(string password)
            {
                this.password = password;
            }
        }
        public List<Password> passw = new List<Password>();
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            foreach (Password pass in passw)
            {
                richTextBox1.AppendText(pass.password + Environment.NewLine);
            }
        }
        public string[] arr = { "a", "b", "c", "1", "2", "3", "x", "y", "z", "4" };
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                passw.Add(new Password("Text"));
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string newpass = textBox2.Text;
            passw.Add(new Password(newpass));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            richTextBox1.Clear();
            int k = (int)numericUpDown1.Value;
            if (k == 0)
            {
                MessageBox.Show("Довжина паролю повинна бути більше за нуль");
            }
            else
            {


                for (int i = 0; i < k; i++)
                {


                    int x = rand.Next(0, arr.Length);
                    richTextBox1.Text += arr[x];


                }
                passw.Add(new Password(richTextBox1.Text));
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string newpass = textBox1.Text;
            List<Password> passwordsToRemove = passw.Where(p => p.password == newpass).ToList();
            foreach (Password passwordToRemove in passwordsToRemove)
            {
                passw.Remove(passwordToRemove);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {

            string tofile = textBox3.Text;
            try
            {
                using (StreamWriter writer = new StreamWriter(tofile))
            {
               


                    foreach (Password password in passw)
                    {
                        writer.WriteLine(password.password);
                    }
               
                   
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка {ex.Message}");
            }
        }
    }

    }

    

