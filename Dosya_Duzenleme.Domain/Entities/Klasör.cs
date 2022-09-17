using System;
using System.Collections.Generic;
using System.IO;
using Dosya_Duzenleme.Domain.Enum;

namespace Dosya_Duzenleme.Domain.Entities
{
    public class Klasör : BaseEntity
    {
        public List<Klasör> Klasörler { get; protected set; }

        private List<Klasör> KlasörListesiAta()
        {
            List<Klasör> klasörler = new List<Klasör>();

            string[] klasörDizi = Directory.GetDirectories(this.DosyaYolu);

            foreach (string item in klasörDizi)
            {
                Klasör yeniKlasör = new Klasör(item)
                {
                    Klasör = this
                };

                klasörler.Add(yeniKlasör);
            }
            return klasörler;
        }

        public List<Dosya> Dosyalar { get; protected set; }

        private List<Dosya> DosyaListesiAta()
        {
            List<Dosya> dosyalar = new List<Dosya>();

            string[] dosyaDizi = Directory.GetFiles(this.DosyaYolu);

            foreach (string item in dosyaDizi)
            {
                Dosya yeniDosya = new Dosya(item)
                {
                    Klasör = this
                };
                dosyalar.Add(yeniDosya);
            }
            return dosyalar;
        }

        public Klasör(string dosyaYolu) : base(dosyaYolu)
        {
            this.Dosyalar = DosyaListesiAta();
            this.Klasörler = KlasörListesiAta();
        }

        public override DosyaTipleri DosyaTipi { get { return DosyaTipleri.Klasör; } }
    }
}
