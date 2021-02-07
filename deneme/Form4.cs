using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace deneme
{
    public partial class Form4 : Form
    {
        SqlConnection baglanti;
     
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection("server=.;Initial Catalog=PizzaOtomasyon;Integrated Security=SSPI");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO uye (kisim, ksifre) VALUES (@kisim, @ksifre)", baglanti);

            cmd.Parameters.AddWithValue("kisim",textBox1.Text);

            cmd.Parameters.AddWithValue("ksifre", textBox2.Text);

            

            cmd.ExecuteNonQuery();


            baglanti.Close();
            MessageBox.Show("Tebrikler Üye Oldunuz");
            Form1 form1 = new Form1();
            form1.Show();  // form1 göster diyoruz
            this.Hide();   // bu yani form1 gizle diyoruz
        }


    }
}
