using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Porje
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-3U064FC; Initial Catalog=CiftlikYonetim;Integrated Security=SSPI");
      
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridView1.CustomDrawEmptyForeground += gridView1_CustomDrawEmptyForeground;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = richTextBox1.Text;

                if (string.IsNullOrEmpty(sorgu))
                {
                    MessageBox.Show("Lütfen bir sorgu girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.RowCount == 0)
            {
                string message = "Hiçbir veri bulunamadı";
                Font font = new Font("Tahoma", 12, FontStyle.Bold);
                Rectangle r = e.Bounds;
                e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#F0F4F8")), r);
                e.Appearance.ForeColor = Color.Gray;
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                e.Graphics.DrawString(message, font, new SolidBrush(e.Appearance.ForeColor), r, e.Appearance.GetStringFormat());
                e.Handled = true;
            }
        }
    }
}
