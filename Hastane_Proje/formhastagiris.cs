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
    public partial class formhastagiris : Form
    {
        public formhastagiris()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı(); 

        private void button1_Click(object sender, EventArgs e)
        {
           SqlCommand cmd = new SqlCommand("Select * from table_hasta where HastaTC=@p1 and HastaSifre=@p2",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p2",textBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FormHastaDetay formHastaDetay = new FormHastaDetay();
                formHastaDetay.tc = maskedTextBox1.Text;
                formHastaDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Tc veya Şifre");
            }
            bgl.baglanti().Close();

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formhastakayıt hastakayıt=new formhastakayıt();
            hastakayıt.Show();
            this.Hide();
        }
    }
}
