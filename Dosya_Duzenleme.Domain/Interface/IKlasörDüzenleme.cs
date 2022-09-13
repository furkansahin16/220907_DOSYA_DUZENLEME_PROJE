using Dosya_Duzenleme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosya_Duzenleme.Domain.Interface
{
    public interface IKlasörDüzenleme
    {
        void DüzenlemeKlasörüAlma(string dosyaYolu);

        void DosyalarıUzantılarınaGöreKlasöreTaşı(AnaKlasör anaKlasör);

        void GeçerlilikSüresineGöreÇöpKutusunaAt(AnaKlasör anaKlasör);

        void DosyalarıKaydet(AnaKlasör anaKlasör);

    }
}
