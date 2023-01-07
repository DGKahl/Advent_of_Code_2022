using System;
using System.IO;

public class Example
{
    public static void Main()
    {
        //variables
        List<string> input_data = new List<string>();      // input data

        //getting the input data into a list
        using (var file = new StreamReader("C:\\Users\\Mr. Gutsy\\Desktop\\input4.txt"))
        {      
            string currentline;
            while ((currentline = file.ReadLine()) != null)
            {
                input_data.Add(currentline);
            }
        }
    }
}

//Idee für Teil 1: 
//Je Zeile alle "-" mit "," ersetzen, dann je Zeile die vier kommagetrennten Ganzzahlen vergleichen.
//1. mit 3. Zahl (Untergrenzen) und 2. mit 4. Zahl (Obergrenze)
//Wenn 1.>3. und 2.<4.: erster Teil komplett im 2. Teil. Wenn 3.<1. und 4.<2.: 2. Teil komplett im 1. Teil.