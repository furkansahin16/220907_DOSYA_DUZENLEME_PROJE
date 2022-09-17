using System;
using Dosya_Duzenleme.Domain.Enum;
using System.IO;

namespace Dosya_Duzenleme.Domain.Entities
{
    public abstract class BaseEntity
    {

        private string _dosyaYolu;

        public string İsim { get; private set; }

        public string DosyaYolu
        {
            get { return _dosyaYolu; }
            set { İsimAta(value);
                _dosyaYolu = value;
            }
        }

        public DateTime SonDeğiştirmeTarihi
        {
            get
            {
                switch (this.DosyaTipi)
                {
                    case DosyaTipleri.Dosya: return File.GetLastAccessTime(this.DosyaYolu);
                    case DosyaTipleri.Klasör: return Directory.GetLastAccessTime(this.DosyaYolu);
                    default: break;
                }
                return DateTime.MinValue;
            }
        }

        public abstract DosyaTipleri DosyaTipi { get; }

        public Klasör Klasör { get; set; }

        public BaseEntity(string DosyaYolu)
        {
            this.DosyaYolu = DosyaYolu;
        }

        /// <summary>
        /// Dosya yolundan klasör veya dosyanın alacağı isme atama yapar
        /// </summary>
        /// <param name="value"></param>
        private void İsimAta(string value)
        {
            if (this.DosyaTipi == DosyaTipleri.Klasör)
            {
                FileInfo fi = new FileInfo(value);
                İsim = fi.Name;
                return;
            }
            DirectoryInfo di = new DirectoryInfo(value);
            İsim = di.Name;
        }

        public override string ToString()
        {
            return İsim;
        }
    }
}
