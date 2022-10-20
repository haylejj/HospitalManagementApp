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
    public partial class formdoktorbilgiduzenle : Form
    {
        public formdoktorbilgiduzenle()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl=new sqlbaglantısı();
        public string tcno;
        private void formdoktorbilgiduzenle_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = tcno;

            SqlCommand komut = new SqlCommand("select * from table_doktor where doktortc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                comboBox1.Text= dr[4].ToString();
            }
            bgl.baglanti().Close();
        }

        private void Kayıt_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("update table_doktor set doktorad=@p1,doktorsoyad=@p2,doktorbrans=@p4 where doktortc=@p3",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox2.Text);
            komut.Parameters.AddWithValue("@p3",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p4",comboBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi");
        }
    }
}
