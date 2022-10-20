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
    public partial class formrandevulistesi : Form
    {
        public formrandevulistesi()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl=new sqlbaglantısı();
        private void formrandevulistesi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dtr=new SqlDataAdapter("Select * from table_randevu",bgl.baglanti());
            dtr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
