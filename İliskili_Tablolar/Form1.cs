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

namespace İliskili_Tablolar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-FUNPM7I;Initial Catalog=DboSehirListesi;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" Select SehirAd from tbl_sehirler", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select ilcead from tbl_ilceler where ilid=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", comboBox1.SelectedIndex + 1);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2[0]);
            }
            baglanti.Close();
        }
    }
}
