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
    public class KlasörDüzenleme : DüzenlemeRepo, IKlasörDüzenleme
    {
        private static KlasörDüzenleme _klasörDüzenleme;

        private KlasörDüzenleme()
        {

        }

        public static KlasörDüzenleme KlasörDüzenle
        {
            get
            {
                if (_klasörDüzenleme == null)
                {
                    _klasörDüzenleme = new KlasörDüzenleme();
                }
                return _klasörDüzenleme;
            }
        }

        /// <summary>
        /// Gönderilen klasör içindeki dosyaların geçerlilik süresini kontrol eder ve çöp kutusuna atar.
        /// </summary>
        /// <param name="dosyalar"></param>
        /// <param name="çöpKutusu"></param>
        /// 
        public void GeçerlilikSüresineGöreÇöpKutusunaAt(AnaKlasör anaKlasör)
        {
            ÇöpKutusuOluştur(anaKlasör);

            AnaKlasör.Klasörüm.KayıtVerisiOluştur();

            foreach (Dosya dosya in anaKlasör.KayıtVerisi)
            {
                if (GeçerlilikSüresiDolduMu(dosya))
                {
                    ÇöpKutusunaEkle(dosya);
                    dosya.Klasör._dosyalar.Remove(dosya);
                }
                KlasördenDosyaListesiAta(AnaKlasör.Klasörüm);
            }
        }

        /// <summary>
        /// Dosya listesindeki dosyaları uzantılarının bulunuğu klasöre ekler.
        /// </summary>
        /// <param name="dosyalar"></param>
        public void DosyalarıUzantılarınaGöreKlasöreTaşı(AnaKlasör anaKlasör)
        {
            UzantılaraGöreKlasörOluştur(anaKlasör);

            foreach (Dosya dosya in anaKlasör._dosyalar)
            {
                DosyayıKendiKlasörüneAt(dosya, anaKlasör);
            }
            KlasördenDosyaListesiAta(AnaKlasör.Klasörüm);
        }

        /// <summary>
        /// Gönderilen dizini işlem yapılacak ana klasör olarak oluşturur.
        /// </summary>
        /// <param name="dosyaYolu"></param>
        /// <returns></returns>
        public void DüzenlemeKlasörüAlma(string dosyaYolu)
        {
            AnaKlasör.KlasörOluştur(dosyaYolu);
            AnaKlasör.Klasörüm.Klasör = AnaKlasör.Klasörüm;
            KayıtKlasörüOluştur(AnaKlasör.Klasörüm);
            KlasördenDosyaListesiAta(AnaKlasör.Klasörüm);
            KlasördenKlasörListesiAta(AnaKlasör.Klasörüm);
        }

        /// <summary>
        /// Belirtilen klasör içindeki dosyaları kaydeder.
        /// </summary>
        /// <param name="anaKlasör"></param>
        public void DosyalarıKaydet(AnaKlasör anaKlasör)
        {
            AnaKlasör.Klasörüm.KayıtVerisiOluştur();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = JsonConvert.SerializeObject(anaKlasör.KayıtVerisi, Formatting.None, new JsonSerializerSettings()
            { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            FileStream fs = new FileStream(anaKlasör.kayıtYeri, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(json);
            sw.Close();
        }
    }
}
