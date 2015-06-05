using System.Collections.Generic;
using System.Text;

namespace PotapanjeBrodova
{
    public class Flota
    {
        public void DodajBrod(PoljeZaBrod[] poljaZaBrod)
        {
            Brod brod = new Brod(poljaZaBrod);
            m_brodovi.Add(brod);
        }

        public RezultatGađanja GađajPolje(int redak, int stupac)
        {
            foreach (Brod b in m_brodovi)
            {
                var res = b.GađajPolje(redak, stupac);
                if (res != RezultatGađanja.Promašaj)
                    return res;
            }
            return RezultatGađanja.Promašaj;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var brod in m_brodovi)
                sb.AppendLine(brod.ToString());
            return sb.ToString();
        }

        List<Brod> m_brodovi = new List<Brod>();
    }
}
