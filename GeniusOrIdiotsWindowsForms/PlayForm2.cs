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
    public partial class PlayForm2 : Form
    {
        public PlayForm2()
        {
            InitializeComponent();
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            textBoxQuestion.Visible = true;
            labelQuestion.Visible = true;

        }
    }
}
