using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace IS_2_20_GrokhotovKM
{
    public partial class FirstP : Form
    {
        
        internal HardDisk hd;
        internal Graphic gp;
        
        public FirstP()
        {
            InitializeComponent();
        }

        
        public abstract class Access<T>
        {
            T Articul;
            internal decimal Price;
            internal short Year;
            public Access(decimal price, short year)
            {
                Price = price;
                Year = year;
            }
            //public Access()
            //{

            //}
            public abstract void Display(ListBox listbox);
        }


        internal class HardDisk : Access<string>
        {
            //Вращения
            private int turns;
            public int Turns_Sv
            {
                get { return turns; }
                set { turns = value; }
            }
            //
            //Интерфейс(поле)
            private string @interface;
            public string Interface_Sv
            {
                get { return @interface; }
                set { @interface = value; } 
            }
            //
            //Объём
            private int size;
            public int Size_Sv
            {
                get { return size; }
                set { size = value; }
            }
            //

            public HardDisk(decimal price, short year, int turns, string @interface, int size) :base(price, year)
            {
                Turns_Sv = turns;
                Interface_Sv = @interface;
                Size_Sv = size;
            }

            public override void Display(ListBox listbox)
            {
                listbox.Items.Add(String.Concat(Enumerable.Repeat("=", 20)));
                listbox.Items.Add($"\nЦена: {this.Price} \tГод: {this.Year}");
                listbox.Items.Add($"Вращения: {Turns_Sv}\tИнтерфейс: {Interface_Sv}\tОбъём: {Size_Sv}");
                listbox.Items.Add(String.Concat(Enumerable.Repeat("=", 20)));
            }
        }
        internal class Graphic : Access <string>
        {
            //Частота
            private double gpu_gh;
            public double GPU_Gh
            {
                get { return gpu_gh; }
                set { gpu_gh = value; }
            }
            //

            //Производитель
            private string maker;
            public string Maker
            {
                get { return maker; }
                set { maker = value; }
            }
            //

            //Объём памяти
            private short gpu_memory;
            public short GPU_Memory
            {
                get { return gpu_memory; }
                set { gpu_memory = value; }
            }
            //

            public Graphic(decimal price, short year, double gPU_Gh, string maker, short gPU_Memory):base(price, year)
            {
                GPU_Gh = gPU_Gh;
                Maker = maker;
                GPU_Memory = gPU_Memory;
            }

            public override void Display(ListBox listbox)
            {
                listbox.Items.Add(String.Concat(Enumerable.Repeat("=", 20)));
                listbox.Items.Add($"\nЦена: {this.Price} \tГод: {this.Year}");
                listbox.Items.Add($"Частота: {GPU_Gh}\tПроизводитель: {Maker}\tОбъём: {GPU_Memory}");
                listbox.Items.Add(String.Concat(Enumerable.Repeat("=", 20)));

            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Block();
            toolTip1.SetToolTip(textBox1, "Цена");
            toolTip1.SetToolTip(textBox2, "Год выпуска");
            toolTip1.SetToolTip(textBox3, "Количество оборотов");
            toolTip1.SetToolTip(textBox4, "Интерфейс");
            toolTip1.SetToolTip(textBox5, "Объём");
            toolTip1.SetToolTip(textBox6, "Частота GPU");
            toolTip1.SetToolTip(textBox7, "Производитель");
            toolTip1.SetToolTip(textBox8, "Объём памяти");

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Жёсткий диск")
            {
                hd = new HardDisk(Convert.ToDecimal(textBox1.Text), Convert.ToInt16(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, Convert.ToInt32(textBox5.Text));
            }
            else if (comboBox1.Text == "Видеокарта")
            {
                gp = new Graphic(Convert.ToDecimal(textBox1.Text), Convert.ToInt16(textBox2.Text), Convert.ToDouble(textBox6.Text), textBox7.Text, Convert.ToInt16(textBox8.Text));
            }
            MessageBox.Show("Инициализировано");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Жёсткий диск")
            {
                try { hd.Display(listBox1); }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
            else if (comboBox1.Text == "Видеокарта")
            {
                try { gp.Display(listBox1); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            Console.WriteLine();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Жёсткий диск")
            {
                Block();
                textBox1.Enabled = true; textBox2.Enabled = true; textBox3.Enabled = true; textBox4.Enabled = true; textBox5.Enabled = true; button1.Enabled = true; button2.Enabled = true;
            }
            else if(comboBox1.Text == "Видеокарта")
            {
                Block();
                textBox1.Enabled = true; textBox2.Enabled = true; textBox6.Enabled = true; textBox7.Enabled = true; textBox8.Enabled = true; button1.Enabled = true; button2.Enabled = true;
            }
            else if (comboBox1.Text == "")
            {
                Block();
            }
        }
        internal void Block()
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name != "comboBox1")
                {
                    c.Enabled = false;
                    if (!c.Name.Contains("button"))
                    {
                        c.Text = "";
                    }
                    
                }
            }
            listBox1.Items.Clear();
            //button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
