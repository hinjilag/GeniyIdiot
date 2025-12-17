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
        string userName;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            userName = textBox1.Text.Trim();
            if (userName == "")
            {
                label1.Text = "Зовут как тебя говорю???";
                label1.Visible = true;
            }
            else
            {
                label1.Text = $"Здраствуй ,{userName} , выбери действие (введи номер)";
                playButton.Visible = true;
                resultsButton.Visible = true;
                adminButton.Visible = true;
                label1.Visible = true;
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayForm2 play = new PlayForm2();
            play.Show();
            Hide();
        }
    }
}
