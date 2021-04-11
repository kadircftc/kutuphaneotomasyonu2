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


namespace kütüphaneotomasyonu2
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter dat;


        public Form1()
        {
            InitializeComponent();
        }

        void üyegetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-OVIOK7K\\SQLEXPRESS;Initial Catalog=otomasyon2;Integrated Security=True");
            baglanti.Open();
            dat = new SqlDataAdapter("SELECT *FROM otomasyon3", baglanti);
            DataTable tablo = new DataTable();
            dat.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            üyegetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtuyeıd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtuyead.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtuyesoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtno.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txttc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO otomasyon3(ÜyeAd,ÜyeSoyad,TCNo,Tarih,Telefon) values (@ad,@soyad,@tc,@tarih,@telefon)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", txtuyead.Text);
            komut.Parameters.AddWithValue("@soyad", txtuyesoyad.Text);
            komut.Parameters.AddWithValue("@tc", txttc.Text);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@telefon", txtno.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            üyegetir();
            MessageBox.Show("Üye Kaydedildi!");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM otomasyon3 WHERE ÜyeID=@ıd";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ıd", Convert.ToInt32(txtuyeıd.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            üyegetir();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE otomasyon3 SET ÜyeAd=@ad ,ÜyeSoyad=@soyad ,TCNo=@tc,  Tarih=@tarih, Telefon=@tel WHERE ÜyeID=@ıd";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ıd", Convert.ToInt32(txtuyeıd.Text));
            komut.Parameters.AddWithValue("@ad", txtuyead.Text);
            komut.Parameters.AddWithValue("@soyad", txtuyesoyad.Text);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@tel",txtno.Text);
            komut.Parameters.AddWithValue("@tc", txttc.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            üyegetir();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }
    }
}
