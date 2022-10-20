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
    public partial class forumsekreterdetay : Form
    {
        public forumsekreterdetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantısı bgl=new sqlbaglantısı();
        
        private void forumsekreterdetay_Load(object sender, EventArgs e)
        {
            
            label2.Text = tc;
            //Ad soyad
            SqlCommand komut=new SqlCommand("Select sekreteradsoyad from table_sekreter where sekretertc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",label2.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            // bransları datagride aktarma
            DataTable dt=new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select bransad from table_branslar", bgl.baglanti());
            adapter.Fill(dt);   
            dataGridView1.DataSource = dt;
            //doktorları datagride aktarma
            DataTable dt2=new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter("Select (doktorad + ' ' + doktorsoyad) as 'Doktorlar',doktorbrans from table_doktor", bgl.baglanti());
            adapter2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            // bransı comboboxa aktarma
            SqlCommand komut2 = new SqlCommand("Select bransad from table_branslar", bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into table_randevu (randevutarih,randevusaat,randevubrans,randevudoktor) values(@p1,@p2,@p3,@p4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komutkaydet.Parameters.AddWithValue("@p2", maskedTextBox2.Text);
            komutkaydet.Parameters.AddWithValue("@p3",comboBox1.Text);
            komutkaydet.Parameters.AddWithValue("@p4",comboBox2.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            SqlCommand komut = new SqlCommand("Select doktorad,doktorsoyad from table_doktor where doktorbrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into table_duyurular (duyuru) values (@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",richTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formdoktorpanel fr=new formdoktorpanel();
            fr.Show();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            forumbranspaneli forumbranspaneli = new forumbranspaneli();
            forumbranspaneli.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           formrandevulistesi formrandevulistesi = new formrandevulistesi();
            formrandevulistesi.Show();
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            forumduyurular forumduyurular=new forumduyurular();
            forumduyurular.Show();
        }
    }
}
