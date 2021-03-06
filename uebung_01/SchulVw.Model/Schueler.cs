﻿namespace SchulVw.Model
{
    public class Schueler
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        //readonly ==> hat nur einen get Zweig
        /* Mehrere Methoden:
        public string Langname { get; private set; }
        public string Langname { get; }
        public string Langname { get; } = "x"; (falls ich es initalisieren möchte, aber kein set habe (vgl. oben)

        public string Langname {
            get
            {
                return Nachname + " " + Vorname;
            }
        }

        */
        public string Langname
        {
            get
            {
                return Nachname + " " + Vorname;
            }
        }

        //private Klasse klasse;
        public Klasse Klasse
        {          get; set;
            /*get
            {
                return klasse;
            }
            set
            {
                //Wenn du von einer fremden Klasse kommst, füge den Schüler hinzu und setze die Klase
                if(value != klasse)
                {
                    value.AddSchueler(this);
                    klasse = value;
                }
            }*/
        }


    }
}