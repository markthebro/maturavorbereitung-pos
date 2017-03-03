using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    public class Pruefung
    {
        public string Gegenstand { set; get; }
        public int Punkte { set; get; }
        public int Note { set; get; }
        public override string ToString()
        {
            return String.Format("{0}: {1} ({2} Punkte)", Gegenstand, Note, Punkte);
        }
    }
}
