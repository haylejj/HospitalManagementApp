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
    public partial class formDoktorDetay : Form
    {
        public formDoktorDetay()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl=new sqlbaglantısı();
        public string tc;
        private void formDoktorDetay_Load(object sender, EventArgs e)
        {
            label2.Text = tc;

            // doktor ad soyad çekme
            SqlCommand cmd = new SqlCommand("select doktorad,doktorsoyad from table_doktor where doktortc=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",label2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();
            // randevulat
            DataTable dt = new DataTable();
            SqlDataAdapter dtr=new SqlDataAdapter("select * from table_randevu where randevudoktor='"+label4.Text+"'", bgl.baglanti());
            dtr.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formdoktorbilgiduzenle form=new formdoktorbilgiduzenle();
            form.tcno = label2.Text;
            form.Show();

        }
    }
}
