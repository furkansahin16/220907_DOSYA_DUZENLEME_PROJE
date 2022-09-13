using System;
using System.IO;
using Dosya_Duzenleme.Domain.Enum;

namespace Dosya_Duzenleme.Domain.Entities
{
    public class Dosya : BaseEntity
    {
        public Dosya(string dosyaYolu) : base(dosyaYolu)
        {
            base.SonDeğiştirmeTarihi = File.GetLastAccessTime(dosyaYolu);
        }

        public string DosyaAçıklaması { get; set; }

        public DateTime GeçerlilikSüresi { get; set; }

        private string _dosyaUzantısı;

        public long Boyut
        {
            get
            {
                return this.DosyaYolu.Length;
            }
        }

        public string DosyaUzantısı
        {
            get
            {
                _dosyaUzantısı = Path.GetExtension(this.DosyaYolu);
                return _dosyaUzantısı;
            }
        }

        public override DosyaTipleri DosyaTipi { get { return DosyaTipleri.Dosya; } }

    }
}
