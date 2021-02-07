using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ekurun = "";
            string adsoyad = textBox1.Text;
            string telefon = textBox2.Text;
            string adres = richTextBox1.Text;
            string pizzatipi = comboBox1.SelectedItem.ToString();
            string icecek= comboBox2.SelectedItem.ToString();
            string hamur = comboBox3.SelectedItem.ToString();
            string kenar = comboBox4.SelectedItem.ToString();
            int pizzaadet = Convert.ToInt32(numericUpDown1.Value);
            int icecekadet = Convert.ToInt32(numericUpDown2.Value);
            double toplamtutar = 0;
            if (pizzatipi == "küçük") toplamtutar = toplamtutar + 18 * pizzaadet;
            else if (pizzatipi == "orta") toplamtutar += (20 * pizzaadet);
            else if (pizzatipi == "büyük") toplamtutar += (24 * pizzaadet);
            if (icecek == "kola") toplamtutar += (5 * icecekadet);
            else if (icecek == "fanta") toplamtutar += (4 * icecekadet);
            else if (icecek == "ayran") toplamtutar += (3 * icecekadet);
            if (hamur == "klasik") toplamtutar += (pizzaadet * 2);
          else  if (hamur == "ince") toplamtutar += (pizzaadet * 1.2);
         else   if (hamur == "kalın") toplamtutar += (pizzaadet * 2.1);
            if (kenar == "klasik") toplamtutar += (pizzaadet * 0.5);
          else  if (kenar == "kalın") toplamtutar += (pizzaadet * 1.5);
          else  if (kenar == "susamlı") toplamtutar += (pizzaadet * 2);
            if (checkBox1.Checked)
            {
                ekurun += "Sucuk";
                toplamtutar += (pizzaadet * 0.5);
            }
            if (checkBox3.Checked) ekurun += "salam";
            if (checkBox5.Checked) ekurun += "mantar";
            if (checkBox2.Checked) ekurun += "kaşar";
            if (checkBox4.Checked) ekurun += "peynir";
            if (checkBox6.Checked)
            {
                ekurun += "sebze";
                toplamtutar = toplamtutar + pizzaadet*1.2;
            }
            listBox1.Items.Add(adsoyad);
            listBox2.Items.Add(telefon);
            listBox3.Items.Add(adres);
            listBox4.Items.Add(pizzatipi + "x" + pizzaadet + "adet");
            listBox5.Items.Add(ekurun);
            listBox6.Items.Add(icecek + "x" + icecekadet + "adet");
            listBox7.Items.Add(toplamtutar+"tl");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Silindi.");
            
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                comboBox2.Items.RemoveAt(comboBox2.SelectedIndex);
                comboBox3.Items.RemoveAt(comboBox3.SelectedIndex);
                comboBox4.Items.RemoveAt(comboBox4.SelectedIndex);
                foreach (var kontrol in this.Controls) //checkboxların hepsini aynı anda temizleme
                {
                    CheckBox cbox = new CheckBox();
                    if (kontrol is CheckBox)
                    {
                        cbox = (CheckBox)kontrol;
                        cbox.Checked = false;
                    }
                }
                richTextBox1.Text = ""; //textbox temizleme
                numericUpDown1.Value = 0; //numericupdownvalue temizleme
                numericUpDown2.Value = 0;
            }
        }
    }
}
