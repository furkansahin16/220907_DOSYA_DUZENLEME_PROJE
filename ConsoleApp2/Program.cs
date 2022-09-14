using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dosya_Duzenleme.Infrastructure.Repository;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            AnaKlasör.KlasörOluştur(@"C:\Users\Furkan\Desktop\Yeni klasör");
            
            AnaKlasör.Klasörüm.DosyalarıUzantılarınaGöreKlasöreTaşı();
            AnaKlasör.Klasörüm.GeçerlilikSüresineGöreÇöpKutusunaAt();

            AnaKlasör.Klasörüm.DosyaAçıklamaEkle(@"C:\Users\Furkan\Desktop\Yeni klasör\.jpeg\ferrari-sf71h-formula-one-f1-cars-2018-4k.jpeg", "Açıklama");

            AnaKlasör.Klasörüm.DosyalarıKaydet();


            Console.ReadLine();
        }
    }
}
