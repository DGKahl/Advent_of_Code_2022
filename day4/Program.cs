using System;
using System.IO;

public class Example
{
    public static void Main()
    {
        //variables
        List<string> input_data = new List<string>();      // input data
        int counter = 0;                                   // found cases (solution)

        //getting the input data into a list
        using (var file = new StreamReader("C:\\Users\\Mr. Gutsy\\Desktop\\input4.txt"))
        {      
            string currentline;
            while ((currentline = file.ReadLine()) != null)
            {
                input_data.Add(currentline);
            }
        }

        //Getting single values for ranges into two seperate arrays
        foreach (string s in input_data) {
            string[] pairs = new string[2];
            string[] first = new string[2];
            string[] second = new string[2];

            //Split string into array at ',' (seperating the two ranges)
            pairs = s.Split(',');
            
            //Split both ranges again to get start and end of each range
            first = pairs[0].Split('-');
            second = pairs[1].Split('-');

            //Determine larger and smaller range and write each element of each range into corresponding lists
            List<int> larger = new List<int>();
            List<int> smaller = new List<int>();

            //second range is larger than first one:
            if (Int32.Parse(first[1])-Int32.Parse(first[0])+1 < Int32.Parse(second[1])-Int32.Parse(second[0])+1) {
                for (int i=0; i < Int32.Parse(second[1])-Int32.Parse(second[0])+1;i++) {
                    larger.Add(Int32.Parse(second[0])+i);
                }
                for (int i=0; i < Int32.Parse(first[1])-Int32.Parse(first[0])+1;i++) {
                    smaller.Add(Int32.Parse(first[0])+i);
                } 
            } else {
            //first range is larger than second one:
            for (int i=0; i < Int32.Parse(first[1])-Int32.Parse(first[0])+1;i++) {
                    larger.Add(Int32.Parse(first[0])+i);
                }
                for (int i=0; i < Int32.Parse(second[1])-Int32.Parse(second[0])+1;i++) {
                    smaller.Add(Int32.Parse(second[0])+i);
                } 
            }

            //check for each element in shorter range if it is already contained in longer range
            bool check = false;
            foreach (int i in smaller) {
                //if (!larger.Contains(i)) { //Solution for PART 1: Check, if any value in shorter range is not contained in longer range.
                if (larger.Contains(i)) {    //Solution for PART 2: Check, if any value in shorter range is already in longer range (= overlap).
                    check = true;
                    break;
                }
            }

            // //PART 1: if "check" == false --> smaller range is completely contained in larger range:
            // if (check == false) {
            //     counter +=1;
            // }

            //PART 2: if "check" == true --> overlap has been found in current line:
            if (check == true) {
                counter +=1;
            }

        }
        Console.WriteLine(counter);
    }
}

//Idee für Teil 1: 
//Je Zeile alle "-" mit "," ersetzen, dann je Zeile die vier kommagetrennten Ganzzahlen vergleichen.
//1. mit 3. Zahl (Untergrenzen) und 2. mit 4. Zahl (Obergrenze)
//Wenn 1.>3. und 2.<4.: erster Teil komplett im 2. Teil. Wenn 3.<1. und 4.<2.: 2. Teil komplett im 1. Teil.