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
    public partial class FormDoktorGiris : Form
    {
        public FormDoktorGiris()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl=new sqlbaglantısı();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from table_doktor where doktortc=@p1 and doktorsıfre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox1.Text);
            SqlDataReader rd=komut.ExecuteReader();
            if (rd.Read())
            {
                formDoktorDetay formDoktorDetay = new formDoktorDetay();
                formDoktorDetay.tc = maskedTextBox1.Text;
                formDoktorDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");
            }
            bgl.baglanti().Close();
                    
        }
    }
}
