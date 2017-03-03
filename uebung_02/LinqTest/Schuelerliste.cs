using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    public class Schuelerliste
    {
        private IList<Schueler> liste = new List<Schueler>();

        public void Add(Schueler s)
        {
            liste.Add(s);
        }

        /*
            Veranschaulichung wie LINQ funktioniert.
        */
        public Schuelerliste Where(Func<Schueler, bool> filterFunction)
        {
            Schuelerliste result = new Schuelerliste();
            foreach(Schueler s in liste)
            {
                if(filterFunction(s) == true)
                {
                    result.Add(s);
                }
            }
            return result;
        }
    }
}
