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
using fourth;
using fiveth;

namespace MenuForm
{
    public partial class Menu : Form
    {
        FirstP first = new FirstP();
        SecondP second = new SecondP();
        ThirdP third = new ThirdP();
        FourthP fourth = new FourthP();
        FivethP fiveth = new FivethP();

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
            second.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            third.ShowDialog();
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            fourth.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fiveth.ShowDialog();
        }
    }
}
