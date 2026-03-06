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

namespace GeniusOrIdiotsWindowsForms
{
    public partial class questionAdd : Form
    {
        public questionAdd()
        {
            InitializeComponent();
        }

        private void questionAdd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string addQuestion = textBoxQuestion.Text.Trim();
            string addAnswer = textBoxAnswer.Text.Trim();
            if (addQuestion == "" || addAnswer == "")
            {
                labelError.Visible = true;
                return;
            }
            labelError.Text = "Вопрос успешно добавлен";
            labelError.ForeColor = Color.Green;            
            File.AppendAllText("..\\..\\..\\questions.txt", addQuestion + Environment.NewLine);
            File.AppendAllText("..\\..\\..\\answers.txt", addAnswer + Environment.NewLine);
            button1.Enabled = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminForm play = new adminForm();
            play.Show();
            Hide();
        }
    }
}
