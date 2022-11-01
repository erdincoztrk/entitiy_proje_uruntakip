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
    public partial class istatistik : Form
    {
        public istatistik()
        {
            InitializeComponent();
        }
        EntityUrunEntities eu = new EntityUrunEntities();
        private void istatistik_Load(object sender, EventArgs e)
        {
            lblkategori.Text = eu.kategori_tablo.Count().ToString();
            tplurun.Text = eu.urun_tablo.Count().ToString();
            aktifmusteri.Text = eu.musteri_tablo.Count(x => x.musteri_durum == true).ToString();
            pasifmusteri.Text = eu.musteri_tablo.Count(x => x.musteri_durum == false).ToString();
            toplamstok.Text = eu.urun_tablo.Sum(x => x.urun_stok).ToString();
            tutar.Text = eu.satis_tablo.Sum(x => x.satis_fiyat) + "TL";
            enyuksekurun.Text = (from x in eu.urun_tablo orderby x.urun_fiyat descending select x.urun_AD).FirstOrDefault();
            endusukurun.Text = (from x in eu.urun_tablo orderby x.urun_fiyat ascending select x.urun_AD).FirstOrDefault();
            beyazesya.Text = eu.urun_tablo.Count(x => x.urun_kategori == 1).ToString();
            sehir.Text = (from x in eu.musteri_tablo select x.musteri_sehir).Distinct().Count().ToString();
            fazlaurun.Text = eu.markagetir().FirstOrDefault().ToString();
        }
    }
}
