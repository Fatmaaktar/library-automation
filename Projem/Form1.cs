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

namespace Projem
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0KPVKP2;Initial Catalog=Kitaplar;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
        private void listele()
        {

            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Klasikler", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Klasikler(KitapAd,KitapYazar,YayinAd) values(@k2,@k3,@k4)", baglanti);
            komut.Parameters.AddWithValue("@k2", txtad.Text);
            komut.Parameters.AddWithValue("@k3", txtyazar.Text);
            komut.Parameters.AddWithValue("@k4", txtyayin.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Eklendi");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete from Klasikler where KitapNo=@k1", baglanti);
            sil.Parameters.AddWithValue("@k1", txtno.Text);
            sil.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi");
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//(çift tıkla)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            txtno.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            txtyazar.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            txtyayin.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            
        }
          int i = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Klasikler SET  KitapAd =@k2, KitapYazar = @k3, YayinAd =@k4 where KitapNo = @k1", baglanti);
            komut.Parameters.AddWithValue("@k1", txtno.Text);
            komut.Parameters.AddWithValue("@k2", txtad.Text);
            komut.Parameters.AddWithValue("@k3", txtyazar.Text);
            komut.Parameters.AddWithValue("@k4", txtyayin.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi");
            baglanti.Close();
        }
    }
}
