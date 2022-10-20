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
    public partial class forumsekretergiris : Form
    {
        public forumsekretergiris()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl=new sqlbaglantısı();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("select * from table_sekreter where sekretertc=@p1 and sekretersifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox1.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                forumsekreterdetay forumsekreterdetay = new forumsekreterdetay();
                forumsekreterdetay.tc = maskedTextBox1.Text;
                forumsekreterdetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girdiğiniz tc veya şifre hatalı!!");
            }
            bgl.baglanti().Close();
        }
    }
}
