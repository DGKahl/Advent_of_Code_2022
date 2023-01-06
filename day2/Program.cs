using System;
using System.IO;

public class Example
{
    public static void Main()
    {
        //variables
        List<string> input_data = new List<string>();      //input data
        int sum = 0;
        Dictionary<string, int> map = new Dictionary<string, int>();

        //getting the input data into a list
        using (var file = new StreamReader("C:\\Users\\Mr. Gutsy\\Desktop\\input2.txt"))
        {      
            string currentline;
            while ((currentline = file.ReadLine()) != null)
            {
                input_data.Add(currentline);
            }
        }

        //_______________________________________
        // --------------- Part 1 ---------------
        // //building dictionary to look up points of specific "hand"
        
        // map.Add("A X", 4);  
        // map.Add("A Y", 8);  
        // map.Add("A Z", 3);
        // map.Add("B X", 1);  
        // map.Add("B Y", 5);
        // map.Add("B Z", 9);
        // map.Add("C X", 7);
        // map.Add("C Y", 2);
        // map.Add("C Z", 6);

        //_______________________________________
        // --------------- Part 2 ---------------
        //adapt points in dicitionary according to what would lead to a win/draw/lose:

        map.Add("A X", 3);  
        map.Add("A Y", 4);  
        map.Add("A Z", 8);
        map.Add("B X", 1);  
        map.Add("B Y", 5);
        map.Add("B Z", 9);
        map.Add("C X", 2);
        map.Add("C Y", 6);
        map.Add("C Z", 7);




        //calculating points for input data
        foreach (string s in input_data)
        {
            sum += map[s];
        }

        Console.WriteLine(sum);
    }
}

