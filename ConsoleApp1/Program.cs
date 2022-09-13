using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dosya_Duzenleme.Domain.Entities;
using Dosya_Duzenleme.Infrastructure.Repository;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:İndirilenler";

            AnaKlasörRepo repo = new AnaKlasörRepo();

            repo.İşlemYap(path);

            Console.ReadKey();
        }
    }
}
