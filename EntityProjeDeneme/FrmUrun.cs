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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DBEntityUrunEntities db= new DBEntityUrunEntities();
        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.TBLURUN.ToList();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.URUNAD = textBox2.Text;
            t.MARKA = textBox3.Text;
            t.STOK = Convert.ToInt16(textBox4.Text);
            t.FİYAT = Convert.ToDecimal(textBox5.Text);
            t.DURUM = true;
            t.KATEGORİ = Convert.ToInt16(comboBox1.Text);
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("BİLGİ EKLEME İŞLEMİ BAŞARILI");

        }
        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var ktg = (from x in db.TBLKATEGORI
                       select new
                       {
                           x.KATEGORİID,
                           x.KATEGORIAD
                       }
                       ).ToList();

            comboBox1.ValueMember = "KATEGORIID";
            comboBox1.DisplayMember = "KATEGORIAD";
            comboBox1.DataSource = ktg;
                       
                

             
        }
    }
}
