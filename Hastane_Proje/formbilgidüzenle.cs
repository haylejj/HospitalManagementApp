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

namespace Hastane_Proje
{
    public partial class formbilgidüzenle : Form
    {
        public formbilgidüzenle()
        {
            InitializeComponent();
        }

        public string tcno;
        sqlbaglantısı bgl=new sqlbaglantısı();
        private void formbilgidüzenle_Load(object sender, EventArgs e)
        {
         
            maskedTextBox1.Text=tcno;
            SqlCommand komut = new SqlCommand("Select * from table_hasta where hastatc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                maskedTextBox2.Text = dr[4].ToString();
                textBox3.Text = dr[5].ToString();
                comboBox1.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void Kayıt_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update table_hasta set hastaad=@p1,hastasoyad=@p2,hastatelefon=@p3,hastasifre=@p4,hastacinsiyet=@p5 where hastatc=@p6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", textBox1.Text);
            komut2.Parameters.AddWithValue("@p2", textBox2.Text);
            komut2.Parameters.AddWithValue("@p3", maskedTextBox2.Text);
            komut2.Parameters.AddWithValue("@p4", textBox3.Text);
            komut2.Parameters.AddWithValue("@p5",comboBox1.Text);
            komut2.Parameters.AddWithValue("@p6",maskedTextBox1.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
