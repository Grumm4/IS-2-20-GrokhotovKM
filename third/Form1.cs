using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace third
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string connStr = "server=chuc.caseum.ru;port=33333;user=st_2_20_8;database=is_2_20_st8_KURS;password=82411770;";
        MySqlConnection conn = new MySqlConnection(connStr);
        private void Form1_Load(object sender, EventArgs e)
        {
            conn.Open();
            ConnectToDb.Page(dataGridView1, conn);
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ConnectToDb.InsertData(connStr));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show($"{dataGridView1[e.ColumnIndex, e.RowIndex].Value}");
        }
    }
}
