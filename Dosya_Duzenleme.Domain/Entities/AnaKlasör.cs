using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace Dosya_Duzenleme.Domain.Entities
{
    public class AnaKlasör : Klasör
    {
        public string kayıtYeri
        {
            get { return Path.Combine(this.DosyaYolu, @".sv\.json");}
        }

        private static AnaKlasör _anaKlasör;

        private AnaKlasör(string dosyaYolu) : base(dosyaYolu)
        {
            KayıtOku();
        }

        ~AnaKlasör()
        {
            Kaydet();
        }

        /// <summary>
        /// Parametre olarak gönderilen dizindeki klasörü AnaKlasör olarak tanımlar.
        /// </summary>
        /// <param name="dosyaYolu"></param>
        /// <returns></returns>
        public static AnaKlasör KlasörOluştur(string dosyaYolu)
        {
            if (_anaKlasör == null)
            {
                _anaKlasör = new AnaKlasör(dosyaYolu);
            }

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
                {
                    throw new Exception("Önce 'KlasörOluştur' metoduyla ana klasör oluşturmanız gerekmektedir. Sonrasında bu özellikle klasöre erişebilirsiniz");
                }
                return _anaKlasör;
            }
        }

        public Klasör ÇöpKutusu { get; set; }

        public Klasör KayıtKlasörü { get; set; }

        public List<Dosya> KayıtVerisi = new List<Dosya>();

        /// <summary>
        /// Klasörün içindeki dosyaları kaydeder.
        /// </summary>
        public void Kaydet()
        {
            KayıtVerisiOluştur();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = JsonConvert.SerializeObject(this.KayıtVerisi, Formatting.None, new JsonSerializerSettings()
            { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            FileStream fs = new FileStream(this.kayıtYeri, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(json);
            sw.Close();
        }

        /// <summary>
        /// Klasör içinde bulunan tüm dosyalardan bir kayıt verisi oluşturur.
        /// </summary>
        public void KayıtVerisiOluştur()
        {
            AnaKlasör.Klasörüm.KayıtVerisi.Clear();

            foreach (Dosya dosya1 in this._dosyalar)
            {
                this.KayıtVerisi.Add(dosya1);
            }

            foreach (Klasör klasör in this._klasörler)
            {
                foreach (Dosya dosya2 in klasör._dosyalar)
                {
                    this.KayıtVerisi.Add(dosya2);
                }
            }
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
                this.KayıtVerisi = JsonConvert.DeserializeObject<List<Dosya>>(json);
                KayıtlarıYükle();
            }
        }

        /// <summary>
        /// Okunan verileri klasörün içine atar.
        /// </summary>
        private void KayıtlarıYükle()
        {
            foreach (var item in this.KayıtVerisi)
            {
                item.Klasör._dosyalar.Add(item);
            }
        }

        

        
        
    }
}
