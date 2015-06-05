
using System;
namespace PotapanjeBrodova
{
    public class PoljeZaBrod
    {
        public PoljeZaBrod(int redak, int stupac)
        {
            Redak = redak;
            Stupac = stupac;
        }
        
        public readonly int Redak;
        public readonly int Stupac;

        // nadglasana metoda Equals koja omogućava usporedbe polja
        // (uveli smo ju zbog lakšeg testiranja)
        public override bool Equals(object obj)
        {
            PoljeZaBrod drugoPolje = obj as PoljeZaBrod;
            if (drugoPolje == null)
                return false;
            // pozvat će tipski sigurnu usporedbu
            return Equals(drugoPolje);
        }

        // moramo nadglasati jer smo nadlasali metodu Equals
        public override int GetHashCode()
        {
            return Redak ^ Stupac;
        }

        // tipski sigurna usporedba (argument je tipa PoljeZaBrod)
        public bool Equals(PoljeZaBrod drugoPolje)
        {
            if (System.Object.ReferenceEquals(drugoPolje, null))
                return false;
            return Redak == drugoPolje.Redak && Stupac == drugoPolje.Stupac;
        }

        // operatori == i != olakšavaju pisanje usporedbi
        public static bool operator ==(PoljeZaBrod lijevo, PoljeZaBrod desno)
        {
            // ako je lijevi null, tada vrati true samo ako je i desni null
            if (System.Object.ReferenceEquals(lijevo, null))
                return System.Object.ReferenceEquals(desno, null);
            return lijevo.Equals(desno);
        }

        public static bool operator !=(PoljeZaBrod lijevo, PoljeZaBrod desno)
        {
            return !(lijevo == desno);
        }

        // nadglasana metoda ToString koja omogućava ispis polja
        public override string ToString()
        {
            return string.Format("{0}-{1}", Convert.ToChar(Stupac + 'A'), Redak + 1);
        }
    }

    public class PočetnoPolje
    {
        public PočetnoPolje(PoljeZaBrod poljeZaBrod, Smjer smjer)
        {
            PoljeZaBrod = poljeZaBrod;
            Smjer = smjer;
        }

        public readonly PoljeZaBrod PoljeZaBrod;
        public readonly Smjer Smjer;

        public override bool Equals(object obj)
        {
            PočetnoPolje drugoPolje = obj as PočetnoPolje;
            if (drugoPolje == null)
                return false;
            // pozvat će tipski sigurnu usporedbu
            return Equals(drugoPolje);
        }

        // moramo nadglasati jer smo nadlasali metodu Equals
        public override int GetHashCode()
        {
            return PoljeZaBrod.GetHashCode() ^ Smjer.GetHashCode();
        }

        // tipski sigurna usporedba (argument je tipa PočetnoPolje)
        public bool Equals(PočetnoPolje drugoPolje)
        {
            if (System.Object.ReferenceEquals(drugoPolje, null))
                return false;
            return PoljeZaBrod == drugoPolje.PoljeZaBrod && Smjer == drugoPolje.Smjer;
        }

        // operatori == i != olakšavaju pisanje usporedbi
        public static bool operator ==(PočetnoPolje lijevo, PočetnoPolje desno)
        {
            // ako je lijevi null, tada vrati true samo ako je i desni null
            if (System.Object.ReferenceEquals(lijevo, null))
                return System.Object.ReferenceEquals(desno, null);
            return lijevo.Equals(desno);
        }

        public static bool operator !=(PočetnoPolje lijevo, PočetnoPolje desno)
        {
            return !(lijevo == desno);
        }

    }
}
