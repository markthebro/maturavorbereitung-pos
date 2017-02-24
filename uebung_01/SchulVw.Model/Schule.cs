using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulVw.Model
{
    public class Schule
    {
        public int Skz { get; set; }
        public string Name { get; set; }

        /* 
            Alte Schreibweise (< C# 3.0), nicht zu empfehlen, in dieser Art und Weise --> sehr fehlerfreudig, Groß- und Kleinschreibung
            private string name;
            public string Name {
                get 
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }
        */

        /*
            Für Matura relevant: Dictionary und List, nicht ArrayList nutzen
            Dict sucht indem nach Key sortiert und dann wird Binär gesucht, List sucht 5CHIF "anders" und gibt sie zurück
            ==> sortierte Liste ist schneller abrufbar bzw. returned schneller

            C# 5 Initialisierung eines Default Properties
            string, Dictionary müssen intsanziert werden (Referentyp); int ist ein primitiver Datentyp, reserviert sich immer 4 Bytes
        */
        public Dictionary<string, Klasse> Klassen { get; } = new Dictionary<string, Klasse>();
        
        /// <summary>
        /// Sucht nach einem Schüler in der Schule
        /// </summary>
        /// <param name="id">Id des Schülers</param>
        /// <returns>Gibt ein ganzes Objekt vom Typ Schüler zurück</returns>
        public Schueler FindSchuelerById(int id)
        {
            /*
                NICHT NACHMACHEN!!!!! NUR ZUM ZEIGEN!!!
                Würde sich die ganze DB holen (Bsp. 40 Millionen Datensätze) und dann durchiterieren...
                Kommentar Schletz: So gibs garantiert nur die Note >=4 ;-)

                foreach(Klasse k in Klassen.Values)
                {
                    foreach(Schueler s in k.Schueler)
                    {
                        if(s.Id == id)
                        {
                            return s;
                        }
                    }
                }

                foreach(Klasse k in Klassen.Values)
                {
                    Schueler found = k.FindSchuelerById(id);
                    if(found != null)
                    {
                        return found;
                    }
                }
            */

            //"Aktuelle" Lösung (Stand mit Ende der Stunde) --> nächste Woche weiter
            foreach (Klasse k in Klassen.Values)
            {
                Schueler found = k.FindSchuelerById(id);
                if(found != null)
                {
                    return found;
                }
            }

            /*
                Schöne Lösung, produktivbetriebs-Lösung --> evtl. statt var den richtigen Datentyp angeben.
                var res = (from k in Klassen.Values
                           from s in k.Schueler
                           where s.Id == id
                           select s).FirstOrDefault();
            */
            return null;
        }

        /*/// <summary>
        /// Erstellt eine neue Klasse in der Schule
        /// </summary>
        /// <param name="k">Klasse als fertiges Objekt</param>
        public void AddKlasse(Klasse k)
        {
            //vgl. mit Codezeile  public void AddSchueler(Schueler s) in Klasse.cs für weitere Fehlerüberprüfungen
            if (k != null)
            {
                try
                {
                    Klassen.Add(k.Name, k);
                    k.Schule = this;
                } catch { }

                //vgl. mit Diagramm --> NICHT VERGESSEN!!! --> Referenzen (Rückreferenz null, Klasse ohne Schule)!!!
                

                //Debugging only (zum Testen für etwas)!! --> bzw. mit F10 kann ich Schritt für Schritt weiter gehen.
                //k.Name = "4CHIF"; 
            }
        }*/

        public bool AddKlasse(Klasse k)
        {
            if (k != null)
            {
                try
                {
                    Klassen.Add(k.Name, k);
                    k.Schule = this;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
