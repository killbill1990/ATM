using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace ComboBox
{
    public partial class Form1 : Form
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OKIJB0T;Initial Catalog=data1;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from fileRelation";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                
                comboBox1.Items.Add(dr["keyCase"].ToString());
               
            }

            con.Close();
        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select * from fileTelephone  where keyPerson='"+comboBox1.SelectedItem.ToString()+"'";
            cmd.CommandText = "select filePayment.amountPay,filePayment.clews,fileTelephone.telephone from filePayment  join fileRelation on filePayment.keyCase = fileRelation.keyCase join fileTelephone on fileRelation.keyPerson = fileTelephone.keyPerson   where fileRelation.keyCase = '" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["telephone"].ToString();
                textBox2.Text = dr["amountPay"].ToString();
                textBox3.Text = dr["clews"].ToString();

            }

           
            con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            

        }

       
    }
}
