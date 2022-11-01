using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entitiy_proje
{
    public partial class AnaForm : Form
    {

        EntityUrunEntities eu = new EntityUrunEntities();
        public AnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 kategori = new Form1();
            kategori.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            urun urn = new urun();
            urn.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            istatistik ist = new istatistik();
            ist.Show();
        }
    }
}
