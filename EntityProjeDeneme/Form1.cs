using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeDeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DBEntityUrunEntities db = new DBEntityUrunEntities();
        
        private void button1_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TBLKATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TBLKATEGORI t = new TBLKATEGORI();
            textBox2.Text.ToUpper();
            t.KATEGORIAD = textBox2.Text;
            db.TBLKATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("KATEGORI EKLEME ISLEMI BASARILI");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktg = db.TBLKATEGORI.Find(x); // TBLKATEGORIDE X DEĞERİNE KARŞILIK GELENİ BUL METODU 
            db.TBLKATEGORI.Remove(ktg); //ktg den gelen değeri TBLKATEGORI deN kaldır
            db.SaveChanges();
            MessageBox.Show("SİLME İŞLEMİ BAŞARILI");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int k = Convert.ToInt32(textBox1.Text);
            var ktg = db.TBLKATEGORI.Find(k);
            ktg.KATEGORIAD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("GUNCELLEME ISLEMI BAŞARILI");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
