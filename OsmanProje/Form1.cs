using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;



namespace OsmanProje
{
    public partial class Form1 : Form
    {
        IEnumerable<dynamic> ogrenciler;
        IEnumerable<dynamic> yediOgrenciler;
        public Form1()
        {
            InitializeComponent();
            OgrenciYukle();

        }






        private void OgrenciYukle()
        {
            ogrenciler = SqliteDataAccess.SekizOgrenciYukle();
            yediOgrenciler = SqliteDataAccess.YediOgrenciYukle();

            Listele();

        }




        private void Listele()
        {
            listView1.Items.Clear();
            foreach (var ogrenci in ogrenciler)
            {
                var row = new string[] { ogrenci.OgrenciID.ToString(), ogrenci.OgrenciAD };
                var lvi = new ListViewItem(row);
                lvi.Tag = ogrenci;
                listView1.Items.Add(lvi);

            }

            listView2.Items.Clear();
            foreach (var ogrenci in yediOgrenciler)
            {
                var row = new string[] { ogrenci.OgrenciID.ToString(), ogrenci.OgrenciAD };
                var lvi = new ListViewItem(row);
                lvi.Tag = ogrenci;
                listView2.Items.Add(lvi);

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciModel o = new OgrenciModel();

            o.Ad = textBox1.Text;

            if (radioButton1.Checked == true)
            {
                SqliteDataAccess.SekizOgrenciKaydet(o);
                textBox1.Text = "";
            }
            else if (radioButton2.Checked == true)
            {
                SqliteDataAccess.YediOgrenciKaydet(o);
                textBox1.Text = "";
            }



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciModel o = new OgrenciModel();

            o.Id = int.Parse(textBox2.Text);

            SqliteDataAccess.OgrenciSil(o);

            textBox2.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OgrenciYukle();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgrenciYukle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
                ExtractTextFromPdf(file);
            }
        }

        public void ExtractTextFromPdf(string path)
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();
                ITextExtractionStrategy Strategy = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();

                for (int i = 1; i <= 1; i++) //i<=1 yerinde reader.NumberOfPages yazıyor
                {
                    string page = "";

                    page = PdfTextExtractor.GetTextFromPage(reader, i, Strategy);
                    string[] lines = page.Split('\n');
                    int a = 0;
                    foreach (string line in lines)
                    {

                        if (a == 11)
                            PdfToDb.SinavKaydet(line);

                       // MessageBox.Show(line + " " + a + ".Satır");

                        a++;

                        


                    }
                }
            }
        }


    }
}
