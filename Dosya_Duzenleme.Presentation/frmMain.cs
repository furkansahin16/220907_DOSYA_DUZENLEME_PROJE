using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dosya_Duzenleme.Domain;
using Dosya_Duzenleme.Domain.Entities;
using Dosya_Duzenleme.Domain.Enum;
using Dosya_Duzenleme.Infrastructure.Repository;

namespace Dosya_Duzenleme.Presentation
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            dosyaAçToolStripMenuItem.Click += new EventHandler(Button_Click);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            AçılışEkranı();
        }

        private void AçılışEkranı()
        {
            Label açılışYazı = new Label()
            {
                Name = "lblAçılış",
                Text = "Lütfen düzenlemek istediğiniz dosyayı seçiniz",
                Width = 500,
            };

            Button btnTemp = new Button()
            {
                Name = "btnTemp",
                Text = "Dosya Seç",
                Tag = 1,
                Width = 100
            };
            btnTemp.Click += new System.EventHandler(Button_Click);
            flpDosyaListesi.Controls.Add(açılışYazı);
            flpDosyaListesi.Controls.Add(btnTemp);
        }

        private string _dosyaYolu;
        private void Button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.ShowDialog();

            _dosyaYolu = fbd.SelectedPath;

            AnaKlasör.KlasörOluştur(_dosyaYolu);

            DosyaListele(AnaKlasör.Klasörüm);
        }

        private void DosyaListele(Klasör klasörüm)
        {
            ListView lstDosya = ListViewOLuştur();
            ListViewDoldur(lstDosya, klasörüm);
        }

        private void ListViewDoldur(ListView lst, Klasör anaKlasör)
        {
            foreach (Klasör klasör in anaKlasör.Klasörler)
            {
                string[] satır = { klasör.İsim,klasör.DosyaTipi.ToString() , klasör.SonDeğiştirmeTarihi.ToString(),"Açıklama Yok","--",klasör.Dosyalar.Count.ToString() + " Dosya"};
                var yeniSatır = new ListViewItem(satır);
                lst.Items.Add(yeniSatır);
            }
            foreach (Dosya dosya in anaKlasör.Dosyalar)
            {
                string[] satır = { dosya.İsim, dosya.DosyaUzantısı, dosya.SonDeğiştirmeTarihi.ToString(), dosya.DosyaAçıklaması, GeçerlilikSüresiGetir(dosya), dosya.Boyut.ToString() };
                var yeniSatır = new ListViewItem(satır);
                lst.Items.Add(yeniSatır);
            }
        }

        private string GeçerlilikSüresiGetir(Dosya dosya)
        {
            if (dosya.GeçerlilikSüresi == DateTime.MinValue)
            {
                return "Atanmamış";
            }
            return dosya.GeçerlilikSüresi.ToString("d");
        }

        private ListView ListViewOLuştur()
        {
            flpDosyaListesi.Controls.Clear();

            ListView lstDosya = new ListView()
            {
                View = View.Details,
                GridLines = true,
                MultiSelect = false,
                FullRowSelect = true,
                Size = flpDosyaListesi.Size
            };

            lstDosya.Columns.Add("Ad",100);
            lstDosya.Columns.Add("Uzantı", 50);
            lstDosya.Columns.Add("Son Değiştitme Tarihi", 100);
            lstDosya.Columns.Add("Açıklama", 100);
            lstDosya.Columns.Add("Geçerlilk Tarihi", 100);
            lstDosya.Columns.Add("Boyut", 50);

            flpDosyaListesi.Controls.Add(lstDosya);

            lstDosya.DoubleClick += new System.EventHandler(List_DoubleClick);

            return lstDosya;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            ListView lst = (ListView)sender;
            if (lst.SelectedItems[0].SubItems[1].Text == DosyaTipleri.Klasör.ToString())
            {
                string klasörİsmi = lst.SelectedItems[0].SubItems[0].Text;

                DosyaListele(AnaKlasör.Klasörüm.KlasörBul(klasörİsmi));

                return;
            }
        }

        private void BtnAnaKlasöreGit_Click(object sender, EventArgs e)
        {
            if (_dosyaYolu == null)
            {
                MessageBox.Show("Lütfen önce klasör seçiniz.");
            }
            DosyaListele(AnaKlasör.Klasörüm);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            AnaKlasör.Klasörüm.DosyalarıKaydet();
            DosyaListele(AnaKlasör.Klasörüm);
        }

        private void BtnÇıkış_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUzantılaraGöreKlasörle_Click(object sender, EventArgs e)
        {
            AnaKlasör.Klasörüm.DosyalarıUzantılarınaGöreKlasöreTaşı();
            DosyaListele(AnaKlasör.Klasörüm);
        }

        private void BtnÇöpKutusunaTaşı_Click(object sender, EventArgs e)
        {
            AnaKlasör.Klasörüm.GeçerlilikSüresineGöreÇöpKutusunaAt();
            DosyaListele(AnaKlasör.Klasörüm);
        }

        private void BtnAçıklamaEkle_Click(object sender, EventArgs e)
        {
            foreach (ListView lst in flpDosyaListesi.Controls)
            {
                if (lst.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen önce dosya seçiniz");
                    return;
                }

                if (lst.SelectedItems[0].SubItems[1].Text == DosyaTipleri.Klasör.ToString())
                {
                    MessageBox.Show("Klasöre açıklama ekleyemezsiniz");
                    return;
                }

                DosyaAçıklamaEkle(lst);
                DosyaListele(AnaKlasör.Klasörüm);
                return;
            }
            MessageBox.Show("Lütfen önce klasör seçiniz");
        }

        private void DosyaAçıklamaEkle(ListView lst)
        {
            string dosyaİsmi = lst.SelectedItems[0].SubItems[0].Text;

            frmAçıklama frm = new frmAçıklama();

            frm.ShowDialog();

            AnaKlasör.Klasörüm.DosyaAçıklamaEkle(dosyaİsmi, frm._açıklama);

            frm.Close();
        }

        private void BtnGeçerlilikSüresiEkle_Click(object sender, EventArgs e)
        {
            foreach (ListView lst in flpDosyaListesi.Controls)
            {
                if (lst.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen önce dosya seçiniz");
                    return;
                }
                if (lst.SelectedItems[0].SubItems[1].Text == DosyaTipleri.Klasör.ToString())
                {
                    MessageBox.Show("Klasöre açıklama ekleyemezsiniz");
                    return;
                }
                DosyaGeçerlilikSüresiEkle(lst);
                DosyaListele(AnaKlasör.Klasörüm);
                return;
            }
            MessageBox.Show("Lütfen önce klasör seçiniz");
        }

        private void DosyaGeçerlilikSüresiEkle(ListView lst)
        {
            string dosyaİsmi = lst.SelectedItems[0].SubItems[0].Text;

            frmDateTime frm = new frmDateTime();

            frm.ShowDialog();

            AnaKlasör.Klasörüm.DosyaGeçerlilikSüresiEkle(dosyaİsmi, frm._time);

            frm.Close();
        }
    }
}
