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

namespace DatabaseÇalışma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = students; Integrated Security = True");
        //Data Source=DESKTOP-6OS4T39\SQLEXPRESS;Initial Catalog=students;Integrated Security=True
        private void veriGöster()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from bilgiler", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku .Read() )
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["adsoyad"].ToString();
                ekle.SubItems.Add(oku["şehir"].ToString());
                ekle.SubItems.Add(oku["okul"].ToString());
                ekle.SubItems.Add(oku["kulüp"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            veriGöster();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}