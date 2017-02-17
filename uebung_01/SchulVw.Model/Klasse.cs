using System.Collections.Generic;

namespace SchulVw.Model
{
    public class Klasse
    {
        public string Name { get; set; }
        public Schule Schule { get; set; }
        public List<Schueler> Schueler { get; } = new List<Schueler>();

        /// <summary>
        /// Suche nach einem Schüler in einer Klasse
        /// </summary>
        /// <param name="id">Id des Schülers</param>
        /// <returns>Gibt den Schüler als Obejekt zurück</returns>
        public Schueler FindSchuelerById(int id)
        {
            /*
                NICHT NACHMACHEN!!!!! NUR ZUM ZEIGEN!!!
                Würde sich die ganze DB holen (Bsp. 40 Millionen Datensätze) und dann durchiterieren...
                Kommentar Schletz: So gibs garantiert nur die Note >=4 ;-)
            */
            foreach (Schueler s in Schueler)
            {
                if(s.Id == id)
                {
                    return s;
                }
            }
            return null;
        }

        /// <summary>
        /// Fügt der Klasse einen neuen Schüler hinzu
        /// </summary>
        /// <param name="s">Schüler als fertiges Objekt</param>
        public void AddSchueler(Schueler s)
        {
            if(s != null)
            {
                Schueler.Add(s);

                //vgl. mit Diagramm --> NICHT VERGESSEN!!! --> Referenzen (Rückreferenz null, Schüler ohne Klasse)!!!
                s.Klasse = this; 
            }

            /*
                oder:
                if(s == null) { return; } //geht auch am Anfang vom Code, beispielsweise 3-4 Fehler prüfen und dann den logischen Code
            */
        }
    }
}