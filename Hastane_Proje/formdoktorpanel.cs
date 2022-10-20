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
    public partial class formdoktorpanel : Form
    {
        public formdoktorpanel()
        {
            InitializeComponent();
        }

       
        sqlbaglantısı bgl=new sqlbaglantısı();
        private void formdoktorpanel_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter("Select  * from table_doktor", bgl.baglanti());
            adapter1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            SqlCommand komut = new SqlCommand("Select bransad from table_branslar", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into table_doktor (doktorad,doktorsoyad,doktortc,doktorbrans,doktorsifre) values(@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox3.Text);
            komut.Parameters.AddWithValue("@p3", maskedTextBox1.Text); 
            komut.Parameters.AddWithValue("@p4", comboBox1.Text);
            komut.Parameters.AddWithValue("@p5",textBox2.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Bilgileri Başarıyla Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen=dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text=dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text=dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            comboBox1.Text=dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox2.Text=dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select from table_doktor where doktortc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("Update table_doktor set doktorad=@p1,doktorsoyad=@p2,doktorbrans=@p4,doktorsıfre=@p5 where doktortc=@p3",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p4", comboBox1.Text);
            komut.Parameters.AddWithValue("@p5", textBox2.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Bilgileri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
