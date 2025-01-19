using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veri_Tabanli_Parti_Secim_Grafik_Istatistik
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        //Sql bağlantıs
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-6JTJ49H;Initial Catalog=DBSECİM;Integrated Security=True;TrustServerCertificate=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //sqlden verileri çekme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select ILCEAD From TBLILCE", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) 
            {
                comboBox1.Items.Add(dr[0]);
                
                }
            baglanti.Close();

            //Oy oranları grafiğe çekme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Sum(APARTI),Sum(BPARTI),Sum(CPARTI),Sum(DPARTI),Sum(EPARTI) FROM TBLILCE", baglanti); 
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti",dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti",dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti",dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti",dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti",dr2[4]);
                
            }
            baglanti.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Progpresbara veri çekme
            baglanti.Open();
            SqlCommand komut=new SqlCommand("Select * From TBLILCE where ILCEAD=@P1",baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                Lbl1.Text = dr[2].ToString();
                Lbl2.Text = dr[3].ToString();
                Lbl3.Text = dr[4].ToString();
                Lbl4.Text = dr[5].ToString();
                Lbl5.Text = dr[6].ToString();
            }
            baglanti.Close();
        }
    }
}
