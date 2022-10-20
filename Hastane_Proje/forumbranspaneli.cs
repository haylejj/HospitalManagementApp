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
    public partial class forumbranspaneli : Form
    {
        public forumbranspaneli()
        {
            InitializeComponent();
        }

        sqlbaglantısı bgl=new sqlbaglantısı();

        private void button1_Click(object sender, EventArgs e)
        {
           SqlCommand komut=new SqlCommand("insert into table_branslar (bransad) values (@p1)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",textBox3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Eklendi.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update table_branslar set  bransad=@p1 where bransid=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox3.Text);
            komut.Parameters.AddWithValue("@p2",textBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş güncellendi.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from table_branslar where bransid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Silindi.");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen=dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox3.Text=dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void forumbranspaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dtr = new SqlDataAdapter("select * from table_branslar", bgl.baglanti());
            dtr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
