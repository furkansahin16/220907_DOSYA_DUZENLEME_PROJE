using Dosya_Duzenleme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosya_Duzenleme.Domain.Interface
{
    public interface IDosyaDüzenleme
    {
        void DosyaAçıklamaEkle(ref Dosya dosya, string açıklama);

        void DosyaGeçerlilikSüresiEkle(ref Dosya dosya, DateTime geçerlilikSüresi);

        bool AynıDosyaVarMı(List<Dosya> dosyalar, Dosya dosya);
    }
}
