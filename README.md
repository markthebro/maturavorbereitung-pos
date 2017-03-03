# Maturavorbereitung POS 5CHIF (2016/2017)
## Unterrichtende Lehrer
* Michael Schletz aka SZ (Freitags von 09:55 Uhr - 11:35 Uhr)
* Robert Stefan aka STE (Freitags von 08:00 Uhr - 08:50 Uhr)

## Hinweis
Zurzeit sind viele Kommentare in den Klassen welche rein zur Orientierung bzw. zum Lernen dienen. Diese werden im Laufe der Zeit entfernt um einerseits eine bessere Codeübersicht zu haben und andererseits sollte der Lerneffekt dadurch besser werden. Sollten die Kommentare immer noch gebraucht werden müssen o.ä. siehe einfach den Verlauf der Commits.

## Übung 01 - ER-Diagramm mit STE am 17. Februar 2017
Erstellen eines ER-Diagramms. Eine Firma möchte ein Fahrtenbuch einführen. Dieses soll außerdem ermöglichen Autos für einen bestimmten Mitarbeiter an einem gewissen Tag zu reservieren.
Vgl. `Fahrtenbuch.dia / Fahrtenbuch.png`

## Übung 01 - Properties mit SZ am 17. Februar 2017
Erstellen eines Konsolenprogrammes mit Hilfe einer Class Library um den Einstieg in die Properties darzustellen bzw. zu erleichtern (Auffrischen der C# Grundlagen). Zusätzlich die ersten Versuche bzw. Vergleiche zwischen einer foreach "Abfrage" und einer (professionellen) LINQ-Abfrage.
Vergleiche Codezeile `public Schueler FindSchuelerById(int id)` in `SchulVw.Model/Klasse.cs`
Original Repo: [schletz/fachtheorie_1617/uebung1](https://github.com/schletz/fachtheorie_1617/tree/master/uebung1)

## Übung 01.1 - Relationales Modell mit STE am 24. Februar 2017
Umsetzen des ERM in ein relationales Modell; konzipiert für einen MSSQL Server.
Tipp: mit `ALT` und `MARKIEREN` kann ich einen ganzen Block markieren und beim lostippen schreibe ich in diesem Block das selbe.

## Übung 01.1 - Properties mit SZ am 24. Februar 2017
Weitere Einführung und Erklärung in die Properties sowie Erklärung wie Navigation Properties funktionieren, wie mit Fehlerbehandlung umgegangen wird sowie erstellen der ersten Unit Tests.
Original Repo: [schletz/fachtheorie_1617/uebung1](https://github.com/schletz/fachtheorie_1617/tree/master/uebung1)

## Übung 02 - Erstellen des EDMX (ADO.NET Entity Data Model) mit STE am 03. März 2017
Erzeugen eines neues Visual Studios Projekts. SQL Code ausführen (`View` --> `SQL Server Object Explorer` --> `Add Server` --> `(localdb)\MSSQLLocalDB` --> `Databases` --> `Right Cliack` --> `Add Database` --> `FahrtenbuchDB` --> `New Query` --> `Run Fahrtenbuch.sql`) <br />
Erstellen einer neuer Class Library, in dieser eine EDMX Datei erstellen (`Add` --> `New Item` --> `Data` --> `ADO.NET Entity Data Model` --> `FahrtenbuchEntities` --> ``EF desinger from Database` --> `New Connection` --> `Microsoft SQL Server` --> `(localdb)\MSSQLServer` --> `FahrtenbuchDB` --> `dbo/Tables/*.*` --> `Pluralize` --> `Save in App.Config`) 
Danach bei `Solution` --> `Add new Item` --> `Test` --> `Unit Test Project` --> `FahrtenbuchTest` --> `Reference` --> `Projects/Solution/FahrtenbuchDB` 
Zusätzlich als Reference über `Manage NuGet Packages` das `EntityFramework v.6.1.3` installieren. 
Nicht vergessen LINQ einzubinden `.Count()` --> `using System.Linq` einbinden. 
Über `Test` --> `Run` --> `All Tests` können die Tests aufgerufen werden. Resultat --> `Failed` 
In `FahrtenbuchTest` in der `App.Config` den `ConnectionString` von der Class Library aus der `App.Config` reinladen. 
Ein erneuter Test führt zum gewünschten Ergebnis.

### Hinweis
Das ist nicht die schönste Methode, nur zum Herzeigen, wie erstelle ich die grundlegnden Klassen und Solutions. Wir schließen die DB nie...
