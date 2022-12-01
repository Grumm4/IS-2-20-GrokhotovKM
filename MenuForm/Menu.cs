using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IS_2_20_GrokhotovKM;
using second;
using third;

namespace MenuForm
{
    public partial class Menu : Form
    {
        FirstP first = new FirstP();
        SecondP second = new SecondP();
        ThirdP third = new ThirdP();

        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            first.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            second.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            third.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
