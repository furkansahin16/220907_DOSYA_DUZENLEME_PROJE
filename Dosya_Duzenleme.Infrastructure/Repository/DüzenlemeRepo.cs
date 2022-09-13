using Dosya_Duzenleme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosya_Duzenleme.Infrastructure.Repository
{
    public class DüzenlemeRepo
    {
        /// <summary>
        /// Dosyayı uzantısının bulunduğu klasöre taşır.
        /// </summary>
        /// <param name="dosya"></param>
        /// <param name="anaKlasör"></param>
        protected void DosyayıKendiKlasörüneAt(Dosya dosya, AnaKlasör anaKlasör)
        {
            foreach (Klasör klasör in anaKlasör._klasörler)
            {
                if (dosya.DosyaUzantısı == klasör.İsim)
                {
                    string yeniDosyaYolu = Path.Combine(klasör.DosyaYolu, dosya.İsim);
                    File.Move(dosya.DosyaYolu, yeniDosyaYolu);
                    klasör._dosyalar.Add(dosya);
                    dosya.Klasör = klasör;
                    return;
                }
            }
        }

        /// <summary>
        /// Geçerlilik süresini kontrol eder
        /// </summary>
        /// <param name="dosya"></param>
        /// <returns></returns>
        protected bool GeçerlilikSüresiDolduMu(Dosya dosya)
        {
            return dosya.GeçerlilikSüresi >= DateTime.Now ? true : false;
        }

        /// <summary>
        /// Gönderilen dosyayı çöp kutusuna ekler
        /// </summary>
        /// <param name="dosya"></param>
        /// <param name="çöpKutusu"></param>
        protected void ÇöpKutusunaEkle(Dosya dosya)
        {
            dosya.Klasör._dosyalar.Remove(dosya);
            dosya.Klasör = AnaKlasör.Klasörüm.ÇöpKutusu;
            AnaKlasör.Klasörüm.ÇöpKutusu._dosyalar.Add(dosya);

            string hedef = Path.Combine(AnaKlasör.Klasörüm.ÇöpKutusu.DosyaYolu, dosya.İsim);
            File.Move(dosya.DosyaYolu, hedef);
        }

        /// <summary>
        /// Gönderilen dosya listesi için her dosyanın uzantılarını liste halinde getirir.
        /// </summary>
        /// <param name="dosyalar"></param>
        /// <returns></returns>
        protected List<string> DosyaUzantıListesiAl(List<Dosya> dosyalar)
        {
            List<string> uzantılar = new List<string>();

            foreach (Dosya dosya in dosyalar)
            {
                string uzantı = Path.GetExtension(dosya.DosyaYolu);

                if (!uzantılar.Contains(uzantı))
                {
                    uzantılar.Add(uzantı);
                }
            }

            return uzantılar;
        }

        /// <summary>
        /// Belirtilen klasör içinde hepsinin adıyla bir klasör oluşturur.
        /// </summary>
        /// <param name="uzantılar"></param>
        /// <param name="anaKlasör"></param>
        protected void UzantılaraGöreKlasörOluştur(Klasör anaKlasör)
        {
            List<string> uzantılar = DosyaUzantıListesiAl(anaKlasör._dosyalar);

            foreach (string item in uzantılar)
            {
                Klasör klasör = new Klasör(anaKlasör.DosyaYolu + @"\" + item)
                {
                    Klasör = anaKlasör,
                };

                anaKlasör._klasörler.Add(klasör);

                if (!Directory.Exists(klasör.DosyaYolu))
                {
                    Directory.CreateDirectory(klasör.DosyaYolu);
                }
            }

        }

        /// <summary>
        /// Parametre olarak gönderilen klasör içerisine Çöp Kutusu adında klasör oluşturur.
        /// </summary>
        /// <param name="anaKlasör"></param>
        /// <returns></returns>
        protected void ÇöpKutusuOluştur(AnaKlasör anaKlasör)
        {
            Klasör klasör = new Klasör(anaKlasör.DosyaYolu + @"\ÇöpKutusu")
            {
                Klasör = anaKlasör,
            };

            if (!Directory.Exists(klasör.DosyaYolu))
            {
                Directory.CreateDirectory(klasör.DosyaYolu);
                anaKlasör._klasörler.Add(klasör);

            }
            anaKlasör.ÇöpKutusu = klasör;
        }

        /// <summary>
        /// Gönderilen ana klasör içerisine kayıtları tutacak bir klasör oluşturur.
        /// </summary>
        /// <param name="anaKlasör"></param>
        protected void KayıtKlasörüOluştur(AnaKlasör anaKlasör)
        {
            string kayıtYolu = Path.Combine(anaKlasör.DosyaYolu + @"\.sv");

            Klasör kayıtKlasörü = new Klasör(kayıtYolu)
            {
                Klasör = anaKlasör,
            };

            if (!Directory.Exists(kayıtYolu))
            {
                Directory.CreateDirectory(kayıtYolu);
                anaKlasör._klasörler.Add(kayıtKlasörü);
            }

            anaKlasör.KayıtKlasörü = kayıtKlasörü;
        }

        /// <summary>
        /// Gönderilen bir klasörün içindeki klasörleri klasörün klasör listesine atar.
        /// </summary>
        /// <param name="klasör"></param>
        /// <returns></returns>
        protected void KlasördenKlasörListesiAta(Klasör klasör)
        {
            klasör._klasörler = new List<Klasör>();

            string[] klasörDizi = Directory.GetDirectories(klasör.DosyaYolu);

            foreach (string item in klasörDizi)
            {
                Klasör yeniKlasör = new Klasör(item);

                yeniKlasör.Klasör = klasör;

                klasör._klasörler.Add(yeniKlasör);

                KlasördenDosyaListesiAta(yeniKlasör);
                KlasördenKlasörListesiAta(yeniKlasör);
            }
        }

        /// <summary>
        /// Gönderilen bir klasörün içindeki dosyaları klasörün dosya listesine atar.
        /// </summary>
        /// <param name="klasör"></param>
        /// <returns></returns>
        protected void KlasördenDosyaListesiAta(Klasör klasör)
        {
            klasör._dosyalar = new List<Dosya>();

            string[] dosyalarDizi = Directory.GetFiles(klasör.DosyaYolu);

            foreach (string item in dosyalarDizi)
            {
                Dosya dosya = new Dosya(item);

                dosya.Klasör = klasör;

                klasör._dosyalar.Add(dosya);
            }
        }
    }
}
