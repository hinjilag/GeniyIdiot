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
    public partial class adminForm : Form
    {
        public adminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            questionAdd play = new questionAdd();
            play.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 play = new Form1();
            play.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteForm play = new deleteForm();
            play.Show();
            Hide();
        }
    }
    
}
