using System;
using System.IO;

public class Example
{
    public static void Main()
    {
        //variables
        List<string> input_data = new List<string>();      // input data
        int middle = 0;                                    // Mitte des strings
        int sum = 0;                                       // Summe für Ergebnisausgabe
        bool breaker = false;                              // check, ob Prüfung des aktuellen strings vorzeitig abgebrochen werden kann

        //getting the input data into a list
        using (var file = new StreamReader("C:\\Users\\Mr. Gutsy\\Desktop\\input3.txt"))
        {      
            string currentline;
            while ((currentline = file.ReadLine()) != null)
            {
                input_data.Add(currentline);
            }
        }


        // = = = PART 1 = = = = = = = = = = = = = = = = = = = = = = = = = = 
        /*TODO:
        1) Länge jeder Zeile ermitteln, durch 2 teilen --> "Mitte" gefunden
        2) Doppelte Schleife: Pro Zeile char von 0 bis "Mitte" - 1 durchlaufen und mit allen chars ab "Mitte" vergleichen (case sensitive!)
        4) Wenn Duplikat gefunden: Prio ermitteln und in laufende "Summen"-Variable addieren
        */

        // //gehe durch jede Zeile...
        // for (int i = 0; i < input_data.Count(); i++) {

        //     //"breaker" zurücksetzen...
        //     breaker = false;

        //     //ermittle die Länge und "Mitte"
        //     int l = input_data[i].Length;
        //     middle = (l/2);
            
        //     //jedes Element aus der erste Hälfte des strings...
        //     for (int x = 0; x < middle; x++) {

        //         //"breaker" prüfen: Wurde im aktuellen string schon ein Duplikat gefunden?
        //         if (breaker == false) {

        //             //mit jedem Element der zweiten Hälfte des string...
        //             for (int y = middle; y < input_data[i].Length; y++) {

        //                 //"breaker" prüfen: Wurde im aktuellen string schon ein Duplikat gefunden?
        //                 if (breaker == false) {

        //                     //vergleichen:
        //                     if (input_data[i][x] == input_data[i][y]) {

        //                         //wenn Treffer, als ASCII speichern...
        //                         int ascii = (int)(input_data[i][x]);

        //                         //wenn Treffer, prüfe ob ASCII < 97 (A-Z --> 65-90, a-z --> 97-122)
        //                         if (ascii < 97) {

        //                             //es ist ein Großbuchstabe --> -38 rechnen! Bsp.: A = "Prio" 27, d.h. 65-38 = 27, usw...)
        //                             ascii -= 38;

        //                         } else {

        //                             //es ist ein Kleinbuchstabe --> -96 rechnen! Bsp.: a = "Prio" 1, d.h. 97-96 = 1, usw...)
        //                             ascii -= 96;
        //                         }

        //                         //Summe um gefundene Prio erhöhen:
        //                         sum += ascii;

        //                         //"breaker" auf TRUE setzen; Prüfung des strings kann vorzeitig beendet werden...
        //                         breaker = true;
        //                     }
        //                 }
        //             }
        //         }
        //     }
        // }

        //= = = PART 2 = = = = = = = = = = = = = = = = = = = = = = = = = = 
        /*TODO:
        1) Zeile für Zeile aus Input vergleichen, immer in 3er-Gruppen
        2) Jedes Element aus 1 mit jedem aus 2
        3) Nur wenn gleich: Suche dieses Element in 3
        4) Wenn Treffer: Umrechnen in ASCII, auf Prio ummünzen, aufaddieren
        5) Sonst: Zurück in ursprüngliche Suche
        */

        for (int a = 0; a < input_data.Count; a+= 3) {                         //in 3er Schritten die Liste durchgehen...  
            foreach (char c in input_data[a]) {                                //jeden char im 1. Listenelement...
                foreach (char ch in input_data[a+1]) {                         //mit jedem char im 2. Listenelement...
                    if (c == ch) {             //vergleichen. Wenn gleich:
                       foreach (char cha in input_data[a+2]) {                 //mit jedem char aus dem 3. Listenelement...
                            if (c == cha) {       //vergleichen.

                                //wenn Treffer, als ASCII speichern...
                                int ascii = (int)(c);
                                //wenn Treffer, prüfe ob ASCII < 97 (A-Z --> 65-90, a-z --> 97-122)
                                if (ascii < 97) {
                                    //es ist ein Großbuchstabe --> -38 rechnen! Bsp.: A = "Prio" 27, d.h. 65-38 = 27, usw...)
                                    ascii -= 38;
                                } else {
                                    //es ist ein Kleinbuchstabe --> -96 rechnen! Bsp.: a = "Prio" 1, d.h. 97-96 = 1, usw...)
                                    ascii -= 96;
                                }
                                //Summe um gefundene Prio erhöhen:
                                sum += ascii;

                                //breaker setzen:
                                breaker = true;
                                break;
                            }
                        }
                        break;
                    }
                    if (breaker == true) {
                        break;    
                    }
                }
                if (breaker == true) {
                        break;    
                    }
            }
            breaker = false;
        }

        //get final result
        Console.WriteLine("Result: " + sum);
    }
}
