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
    public partial class forumduyurular : Form
    {
        public forumduyurular()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl=new sqlbaglantısı();
        private void forumduyurular_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from table_duyurular",bgl.baglanti());
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
