using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dosya_Duzenleme.Infrastructure.Repository;
using Dosya_Duzenleme.Domain.Entities;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            KlasörDüzenleme.KlasörDüzenle.DüzenlemeKlasörüAlma(@"C:\Users\Furkan\Desktop\Yeni klasör");
            KlasörDüzenleme.KlasörDüzenle.DosyalarıUzantılarınaGöreKlasöreTaşı(AnaKlasör.Klasörüm);
            KlasörDüzenleme.KlasörDüzenle.GeçerlilikSüresineGöreÇöpKutusunaAt(AnaKlasör.Klasörüm);
            KlasörDüzenleme.KlasörDüzenle.DosyalarıKaydet(AnaKlasör.Klasörüm);



            Console.ReadLine();
        }
    }
}
