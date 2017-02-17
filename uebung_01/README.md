#1. �bung: Properties

Es soll eine Schule, die mehrere Klassen hat, verwaltet werden. Eine Klasse hat wiederum mehrere Sch�ler. Dabei gelten folgende Grundprinzipien:
1. Die Id eines Sch�lers ist eindeutig.
2. Eine Klasse kann nicht mehr als 5 Sch�ler haben (zum Testen ist dies einfacher, in der Realit�t sind dies 30 Sch�ler).
3. Ein Sch�ler kann nur in genau 1 Klasse sein.

##  Klassendiagramm
Das Klassendiagramm in UML sieht wie folgt aus:
![UML Klassendiagramm](https://github.com/markthebro/maturavorbereitung-pos/blob/master/uebung_01/SchulVwKlassendiagramm3.png)

Implementiere nun die Methoden und Properties so, dass sie den oben genannten Prinzipien entsprechen. Dabei soll das Property *Klasse* des Sch�lers auch beschreibbar sein. Allerdings darf durch das Setzen des Properties die Regel mit der Klassenh�chstzahl nicht verletzt werden.

## Hinweise zur Umsetzung
Lege eine neue Solution mit dem Namen *SchulVw* an. Gib die 3 modellierten Klassen in ein Modul mit dem Namespace *SchulVw.Model*. Zum Testen lege in dieser Solution zudem noch eine Konsolenapplikation *SchulVw.App* an.