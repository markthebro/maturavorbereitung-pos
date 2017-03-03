using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    public class Schueler
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public IList<Pruefung> Pruefungen { set; get; } = new List<Pruefung>();
        public override string ToString()
        {
            return String.Format("ID: {0}, Name: {1}", Id, Name);
        }
    }
}
