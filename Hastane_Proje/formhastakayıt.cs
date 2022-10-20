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
    public partial class formhastakayıt : Form
    {
        public formhastakayıt()
        {
            InitializeComponent();
        }

        sqlbaglantısı bgl= new sqlbaglantısı();
        private void Kayıt_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into table_hasta (HastaAd,HastaSoyad,HastaTc,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox2.Text);
            komut.Parameters.AddWithValue("@p3",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p4",maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p5",textBox3.Text);
            komut.Parameters.AddWithValue("@p6", textBox4.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir. Şifreniz:"+textBox3.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

            formhastagiris formhastagiris = new formhastagiris();
            formhastagiris.Show();
            this.Hide();
        }
    }
}
