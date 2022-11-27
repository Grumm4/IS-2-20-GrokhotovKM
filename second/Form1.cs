using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace second
{
    public partial class Form1 : Form
    {
        static string connect = "server=chuc.caseum.ru; port=33333; database=uchebka; user=uchebka; password=uchebka";
        private class ConnectDB
        {
            internal string ReturnConnect(string connect) => connect;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectDB conn = new ConnectDB();
                MySqlConnection connection = new MySqlConnection(connect);
                connection.Open();
                connection.Close();
                MessageBox.Show(conn.ReturnConnect(connect));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Application.Exit();
            
        }
    }
}
