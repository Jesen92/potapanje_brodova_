using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public enum StanjePolja
    {
        Netaknuto,
        Promašeno,
        Pogođeno,
        Potopljeno
    }

    public class PoljeZaEvidenciju : PoljeZaBrod
    {
        public PoljeZaEvidenciju(int redak, int stupac) : base(redak, stupac)
        {
            StanjePolja = StanjePolja.Netaknuto;
        }

        public void PromijeniStanje(StanjePolja novoStanje)
        {
            StanjePolja = novoStanje;
        }

        public StanjePolja StanjePolja { get; private set; }
    }
}
