using SchulVw.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulVw.App
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Model muss als Reference eingebunden werden --> References --> Add Reference --> Project --> SchulVw.Model
                Model.Schule s = new Schule(); --> ebenfalls möglich
                Lämpchen --> using [...] nutzen.
                
                keine Konstrukturen in C# (in Datenhaltendenklassen, bei DB Verbindungen beispielsweise schon) bzw. so gut wie es geht
                vermeiden
                INITIALIZER Objekt obj = new Objekt() { Property = value, Property2 = value, .... }
            */
            Schule s = new Schule()
            {
                Skz = 905417,
                Name = "HTL Spengergasse"
            };

            //Gefahr beim direkten Anlegen über new, Referenz verschwinden!
            s.AddKlasse(new Klasse() { Name = "5CHIF" });
            s.AddKlasse(new Klasse() { Name = "5BHIF" });

            /*  
                Schüler wird erstellt und in die 5CHIF geschmissen.
                [..] ==> Indexer. Greife über einen Key auf einen Wert zu. (Array Index, 0,1,2,3,....)
                F12 ==> Go to Definition
            */
            Schueler sch = new Schueler { Id = 1, Nachname = "Mustermann", Vorname = "Max" };
            s.Klassen["5CHIF"].AddSchueler(sch);

            //Umstellen auf bool der void Methoden AddSchueler und AddKlasse ==> returned true/false "Exception"-freundlicher
            //Geht nicht, weil die Id doppelt ist ==> 1
            s.Klassen["5BHIF"].AddSchueler(new Schueler
            {
                Id = 1,
                Vorname = "Max2",
                Nachname = "Mustermann2"
            });


            //Wirft Exeception (Navigation Property)
            //s.FindSchuelerById(1).Klasse = s.Klassen["5BHIF"];
            //s.Klassen["5BHIF"].AddSchueler(sch);

            /*
                Vgl. Klasse.cs ==> Codezeile public List<Schueler> Schueler { get; } = new List<Schueler>();
                bzw.
                Codezeile.cs Codezeile: public Dictionary<string, Klasse> Klassen { get; } = new Dictionary<string, Klasse>();


                Person p = new Person() { Name = "A" };
                Person p2 = p;
                p2.Name = "A2";
                Was liefert p.Name? --> Antwort: A2

                List<Person> pl = new List<Person>() { p };
                p.Name = "A3";
                Was liefert p.Name? --> Antwort: A3
            */

        }
    }
}
