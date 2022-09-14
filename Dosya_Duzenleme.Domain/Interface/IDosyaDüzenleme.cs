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
        void DosyaAçıklamaEkle(string dosyaYolu, string açıklama);

        void DosyaGeçerlilikSüresiEkle(string dosyaYolu, DateTime geçerlilikSüresi);
    }
}
