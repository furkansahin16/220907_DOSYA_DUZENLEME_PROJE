using Dosya_Duzenleme.Domain.Entities;
using Dosya_Duzenleme.Domain.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Dosya_Duzenleme.Infrastructure.Repository
{
    public class AnaKlasör : Klasör, IDosyaDüzenleme, IKlasörDüzenleme
    {
        private static AnaKlasör _anaKlasör;

        private AnaKlasör(string dosyaYolu) : base(dosyaYolu)
        {
            this.Klasör = this;
            MevcutÇöpKutusuVeKayıtKlasörüAta();
            KayıtOku();
        }

        ~AnaKlasör()
        {
            DosyalarıKaydet();
        }

        public string kayıtYeri { get { return Path.Combine(this.DosyaYolu, @".sv\.json"); } }

        public Klasör ÇöpKutusu { get; set; }

        public Klasör KayıtKlasörü { get; set; }

        public List<Dosya> KayıtVerisi { get { return KayıtVerisiOluştur(); } }

        /// <summary>
        /// Parametre olarak gönderilen dizindeki klasörü AnaKlasör olarak tanımlar.
        /// </summary>
        /// <param name="dosyaYolu"></param>
        /// <returns></returns>
        public static AnaKlasör KlasörOluştur(string dosyaYolu)
        {
            if (_anaKlasör == null)
                _anaKlasör = new AnaKlasör(dosyaYolu);
            return _anaKlasör;
        }

        /// <summary>
        /// Daha önce oluşturulmuş bir AnaKlasör nesnesini getirir. Daha önce oluşturulmadıysa KlasörOluştur metodunu kullanınız.
        /// </summary>
        public static AnaKlasör Klasörüm
        {
            get
            {
                if (_anaKlasör == null)
                    throw new Exception("Önce 'KlasörOluştur' metoduyla ana klasör oluşturmanız gerekmektedir. Sonrasında bu özellikle klasöre erişebilirsiniz");
                return _anaKlasör;
            }
        }

        /// <summary>
        /// Belirtilen dosya dizinindeki dosyaya bir açıklama ekler.
        /// </summary>
        /// <param name="dosyaYolu"></param>
        /// <param name="açıklama"></param>
        public void DosyaAçıklamaEkle(string dosyaİsmi, string açıklama)
        {
            DosyaBul(dosyaİsmi).DosyaAçıklaması = açıklama;
        }
        
        /// <summary>
        /// Belirtilen dosya yolundaki dosyaya geçerlilik süresi atar.
        /// </summary>
        /// <param name="dosyaYolu"></param>
        /// <param name="geçerlilikSüresi"></param>
        public void DosyaGeçerlilikSüresiEkle(string dosyaİsmi, DateTime geçerlilikSüresi)
        {
            DosyaBul(dosyaİsmi).GeçerlilikSüresi = geçerlilikSüresi;
        }

        /// <summary>
        /// Gönderilen klasör içindeki dosyaların geçerlilik süresini kontrol eder ve çöp kutusuna atar.
        /// </summary>
        /// <param name="dosyalar"></param>
        /// <param name="çöpKutusu"></param>
        /// 
        public void GeçerlilikSüresineGöreÇöpKutusunaAt()
        {
            DüzenlemeRepo.ÇöpKutusuOluştur(this);

            foreach (Dosya dosya in KayıtVerisi)
            {
                if (DüzenlemeRepo.GeçerlilikSüresiDolduMu(dosya))
                {
                    DüzenlemeRepo.ÇöpKutusunaEkle(dosya);
                    dosya.Klasör.Dosyalar.Remove(dosya);
                }
            }
        }

        /// <summary>
        /// Dosya listesindeki dosyaları uzantılarının bulunuğu klasöre ekler.
        /// </summary>
        /// <param name="dosyalar"></param>
        public void DosyalarıUzantılarınaGöreKlasöreTaşı()
        {
            DüzenlemeRepo.UzantılaraGöreKlasörOluştur(this);

            foreach (Dosya dosya in this.Dosyalar)
            {
                DüzenlemeRepo.DosyayıKendiKlasörüneAt(dosya, this);
            }
            this.Dosyalar.Clear();
        }

        /// <summary>
        /// Belirtilen klasör içindeki dosyaları kaydeder.
        /// </summary>
        /// <param name="anaKlasör"></param>
        public void DosyalarıKaydet()
        {
            DüzenlemeRepo.KayıtKlasörüOluştur(this);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = JsonConvert.SerializeObject(this.KayıtVerisi, Formatting.None, new JsonSerializerSettings()
            { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            FileStream fs = new FileStream(this.kayıtYeri, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(json);
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// Klasör içinde bulunan tüm dosyalardan bir kayıt verisi oluşturur.
        /// </summary>
        private List<Dosya> KayıtVerisiOluştur()
        {
            List<Dosya> dosyalar = new List<Dosya>();

            foreach (Dosya dosya1 in this.Dosyalar)
            {
                dosyalar.Add(dosya1);
            }

            foreach (Klasör klasör in this.Klasörler)
            {
                if (klasör.İsim != this.ÇöpKutusu.ToString() && klasör.İsim != this.KayıtKlasörü.ToString())
                    foreach (Dosya dosya2 in klasör.Dosyalar)
                    {
                        dosyalar.Add(dosya2);
                    }
            }
            return dosyalar;
        }

        /// <summary>
        /// Kayıt dizininden kayıtları okur.
        /// </summary>
        private void KayıtOku()
        {
            if (File.Exists(kayıtYeri))
            {
                StreamReader sr = new StreamReader(this.kayıtYeri);
                string json = sr.ReadToEnd();
                sr.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                List<Dosya> kayıtlar = new List<Dosya>();
                kayıtlar = JsonConvert.DeserializeObject<List<Dosya>>(json);
                KayıtlarıYükle(kayıtlar);
            }
        }

        /// <summary>
        /// Okunan verileri klasörün içine atar.
        /// </summary>
        private void KayıtlarıYükle(List<Dosya> kayıtlar)
        {
            foreach (Dosya dosya in kayıtlar)
            {
                DosyaBul(dosya.DosyaYolu).DosyaAçıklaması = dosya.DosyaAçıklaması;
                DosyaBul(dosya.DosyaYolu).GeçerlilikSüresi = dosya.GeçerlilikSüresi;
            }
        }

        /// <summary>
        /// Gönderilen dosya dizinindeki dosyayı blup getirir.
        /// </summary>
        /// <param name="dosyaYolu"></param>
        /// <returns></returns>
        private Dosya DosyaBul(string dosyaİsmi)
        {
            foreach (Dosya dosya1 in this.Dosyalar)
            {
                if (dosya1.İsim == dosyaİsmi)
                    return dosya1;
            }

            foreach (Klasör klasör in this.Klasörler)
            {
                foreach (Dosya dosya2 in klasör.Dosyalar)
                {
                    if (dosya2.İsim == dosyaİsmi)
                        return dosya2;
                }
            }

            throw new Exception("Dosya bulunamadı");
        }

        private void MevcutÇöpKutusuVeKayıtKlasörüAta()
        {
            foreach (Klasör klasör in this.Klasörler)
            {
                if (klasör.İsim == "ÇöpKutusu")
                    this.ÇöpKutusu = klasör;
                if (klasör.İsim == ".sv")
                    this.KayıtKlasörü = klasör;
            }
        }
    }
}
