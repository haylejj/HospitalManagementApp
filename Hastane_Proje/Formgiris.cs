using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Proje
{
    public partial class Formgiris : Form
    {
        public Formgiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formhastagiris formhastagiris = new formhastagiris();
            formhastagiris.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDoktorGiris formDoktorGiris = new FormDoktorGiris();
            formDoktorGiris.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            forumsekretergiris forumsekretergiris = new forumsekretergiris();
            forumsekretergiris.Show();
            this.Hide();
        }
    }
}
