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
namespace entitiy_proje
{
    public partial class urun : Form
    {
        EntityUrunEntities eu = new EntityUrunEntities();
        public urun()
        {
            InitializeComponent();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            var urunkategori = eu.urun_tablo.ToList();
            dataGridView1.DataSource = urunkategori;

            dataGridView1.DataSource = (from x in eu.urun_tablo
                                        select new
                                        {

                                            x.urun_ID,
                                            x.urun_AD,
                                            x.urun_marka,
                                            x.urun_stok,
                                            x.urun_fiyat,
                                            x.urun_durum,
                                            x.kategori_tablo.kategori_AD
                                        }).ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            urun_tablo t = new urun_tablo();

            t.urun_AD = txtAd.Text;
            t.urun_fiyat = Convert.ToInt32(txtFiyat.Text);
            t.urun_stok = int.Parse(txtStok.Text);
            t.urun_marka = txtMarka.Text;
            t.urun_kategori = int.Parse(comboBox1.SelectedValue.ToString());
            t.urun_durum = true;
            eu.urun_tablo.Add(t);
            eu.SaveChanges();
            MessageBox.Show("ÜRÜN SİSTEME BAŞARIYLA KAYDEDİLDİ!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtMarka.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtStok.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtFiyat.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtID.Text);
            var urun = eu.urun_tablo.Find(x);
            eu.urun_tablo.Remove(urun);
            eu.SaveChanges();
            MessageBox.Show("ÜRÜN BAŞARIYLA SİSTEMDEN SİLİNDİ!", "ÜRÜN SİLİNDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var urun = eu.urun_tablo.Find(x);
            urun.urun_AD = txtAd.Text;
            urun.urun_fiyat = Convert.ToInt32(txtFiyat.Text);
            urun.urun_stok = int.Parse(txtStok.Text);
            urun.urun_durum = Convert.ToBoolean(txtDurum.Text);
            urun.urun_marka = txtMarka.Text;
            MessageBox.Show("ÜRÜN BAŞARIYLA SİSTEMDE GÜNCELLENDİ!", "ÜRÜN GÜNCELLENDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void urun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in eu.kategori_tablo
                               select new
                               {
                                   x.kategori_ID,
                                   x.kategori_AD
                               }
                               ).ToList();
            comboBox1.ValueMember = "kategori_ID";
            comboBox1.DisplayMember = "kategori_AD";
            comboBox1.DataSource = kategoriler;

        }
    }
}
