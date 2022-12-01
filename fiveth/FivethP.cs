using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectToDB;
using MySql.Data.MySqlClient;

namespace fiveth
{
    public partial class FivethP : Form
    {
        public static string connStr = "server=chuc.caseum.ru;port=33333;user=st_2_20_8;database=is_2_20_st8_KURS;password=82411770;";
        Connect getConn = new Connect(connStr);
        MySqlConnection connect = new MySqlConnection(Connect.GetStr());
        public FivethP()
        {
            InitializeComponent();
        }


        private void FivethP_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Числовой ID");
            toolTip1.SetToolTip(textBox2, "ФИО");
            toolTip1.SetToolTip(textBox3, "Дата в формате YYYY.MM.DD");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query0 = "UPDATE t_Uchebka_GROKHOTOV SET fioStud = null; UPDATE t_Uchebka_GROKHOTOV SET datetimeStud = null;";
                string query = $"INSERT t_Uchebka_GROKHOTOV(idStud, fioStud, datetimeStud) VALUES({Convert.ToInt32(textBox1.Text)},'{textBox2.Text}','{textBox3.Text}')";
                
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, connect);
                //MySqlCommand cmd0 = new MySqlCommand(query0, connect);
                //cmd0.ExecuteNonQuery();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
