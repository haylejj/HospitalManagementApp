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
    public partial class FormHastaDetay : Form
    {
        public FormHastaDetay()
        {
            InitializeComponent();
        }

        public string tc;
        
        sqlbaglantısı bgl=new sqlbaglantısı();
        private void FormHastaDetay_Load(object sender, EventArgs e)
        {
            label2.Text = tc;
            //AD SOYAD ÇEKME
            SqlCommand komut=new SqlCommand("Select HastaAd,HastaSoyad from table_hasta where  HastaTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",label2.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //RANDEVU GEÇMİŞİ
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from table_randevu where hastatc="+tc,bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //Branşları Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd from table_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad from table_doktor where DoktorBrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",comboBox1.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]+" "+dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from table_randevu where randevubrans='" + comboBox1+"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formbilgidüzenle formbilgidüzenle=new formbilgidüzenle();
            formbilgidüzenle.tcno=label2.Text;
            formbilgidüzenle.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
