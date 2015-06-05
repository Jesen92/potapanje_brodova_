using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Sucelje
{

   public enum smjer
    {
        up, 
        down, 
        left, 
        right
    };

   public class moji_brodovi
    {
        public string pocetno_polje;
        public List<string> sva_polja = new List<string>();
        public int dulj;
        public smjer smj;
    }
}
