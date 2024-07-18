﻿namespace KalorienManager_WeightwatcherApp
{
    internal class Program
    {


        //________________________LISTEN GLOBAL DEFINIEREN________________________
        class TagesListe
        {
            public string Menge { get; set; }
            public string Gericht { get; set; }
            public double Kcal { get; set; }
        }
        static List<TagesListe> tagesListe = new List<TagesListe>();


        class VorlagenListe
        {
            public string VorlageEinheit { get; set; }
            public string GerichtVorlage { get; set; }
            public double KcalVorlage { get; set; }
        }
        static List<VorlagenListe> vorlagenListe = new List<VorlagenListe>();


        class GesamtverlaufListe
        {
            public string DatumGV { get; set; }
            public double KcalGV { get; set; }
        }
        static List<GesamtverlaufListe> gesamtverlaufListe = new List<GesamtverlaufListe>();


        class KalenderWochenListe
        {
            public string Jahr { get; set; }
            public string KW { get; set; }
            public double Gewicht { get; set; }
        }
        static List<KalenderWochenListe> kalenderWochenListe = new List<KalenderWochenListe>();


        class TagesLimitListe
        {
            public double Tageslimit { get; set; }
        }
        static List<TagesLimitListe> tagesLimitListe = new List<TagesLimitListe>();
        //***********************LISTEN GLOBAL DEFINIEREN ENDE***********************



        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tWillkommen bei KalorienManager App\n");
                Console.WriteLine("\t(T)AGESVERLAUF\n");
                Console.WriteLine("\t(V)ORLAGENSEITE\n");
                Console.WriteLine("\t(G)ESAMTVERLAUF\n");
                Console.WriteLine("\t(K)ALENDERWOCHEN\n");
                Console.WriteLine("\tT(U)TORIAL\n\t");
                string auswahl = Console.ReadLine().ToLower().Trim();

                switch (auswahl)
                {
                    case "t":
                        TagesVerlauf();
                        break;
                    case "v":
                        Vorlagenseite();
                        break;
                    case "g":
                        GesamtVerlauf();
                        break;
                    case "k":
                        KalenderWochen();
                        break;
                    case "u":
                        TutorialSeite();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tUNGÜLTIGE AUSWAHL");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Thread.Sleep(400);
                        break;
                }
            }
        }



        //________________________TAGESVERLAUF________________________
        static void TagesVerlauf()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t-----TAGESVERLAUF-----\n");
                double summeKcal = 0;
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (TagesListe item in tagesListe)
                {
                    Console.WriteLine($"\t {item.Menge}\t{item.Gericht}\t{item.Kcal} Kcal");
                    summeKcal += item.Kcal;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t--------------------------");
                Console.WriteLine($"\tGesamtsumme der Kcal: {summeKcal}");
                if (tagesLimitListe.Count > 0)
                {
                    double tageslimit = tagesLimitListe[0].Tageslimit;
                    double rest = tageslimit - summeKcal;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\tRESTLICHE KCAL HEUTE: {rest}\n\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.WriteLine("\n\n\tBITTE NOCH TAGESLIMIT ANGEBEN!\n");
                }


                Console.WriteLine("\t(N)EUER EINTRAG");
                Console.WriteLine("\t(L)ETZTEN EINTRAG LÖSCHEN");
                Console.WriteLine("\t(V)ORLAGENSEITE\n");
                Console.WriteLine("\t(Z)URÜCK");
                Console.WriteLine("\tL(I)MIT FESTLEGEN");
                Console.WriteLine("\t(D)UMMYS IMPORTIEREN\n\t");

                string auswahl = Console.ReadLine().ToLower().Trim();

                switch (auswahl)
                {
                    case "n":
                        NeuerEintragTagesverlauf();
                        break;
                    case "l":
                        EntferneLetztenEintragTagesverlauf();
                        break;
                    case "v":
                        Vorlagenseite();
                        break;
                    case "z":
                        return;
                    case "i":
                        LimitFestlegen();
                        break;
                    case "d":
                        DummysTagesliste();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tUNGÜLTIGE AUSWAHL");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Thread.Sleep(400);
                        break;
                }
            }
        }
        static void NeuerEintragTagesverlauf()
        {
            TagesListe item = new TagesListe();
            Console.Write("\tMENGE EINGEBEN\n\t");
            item.Menge = Console.ReadLine();
            Console.Write("\tGERICHT EINGEBEN\n\t");
            item.Gericht = Console.ReadLine();
            Console.Write("\tKCAL EINGEBEN\n\t");
            item.Kcal = Convert.ToDouble(Console.ReadLine());
            tagesListe.Add(item);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tDANKE");
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(500);
        }
        static void EntferneLetztenEintragTagesverlauf()
        {
            if (tagesListe.Count > 0)
            {
                tagesListe.RemoveAt(tagesListe.Count - 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\tWIRD GELÖSCHT");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\tDIE LISTE LEER");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Thread.Sleep(500);
        }
        static void DummysTagesliste()
        {
            tagesListe.Add(new TagesListe { Menge = "1x       ", Gericht = "Kaffee mit 2 Zucker", Kcal = 35 });
            tagesListe.Add(new TagesListe { Menge = "97g      ", Gericht = "Brezel             ", Kcal = 310 });
            tagesListe.Add(new TagesListe { Menge = "1x       ", Gericht = "Landjäger          ", Kcal = 184 });
            tagesListe.Add(new TagesListe { Menge = "1x       ", Gericht = "Rewe Cappucino     ", Kcal = 142 });
            tagesListe.Add(new TagesListe { Menge = "1 Portion", Gericht = "Spaghetti Bolognese", Kcal = 900 });
            tagesListe.Add(new TagesListe { Menge = "1x       ", Gericht = "Gemischter Salat   ", Kcal = 250 });
            tagesListe.Add(new TagesListe { Menge = "1 Stk    ", Gericht = "Marmorkuchen       ", Kcal = 400 });
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tDUMMYS HINZUGEFÜGT");
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(500);
        }

        //***********************TAGESVERLAUF ENDE***********************




        //________________________VORLAGENSEITE________________________
        static void Vorlagenseite()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t-----Vorlagenseite-----\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (VorlagenListe item in vorlagenListe)
                {
                    Console.WriteLine($" \t {item.VorlageEinheit}\t\t {item.GerichtVorlage}\t\t{item.KcalVorlage}");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t(N)EUER EINTRAG");
                Console.WriteLine("\t(L)ETZTEN EINTRAG LÖSCHEN");
                Console.WriteLine("\t(Z)URÜCK");
                Console.WriteLine("\t(D)UMMYS IMPORTIEREN\n\t");

                string auswahl = Console.ReadLine().ToLower().Trim();

                switch (auswahl)
                {
                    case "n":
                        NeuerEintragVorlagenseite();
                        break;
                    case "l":
                        EntferneLetztenEintragVorlagenSeite();
                        break;
                    case "z":
                        return;
                    case "d":
                        DummysVorlagenSeite();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tUNGÜLTIGE AUSWAHL");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Thread.Sleep(400);
                        break;
                }
            }
        }

        static void NeuerEintragVorlagenseite()
        {
            VorlagenListe item = new VorlagenListe();
            Console.Write("\tPRO 100G? PRO Portion ODER PRO STÜCK?\n\t");
            item.VorlageEinheit = Console.ReadLine();
            Console.Write("\tGERICHT EINGEBEN\n\t");
            item.GerichtVorlage = Console.ReadLine();
            Console.Write("\tKCAL EINGEBEN\n\t");
            item.KcalVorlage = Convert.ToDouble(Console.ReadLine());
            vorlagenListe.Add(item);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tDANKE");
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(500);
        }

        static void EntferneLetztenEintragVorlagenSeite()
        {
            if (vorlagenListe.Count > 0)
            {
                vorlagenListe.RemoveAt(vorlagenListe.Count - 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\tWIRD GELÖSCHT");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\tDIE LISTE IST SCHON LEER");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Thread.Sleep(500);
        }

        static void DummysVorlagenSeite()
        {
            vorlagenListe.Add(new VorlagenListe { VorlageEinheit = "1x       ", GerichtVorlage = "Pizza Aldi                 ", KcalVorlage = 1023 });
            vorlagenListe.Add(new VorlagenListe { VorlageEinheit = "1 Portion", GerichtVorlage = "Zucchini Auflauf           ", KcalVorlage = 973 });
            vorlagenListe.Add(new VorlagenListe { VorlageEinheit = "100g     ", GerichtVorlage = "Fleischküchle selbstgemacht", KcalVorlage = 209 });
            vorlagenListe.Add(new VorlagenListe { VorlageEinheit = "100g     ", GerichtVorlage = "Tomaten-Thunfisch Salat    ", KcalVorlage = 70 });
            vorlagenListe.Add(new VorlagenListe { VorlageEinheit = "1x       ", GerichtVorlage = "Big King XXL Burger King   ", KcalVorlage = 973 });
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tDUMMYS HINZUGEFÜGT");
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(500);
        }
        //***********************VORLAGENSEITE ENDE***********************




        //________________________GESAMTVERLAUFSEITE________________________

        static void GesamtVerlauf()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t-----GESAMTVERLAUF-----\n");
                foreach (GesamtverlaufListe item in gesamtverlaufListe)
                {
                    Console.WriteLine($" \t {item.DatumGV}\t{item.KcalGV}");
                }
                Console.WriteLine("\n\t(N)EUER EINTRAG");
                Console.WriteLine("\t(L)ETZTEN EINTRAG LÖSCHEN");
                Console.WriteLine("\t(Z)URÜCK");
                Console.WriteLine("\t(D)UMMYS IMPORTIEREN");

                string auswahl = Console.ReadLine().ToLower().Trim();

                switch (auswahl)
                {
                    case "n":
                        NeuerEintragGesamtverlauf();
                        break;
                    case "l":
                        EntferneLetztenEintragGesamtverlauf();
                        break;
                    case "z":
                        return;
                    case "d":
                        DummysGesamtverlauf();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tUNGÜLTIGE AUSWAHL");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Thread.Sleep(400);
                        break;
                }
            }
        }

        static void NeuerEintragGesamtverlauf()
        {
            GesamtverlaufListe item = new GesamtverlaufListe();
            Console.Write("\tDATUM? YYYY.MM.DD\n\t");
            item.DatumGV = Console.ReadLine();
            Console.Write("\tGESAMT-KCAL DES TAGESEINGEBEN\n\t");
            item.KcalGV = Convert.ToDouble(Console.ReadLine());
            gesamtverlaufListe.Add(item);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tDANKE");
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(500);
        }

        static void EntferneLetztenEintragGesamtverlauf()
        {
            if (gesamtverlaufListe.Count > 0)
            {
                gesamtverlaufListe.RemoveAt(gesamtverlaufListe.Count - 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\tWIRD GELÖSCHT");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\tDIE LISTE IST SCHON LEER");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Thread.Sleep(500);
        }

        static void DummysGesamtverlauf()
        {
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_06_21", KcalGV = 3300 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_06_22", KcalGV = 3100 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_06_23", KcalGV = 3500 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_06_24", KcalGV = 2300 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_06_25", KcalGV = 3500 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_06_26", KcalGV = 3300 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_06_27", KcalGV = 2200 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_06_28", KcalGV = 3500 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_06_29", KcalGV = 4500 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_06_30", KcalGV = 4000 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_07_01", KcalGV = 2400 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_07_02", KcalGV = 2000 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_07_03", KcalGV = 3300 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_07_04", KcalGV = 2000 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_07_05", KcalGV = 2400 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_07_06", KcalGV = 3700 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_07_07", KcalGV = 4500 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_07_08", KcalGV = 2200 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_07_09", KcalGV = 2500 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_07_10", KcalGV = 2700 });
            gesamtverlaufListe.Add(new GesamtverlaufListe { DatumGV = "2024_07_11", KcalGV = 4500 });
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tDUMMYS HINZUGEFÜGT");
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(500);
        }

        //***********************GESAMTVERLAUFSEITE ENDE***********************


        //________________________KALENDERWOCHENSEITE________________________
        static void KalenderWochen()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t-----KALENDERWOCHEN MIT GEWICHT-----\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (KalenderWochenListe item in kalenderWochenListe)
                {
                    Console.WriteLine($"\t{item.Jahr}\t{item.KW}\t{item.Gewicht}KG");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t(N)EUER EINTRAG");
                //Console.WriteLine("\t(L)ETZTEN EINTRAG LÖSCHEN");
                Console.WriteLine("\t(Z)URÜCK");
                Console.WriteLine("\t(D)UMMYS IMPORTIEREN");

                string auswahl = Console.ReadLine().ToLower().Trim();

                switch (auswahl)
                {
                    case "n":
                        NeuerEintragKalenderwochen();
                        break;
                    //case "l":
                    //    LetztenEintragLöschen();
                    //    break;
                    case "z":
                        return;
                    case "d":
                        DummysKalenderWochen();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tUNGÜLTIGE AUSWAHL");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Thread.Sleep(400);
                        break;
                }
            }
        }
        static void NeuerEintragKalenderwochen()
        {
            KalenderWochenListe item = new KalenderWochenListe();
            Console.Write("\tJAHR EINGEBEN\n\t");
            item.Jahr = Console.ReadLine();
            Console.Write("\t\tKALENDERWOCHE EINGEBEN\n\t");
            item.KW = Console.ReadLine();
            Console.Write("GEWICHT EINGEBEN\n\t");
            item.Gewicht = Convert.ToDouble(Console.ReadLine());
            kalenderWochenListe.Add(item);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tDANKE");
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(500);
        }

        static void DummysKalenderWochen()
        {
            kalenderWochenListe.Add(new KalenderWochenListe { Jahr = "2024", KW = "KW24", Gewicht = 118 });
            kalenderWochenListe.Add(new KalenderWochenListe { Jahr = "2024", KW = "KW25", Gewicht = 116 });
            kalenderWochenListe.Add(new KalenderWochenListe { Jahr = "2024", KW = "KW26", Gewicht = 114 });
            kalenderWochenListe.Add(new KalenderWochenListe { Jahr = "2024", KW = "KW27", Gewicht = 114 });
            kalenderWochenListe.Add(new KalenderWochenListe { Jahr = "2024", KW = "KW28", Gewicht = 113 });
            kalenderWochenListe.Add(new KalenderWochenListe { Jahr = "2024", KW = "KW29", Gewicht = 114 });
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tDUMMYS HINZUGEFÜGT");
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(500);
        }
        //***********************KALENDERWOCHENSEITE ENDE***********************


        //________________________TUTORIALSEITE________________________
        static void TutorialSeite()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t(Z)URÜCK");
                Console.WriteLine("\n\t-----TUTORIALSEITE-----\n");
                Console.WriteLine("Willkommen zur WeightWatchers App - Dein Kalorien Manager zum Abnehmen!");
                Console.WriteLine("");
                Console.WriteLine("Du willst Gewicht verlieren? Dann ist diese App genau das Richtige für dich! \nMit dem Kalorien Manager kannst du dein Ziel erreichen, indem du deine Ernährung genau im Blick behältst und Schritt für Schritt abnimmst. Folge den Anweisungen und du wirst erfolgreich sein.");
                Console.WriteLine("");
                Console.WriteLine("So funktioniert's:");
                Console.WriteLine("1. Kalorienaufnahme verstehen \nUm Gewicht zu verlieren, musst du weniger Kalorien zu dir nehmen, als du verbrauchst. Dies nennt man ein Kaloriendefizit.");
                Console.WriteLine("");
                Console.WriteLine("2. Essen abwiegen und protokollieren \nAuf allen Lebensmitteln stehen hinten drauf die enthaltenen Kcal pro 100g. Wiege dein Essen ab und multipliziere mit den angegebenen Kcal/100g. Trage die Kalorien in die App ein. So behältst du den Überblick und stellst sicher, dass du unter deinem Kalorienlimit bleibst.");
                Console.WriteLine("");
                Console.WriteLine("3. Zwei Wochen normal essen \nIss zwei Wochen lang ganz normal wie immer und trage alle deine Mahlzeiten in die App ein. So ermittelst du die Kalorien die dein Körper täglich verbraucht");
                Console.WriteLine("");
                Console.WriteLine("4. Kalorienziel festlegen \nNachdem du deinen täglichen Kalorienverbrauch ermittelt hast, ziehe 500 kcal davon ab. Das ist dein tägliches Kalorienziel, um effektiv abzunehmen.");
                Console.WriteLine("");
                Console.WriteLine("Hintergrundwissen: \n 1 kg menschliches Körperfett enthält 7000 kcal \nUm 1 kg Körperfett zu verlieren, musst du insgesamt 7000 kcal einsparen. Mit einem täglichen Defizit von 500 kcal hast du das in 2 Wochen erreicht");
                Console.WriteLine("");
                Console.WriteLine("Tipps für den Erfolg: \n Bewegung integrieren \nUnterstütze deinen Abnehmprozess mit regelmäßiger Bewegung. Das erhöht deinen Kalorienverbrauch und verbessert dein Wohlbefinden.");
                Console.WriteLine("");
                Console.WriteLine("Mit der KalorienManager/WeightWatcher App hast du ein mächtiges Werkzeug an deiner Seite, das dir hilft, deine Ziele zu erreichen. Starte noch heute und mach den ersten Schritt zu einem gesünderen und glücklicheren Leben!");
                Console.WriteLine("");
                Console.WriteLine("\t(Z)URÜCK");

                string auswahl = Console.ReadLine().ToLower().Trim();

                switch (auswahl)
                {
                    case "z":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tUNGÜLTIGE AUSWAHL");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Thread.Sleep(400);
                        break;
                }
            }
        }
        //***********************TUTORIALSEITE ENDE***********************


        //_______________________LIMIT FESTLEGEN SEITE________________________
        static void LimitFestlegen()
        {
            TagesLimitListe item = new TagesLimitListe();
            Console.Write("\tTAGESLIMIT EINGEBEN\n\t");
            item.Tageslimit = Convert.ToDouble(Console.ReadLine());
            tagesLimitListe.Add(item);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tDANKE");
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(500);
        }
        //***********************LIMIT FESTLEGEN ENDE***********************
    }
}
