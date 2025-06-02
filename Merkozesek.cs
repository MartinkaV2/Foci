using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foci
{
    internal class Merkozesek
    {
        public int datum;
        public string ellenfel;
        public string helyszin;
        public int sajatgol;
        public int ellenfelgol;
        public string nyerteke;

        public Merkozesek(string datum, string ellenfel, string helyszin, string sajatgol, string ellenfelgol, string nyerteke)
        {
            this.datum = int.Parse(datum);
            this.ellenfel = ellenfel;
            this.helyszin = helyszin;
            this.sajatgol = int.Parse(sajatgol);
            this.ellenfelgol = int.Parse(ellenfelgol);
            this.nyerteke = nyerteke;
        }
    }
}
