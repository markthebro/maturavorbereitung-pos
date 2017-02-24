using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchulVw.Model;

namespace SchulVw.Test
{
    [TestClass]
    public class UnitTest1
    {
        /*
            Testen: Build --> Rebuild Solution (F6)
            Test --> Windows --> Test Explorer
            Test zum ausführen nicht da? Rebuild? Annotation [TestMethod] vergessen?
            TestAddSchueler im TestTexplorer --> Analyze --> Model --> Klasse --> AddSchueler 
            --> Go to Source Code --> alles was rot ist, ist nicht getestet.
        */

        [TestMethod]
        public void TestAddSchueler()
        {
            Schule s = new Schule()
            {
                Skz = 905417,
                Name = "HTL Spengergasse"
            };

            s.AddKlasse(new Klasse() { Name = "5CHIF" });
            s.AddKlasse(new Klasse() { Name = "5BHIF" });
            Schueler sch = new Schueler { Id = 1, Nachname = "Mustermann", Vorname = "Max" };

            s.Klassen["5BHIF"].AddSchueler(sch);
            s.Klassen["5CHIF"].AddSchueler(sch);
            
            
            //Was passiert wenn das Schülerobjekt null ist
            Assert.AreEqual<bool>(false, s.Klassen["5CHIF"].AddSchueler(null));

            //Ist der Schüler wirklich in der 5CHIF?
            /*
            if (s.Klassen["5CHIF"].FindSchuelerById(1) == sch)
            {
                //TEST OK!!!
            }
            */

            //Das ist der obere if, was erwarte ich (1. Parameter) und was ist gespeichert worden (2. Parameter)
            //Prüfe ob die Zordnung der Klasse funktioniert hat?
            Assert.AreEqual<Schueler>(sch, s.Klassen["5CHIF"].FindSchuelerById(1));


            s.Klassen["5CHIF"].AddSchueler(new Schueler() { Id = 2, Vorname = "", Nachname = "" });
            s.Klassen["5CHIF"].AddSchueler(new Schueler() { Id = 3, Vorname = "", Nachname = "" });
            s.Klassen["5CHIF"].AddSchueler(new Schueler() { Id = 4, Vorname = "", Nachname = "" });
            s.Klassen["5CHIF"].AddSchueler(new Schueler() { Id = 5, Vorname = "", Nachname = "" });

            // Mehr als 5 Schüler sollten nicht klappen
            Assert.AreEqual<bool>(false, s.Klassen["5CHIF"].AddSchueler(
                new Schueler() { Id = 6, Vorname = "", Nachname = "" }
            ));
        }
    }
}
