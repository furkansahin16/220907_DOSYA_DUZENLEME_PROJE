using Dosya_Duzenleme.Domain.Entities;
using Dosya_Duzenleme.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosya_Duzenleme.Infrastructure.Repository
{
    public class DosyaDüzenleme : DüzenlemeRepo, IDosyaDüzenleme
    {
        private static DosyaDüzenleme _dosyaDüzenleme;

        private DosyaDüzenleme()
        {

        }

        public static DosyaDüzenleme DosyaDüzenle
        {
            get
            {
                if (_dosyaDüzenleme == null)
                {
                    _dosyaDüzenleme = new DosyaDüzenleme();
                }
                return _dosyaDüzenleme;
            }
        }

        /// <summary>
        /// Gönderilen dosyanın, dosya listesinde olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="dosyalar"></param>
        /// <param name="dosya"></param>
        /// <returns></returns>
        public bool AynıDosyaVarMı(List<Dosya> dosyalar, Dosya dosya)
        {
            int sayaç = 0;
            foreach (Dosya item in dosyalar)
            {
                if (item.DosyaYolu == dosya.DosyaYolu && item.Boyut == dosya.Boyut)
                {
                    sayaç++;
                }
            }

            return sayaç > 1 ? true : false;
        }

        /// <summary>
        /// Referans olarak gönderilen dosyaya, gönderilen açıklamayı ekler.
        /// </summary>
        /// <param name="dosya"></param>
        /// <param name="açıklama"></param>
        public void DosyaAçıklamaEkle(ref Dosya dosya, string açıklama)
        {
            dosya.DosyaAçıklaması = açıklama;
        }

        /// <summary>
        /// Referans olarak gönderilen dosyaya bir geçerlilik süresi atar.
        /// </summary>
        /// <param name="dosya"></param>
        /// <param name="geçerlilikSüresi"></param>
        public void DosyaGeçerlilikSüresiEkle(ref Dosya dosya, DateTime geçerlilikSüresi)
        {
            dosya.GeçerlilikSüresi = geçerlilikSüresi;
        }
    }
}
