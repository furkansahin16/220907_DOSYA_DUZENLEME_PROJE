using Dosya_Duzenleme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosya_Duzenleme.Infrastructure.Repository
{
    internal static class DüzenlemeRepo
    {
        /// <summary>
        /// Dosyayı uzantısının bulunduğu klasöre taşır.
        /// </summary>
        /// <param name="dosya"></param>
        /// <param name="anaKlasör"></param>
        internal static void DosyayıKendiKlasörüneAt(Dosya dosya, Klasör klasör)
        {
            foreach (Klasör item in klasör.Klasörler)
            {
                if (dosya.DosyaUzantısı == item.İsim)
                {
                    string yeniDosyaYolu = Path.Combine(item.DosyaYolu, dosya.İsim);
                    File.Move(dosya.DosyaYolu, yeniDosyaYolu);
                    dosya.Klasör = item;
                    dosya.Klasör.Dosyalar.Add(dosya);
                    return;
                }
            }
        }

        /// <summary>
        /// Geçerlilik süresini kontrol eder
        /// </summary>
        /// <param name="dosya"></param>
        /// <returns></returns>
        internal static bool GeçerlilikSüresiDolduMu(Dosya dosya)
        {
            return dosya.GeçerlilikSüresi >= DateTime.Now ? true : false;
        }

        /// <summary>
        /// Gönderilen dosyayı çöp kutusuna ekler
        /// </summary>
        /// <param name="dosya"></param>
        /// <param name="çöpKutusu"></param>
        internal static void ÇöpKutusunaEkle(Dosya dosya)
        {
            dosya.Klasör.Dosyalar.Remove(dosya);
            dosya.Klasör = AnaKlasör.Klasörüm.ÇöpKutusu;
            AnaKlasör.Klasörüm.ÇöpKutusu.Dosyalar.Add(dosya);
            string hedef = Path.Combine(AnaKlasör.Klasörüm.ÇöpKutusu.DosyaYolu, dosya.İsim);
            File.Move(dosya.DosyaYolu, hedef);
        }

        /// <summary>
        /// Gönderilen dosya listesi için her dosyanın uzantılarını liste halinde getirir.
        /// </summary>
        /// <param name="dosyalar"></param>
        /// <returns></returns>
        internal static List<string> DosyaUzantıListesiAl(List<Dosya> dosyalar)
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
        internal static void UzantılaraGöreKlasörOluştur(Klasör klasör)
        {
            List<string> uzantılar = DosyaUzantıListesiAl(klasör.Dosyalar);

            foreach (string item in uzantılar)
            {
                string path = Path.Combine(klasör.DosyaYolu, item);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                Klasör yeniKlasör = new Klasör(path)
                {
                    Klasör = klasör,
                };

                klasör.Klasörler.Add(yeniKlasör);

                
            }

        }

        /// <summary>
        /// Parametre olarak gönderilen klasör içerisine Çöp Kutusu adında klasör oluşturur.
        /// </summary>
        /// <param name="anaKlasör"></param>
        /// <returns></returns>
        internal static void ÇöpKutusuOluştur(Klasör klasör)
        {
            string path = Path.Combine(klasör.DosyaYolu, "ÇöpKutusu");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

                Klasör çöpKutusu = new Klasör(path)
                {
                    Klasör = klasör,
                };

                klasör.Klasörler.Add(çöpKutusu);

                AnaKlasör.Klasörüm.ÇöpKutusu = çöpKutusu;
            }
        }

        /// <summary>
        /// Gönderilen ana klasör içerisine kayıtları tutacak bir klasör oluşturur.
        /// </summary>
        /// <param name="anaKlasör"></param>
        internal static void KayıtKlasörüOluştur(Klasör klasör)
        {
            string kayıtYolu = Path.Combine(klasör.DosyaYolu + @"\.sv");

            if (!Directory.Exists(kayıtYolu))
            {
                Directory.CreateDirectory(kayıtYolu);

                Klasör kayıtKlasörü = new Klasör(kayıtYolu)
                {
                    Klasör = klasör,
                };

                klasör.Klasörler.Add(kayıtKlasörü);

                AnaKlasör.Klasörüm.KayıtKlasörü = kayıtKlasörü;
            }
        }


    }
}
