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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EntityUrunEntities eu = new EntityUrunEntities();
        private void btnlistele_Click(object sender, EventArgs e)
        {
            var kategoriler = eu.kategori_tablo.ToList();
            dataGridView1.DataSource = kategoriler;

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            kategori_tablo t = new kategori_tablo();
            t.kategori_AD = textBox2.Text;
            eu.kategori_tablo.Add(t);
            eu.SaveChanges();
            MessageBox.Show("KATEGORİ EKLENDİ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = eu.kategori_tablo.Find(x);
            eu.kategori_tablo.Remove(ktgr);
            eu.SaveChanges();
            MessageBox.Show("KATEGORİ SİLİNDİ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = eu.kategori_tablo.Find(x);
            ktgr.kategori_AD = textBox2.Text;
            eu.SaveChanges();
            MessageBox.Show("KATEGORİ GÜNCELLENDİ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
