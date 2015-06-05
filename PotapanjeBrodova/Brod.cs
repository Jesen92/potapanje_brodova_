using System.Text;
using System.Collections.Generic;

namespace PotapanjeBrodova
{
    public enum RezultatGađanja
    {
        Promašaj,
        Pogodak,
        Potopljen
    }

    public class Brod
    {
        public Brod(PoljeZaBrod[] polja)
        {
            m_polja = polja;
        }

        public RezultatGađanja GađajPolje(int redak, int stupac)
        {
            foreach (PoljeZaBrod p in m_polja)
            {
                if (p.Redak == redak && p.Stupac == stupac)
                {
                    m_pogođenaPolja.Add(p);
                    if (m_pogođenaPolja.Count == m_polja.Length)
                        return RezultatGađanja.Potopljen;
                    return RezultatGađanja.Pogodak;
                }
            }
            return RezultatGađanja.Promašaj;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var polje in m_polja)
                sb.AppendFormat("{0} ", polje);
            return sb.ToString();
        }

        PoljeZaBrod[] m_polja;
        HashSet<PoljeZaBrod> m_pogođenaPolja = new HashSet<PoljeZaBrod>();
    }
}
