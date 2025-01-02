using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Porje
{
    public partial class Form1 : Form
    {
        // SQL bağlantı tanımı
        SqlConnection con = new SqlConnection("server=DESKTOP-3U064FC; Initial Catalog=CiftlikYonetim;Integrated Security=SSPI");

        public Form1()
        {
            InitializeComponent();
        }

        // Listele butonuna tıklanınca çalışacak fonksiyon
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = richTextBox1.Text;

                // Sorgunun boş olup olmadığını kontrol et
                if (string.IsNullOrEmpty(sorgu))
                {
                    MessageBox.Show("Lütfen bir sorgu girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Veritabanı işlemleri
                SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
