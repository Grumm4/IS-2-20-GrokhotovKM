using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace third
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ThirdP());
        }
        
    }
    public class ConnectToDb
    {
        public static string InsertData(string connect)
        {
            return connect;
        }
        public static void Page(DataGridView datagrid, MySqlConnection conn)
        {
            string load = $"select * from Main left join t_provider on Main.provider_id=t_provider.id";   
            MySqlCommand cmd = new MySqlCommand(load, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (read.Read())
            {
                data.Add(new string[7]);
                data[data.Count - 1][0] = read[0].ToString();
                data[data.Count - 1][1] = read[1].ToString();
                data[data.Count - 1][2] = read[2].ToString();
                data[data.Count - 1][3] = read[3].ToString();
                data[data.Count - 1][4] = read[4].ToString();
                data[data.Count - 1][5] = read[5].ToString();
                data[data.Count - 1][6] = read[6].ToString();
            }
            foreach (string[] s in data)
                datagrid.Rows.Add(s);

            read.Close();
        }
    }
}
