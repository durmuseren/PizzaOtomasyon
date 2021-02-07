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
    public partial class Form2 : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sorgu = "SELECT * FROM uye where kisim=@kisim AND ksifre=@ksifre";
            con = new SqlConnection("server=.;Initial Catalog=PizzaOtomasyon;Integrated Security=SSPI");
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@kisim", textBox1.Text);
            cmd.Parameters.AddWithValue("@ksifre", textBox3.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.");

                Form1 form1 = new Form1();
                form1.Show();  // form1 göster diyoruz
                this.Hide();   // bu yani form1 gizle diyoruz

            }


            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            con.Close();

        }

      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox3.UseSystemPasswordChar = true;
                checkBox1.Text = "Gizle";
            }
            else if(checkBox1.CheckState==CheckState.Unchecked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
        }
    }
}