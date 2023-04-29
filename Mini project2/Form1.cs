using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mini_project2
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ahmad_bqh2ijo\source\repos\Mini project2\Mini project2\Database1.mdf"";Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = Int32.Parse(textBox4.Text.ToString());
            string item = textBox1.Text.ToString();
            int price = Int32.Parse(textBox2.Text.ToString());
            int quantity = Int32.Parse(textBox3.Text.ToString());
            SqlCommand sq = new SqlCommand("insert into items values(" + id + ",'" + item + "','" + price + "', " + quantity + ")", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sq = new SqlCommand("delete from items where id = " + textBox4.Text + " ", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = Int32.Parse(textBox4.Text.ToString());
            string name = textBox1.Text.ToString();
            string address = textBox3.Text.ToString();
            int phone = Int32.Parse(textBox2.Text.ToString());
            SqlCommand sq = new SqlCommand("update items set name ='" + name + "', address = '" + address + "', phonenumber = " + phone + " where id = " + id + " ", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from items", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
