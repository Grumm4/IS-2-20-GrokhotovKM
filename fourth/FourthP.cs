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
using ConnectToDB;

namespace fourth
{
    public partial class FourthP : Form
    {
        public static string connStr = "server=10.90.12.110;port=33333;user=st_2_20_8;database=is_2_20_st8_KURS;password=82411770;";
        Class1 db = new Class1(connStr);
        //parse parser = new parse();
        
        MySqlConnection conn = new MySqlConnection(connStr);
        public FourthP()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "https://www.ejin.ru/wp-content/uploads/2017/09/4-597.jpg";
        }

        private void FourthP_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(db.GetStr());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM t_datatime";
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int r = dataGridView1.Rows.Add();
                    dataGridView1.Rows[r].Cells[0].Value = reader[0].ToString();
                    dataGridView1.Rows[r].Cells[1].Value = reader[1].ToString();
                    dataGridView1.Rows[r].Cells[2].Value = parse.DateParser.Parser(reader[2].ToString());
                    dataGridView1.Rows[r].Cells[3].Value = reader[3].ToString();
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string id = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();

            try
            {
                conn.Open();
                string sql = $"SELECT photoUrl FROM t_datatime WHERE id = {id}";
                MySqlCommand command = new MySqlCommand(sql, conn);

                string url = command.ExecuteScalar().ToString();

                pictureBox1.ImageLocation = url;
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
