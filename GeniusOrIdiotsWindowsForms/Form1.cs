using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeniusOrIdiotsWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string userName = textBox1.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            //while (userName == "")
            //{
            //    label1.Text = "Зовут как тебя говорю???";
            //    userName = textBox1.Text.Trim();
            //}
            label1.Text = $"Здраствуй ,{userName} , выбери действие (введи номер)";
            
                
        }
    }
}
