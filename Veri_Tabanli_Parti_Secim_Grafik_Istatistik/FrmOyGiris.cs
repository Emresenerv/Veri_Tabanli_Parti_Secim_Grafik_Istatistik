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

namespace Veri_Tabanli_Parti_Secim_Grafik_Istatistik
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }
        //Sql bağlantısı
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-6JTJ49H;Initial Catalog=DBSECİM;Integrated Security=True;TrustServerCertificate=True");
        private void BtnOyGiris_Click(object sender, EventArgs e)
        {
            // Sql oyları ekleme
            baglanti.Open();
            SqlCommand komut= new SqlCommand("insert into TBLILCE (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) values (@P1,@P2,@P3,@P4,@P5,@P6)",baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtA.Text);
            komut.Parameters.AddWithValue("@p3", TxtB.Text);
            komut.Parameters.AddWithValue("@p4", TxtC.Text);
            komut.Parameters.AddWithValue("@p5", TxtD.Text);
            komut.Parameters.AddWithValue("@p6", TxtE.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy Girişi Başarılı");



        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            //Grafikler Formunu Açma
            FrmGrafikler fr= new FrmGrafikler();
            fr.Show();
        }

        private void BtnCıkıs_Click(object sender, EventArgs e)
        {
            //çıkış yapma
            Application.Exit();
        }
    }
}
