using System.Collections.Generic;
using System.IO;
using Dosya_Duzenleme.Domain.Enum;

namespace Dosya_Duzenleme.Domain.Entities
{
    public class Klasör : BaseEntity
    {
        public List<Klasör> _klasörler = new List<Klasör>();

        public List<Dosya> _dosyalar = new List<Dosya>();

        public Klasör(string dosyaYolu) : base(dosyaYolu)
        {
            base.SonDeğiştirmeTarihi = Directory.GetLastAccessTime(dosyaYolu);
        }

        public override DosyaTipleri DosyaTipi { get { return DosyaTipleri.Klasör; } }
    }
}
