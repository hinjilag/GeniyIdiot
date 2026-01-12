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
    public partial class ResultsForm3 : Form
    {
        public ResultsForm3()
        {
            InitializeComponent();
        }

        private void ResultsForm3_Load(object sender, EventArgs e)
        {
            string[] fileData = File.ReadAllLines("..\\..\\..\\results.txt");

            label2.Text = fileData[fileData.Length - 1].Replace("#", "    ");
            label3.Text = fileData[fileData.Length - 2].Replace("#", "    ");
            label4.Text = fileData[fileData.Length - 3].Replace("#", "    ");
            label5.Text = fileData[fileData.Length - 4].Replace("#", "    ");
            label6.Text = fileData[fileData.Length - 5].Replace("#", "    ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 play = new Form1();
            play.Show();
            Hide();
        }

        private void смотретьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultsForm3 play = new ResultsForm3();
            play.Show();
            Hide();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayForm2 play = new PlayForm2();
            play.Show();
            Hide();
        }

        private void входДляАдминаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminForm play = new adminForm();
            play.Show();
            Hide();
        }
    }
}
