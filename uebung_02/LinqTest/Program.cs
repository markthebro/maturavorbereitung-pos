using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Schueler> sl = new List<Schueler>();
            Schuelerliste mySl = new Schuelerliste();

            /*
            mySl.Add(new Schueler { Id = 1, Name = "xxx" });
            mySl.Add(new Schueler { Id = 2, Name = "xxx" });
            mySl.Add(new Schueler { Id = 3, Name = "xxx" });

            //Ruft eigenen FunctionDelegate auf
            Schuelerliste result = mySl.Where(s => s.Id == 3);

            //Schuelerliste result = mySl.Where(s => s.Id == 3 && s.Name = "xxx");

            //Das gleiche wie oben, zuerst suche ich nach der Id 3 UND DANN nach dem Namen, gibt aber eh nur "einen" zurück 
            //(vgl. .First() bzw. Id sollte j eindeutig sein)
            //Schuelerliste result = mySl.Where(s => s.Id == 3).Where(s => s.Name == "xxx");


            Brauche aber keine eigene .Where oder allgemein Filter Functions, gibt es schon: System.Linq
            */



            Schueler sch = new Schueler { Id = 1, Name = "Mustermann" };
            sch.Pruefungen.Add(new Pruefung { Gegenstand = "POS", Punkte = 12, Note = 5 });
            sch.Pruefungen.Add(new Pruefung { Gegenstand = "DBI", Punkte = 14, Note = 4 });
            sch.Pruefungen.Add(new Pruefung { Gegenstand = "D", Punkte = 16, Note = 3 });
            sl.Add(sch);
            sch = new Schueler { Id = 2, Name = "Musterfrau" };
            sch.Pruefungen.Add(new Pruefung { Gegenstand = "POS", Punkte = 14, Note = 4 });
            sch.Pruefungen.Add(new Pruefung { Gegenstand = "DBI", Punkte = 24, Note = 1 });
            sch.Pruefungen.Add(new Pruefung { Gegenstand = "E", Punkte = 20, Note = 2 });
            sl.Add(sch);


            // *************************************************************************************
            // Welche Prüfungen hat der Schüler mit der Id 1? Überlege dir dafür, ob die Where 
            // Klausel einen Schüler oder eine Liste von Schülern liefert.
            // *************************************************************************************

            //Am besten .FirstOrDefault nutzen damit das Exception Handling besser ist.
            Schueler s = sl.Where(s2 => s2.Id == 1).FirstOrDefault();
            var result1 = s.Pruefungen;

            //select Keyword ist die Projektion
            result1 = (from s2 in sl
                       where s2.Id == 1
                       select s2.Pruefungen).FirstOrDefault();

            result1 = sl.Where(s2 => s2.Id == 1).Select(s3 => s3.Pruefungen).FirstOrDefault();

            //Erst mit .ToList() wird das SQL Statement ausgeführt (vgl. mit einer DB)
            result1.ToList().ForEach(p => Console.WriteLine(p));
            // *************************************************************************************
            // Welchen Notendurchschnitt hat der Schüler mit der ID 2? Hinweis: Verwende Average
            // *************************************************************************************

            var pruefungen = (from s2 in sl
                              where s2.Id == 2
                              select s2.Pruefungen).FirstOrDefault();

            double avg = (from p in pruefungen
                          select p.Note).Average();

            double avg2 = (from s2 in sl
                           where s2.Id == 2
                           select s2.Pruefungen).FirstOrDefault().Average(p => p.Note);

            //Holt sich Schueler mit Id2, sagt im Ergebnis ich will gleich den mittelwert und dann eben nur einen schüler
            //FirstOrDefault
            //Hätte ich kein s2.Id == 2 UND kein .FirstOrDefault() hätte ich eine Liste von Mittelwerten
            double avg3 = (from s2 in sl
                           where s2.Id == 2
                           select s2.Pruefungen.Average(p => p.Note)).FirstOrDefault();

            double avg4 = sl
                .Where(s2 => s2.Id == 2)
                .Select(s3 => s3.Pruefungen
                    .Average(p => p.Note))
                .FirstOrDefault();

            Console.WriteLine("{ 0, 1, 2, 3}", avg, avg2, avg3, avg4);

            // *************************************************************************************
            // Welche Schüler hatten in D eine Prüfung? Hinweis: Verwende Any
            // *************************************************************************************

            IEnumerable<Schueler> result3 = (from s2 in sl
                           where s2.Pruefungen.Any(p => p.Gegenstand == "D")
                           select s2);

            //Fluid Syntax
            result3 = sl.Where(s2 => s2.Pruefungen.Any(p => p.Gegenstand == "D"));

            result3.ToList().ForEach(p => Console.WriteLine(p));

            // *************************************************************************************
            // Welche Schüler hatten schlechtere Noten als Befriedigend? Hinweis: Verwende Any
            // *************************************************************************************

            var result4 = from s2 in sl
                          where s2.Pruefungen.Any(p => p.Note > 3)
                          select s2;

            //Fluid Syntax
            result4 = sl.Where(s2 => s2.Pruefungen.Any(p => p.Note > 3));

            result4.ToList().ForEach(p => Console.WriteLine(p));

            // *************************************************************************************
            // Gibt es Schüler mit mehr als 3 Prüfungen? Verwende die Längeneigenschaft der Liste.
            // *************************************************************************************

            var result5 = from s2 in sl
                          where s2.Pruefungen.Count() > 3
                          select s2;

            //Fluid Syntax
            result5 = sl.Where(s2 => s2.Pruefungen.Count() > 3);

            result5.ToList().ForEach(p => Console.WriteLine(p));

            // *************************************************************************************
            // Liste alle Prüfungen auf, die mehr als 12 Punkte ergaben. Verwende dafür 2 mal
            // die from Klausel, indem du die Schülerliste mit den Prüfungen jedes
            // Schülers verknüpft. Unter http://stackoverflow.com/a/6429081 findest du ein Beispiel.
            // Sortiere sie nach der Anzahl der Punkte in absteigender Reihenfolge.
            // *************************************************************************************
            result6.ToList().ForEach(p => Console.WriteLine(p));

            // *************************************************************************************
            // Welches Punktemittel hatten alle POS Prüfungen? Ermittle diesen Wert mit Average,
            // wobei jedoch diese Funktion eine Lambda Expression mitgegeben werden muss. 
            // *************************************************************************************
            result7.ToList().ForEach(p => Console.WriteLine(p));
            
            Console.ReadKey();
        }
    }
}
