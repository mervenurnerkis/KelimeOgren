using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KelimeOgren
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C: \Users\Merve Nur\Desktop\dbSozluk.mdb");

        Random rast = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            int sayi;
            sayi = rast.Next(1, 2490);
            

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from sozluk where id = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", sayi);
            OleDbDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                txtingilizce.Text = dr[1].ToString();
                LblCevap.Text = dr[2].ToString();
            }
            baglanti.Close();

          

        }

       
    }
}
