using System;
using System.IO;

public class Example
{
    public static void Main()
    {
        //variables
         List<int> input_data = new List<int>();      //input data
         int temp_sum = 0;                            //sum of kcal for current elve
         
        //highest value of sum of kcal found so far
         int top1_sum = 0;                            
         int top2_sum = 0;
         int top3_sum = 0;

        //getting the input data into a list
        using (var file = new StreamReader("C:\\Users\\Mr. Gutsy\\Desktop\\input1.txt"))
        {      
            string currentline;
            while ((currentline = file.ReadLine()) != null)
            {
                if (currentline == "") {
                    input_data.Add(0);
                } else {
                    input_data.Add(Int32.Parse(currentline));
                }
            }
        }

        //go through list: Add entries until "0" is found --> is current sum bigger than the highest previously found sum?
        //YES: Remember current elve and save kcal as new highest cound
        //increment elve counter and reset sum

        //Part 2: Add 2 more trackers of 2nd and 3rd highest value.
        //for each new sum, check if it is higher than these 3 (starting at top value) and replace+shift down if needed.

        foreach (int i in input_data) {
            if (i > 0) {
                temp_sum += i;
            } else {
                if (temp_sum > top1_sum) {
                    top3_sum = top2_sum;
                    top2_sum = top1_sum;
                    top1_sum = temp_sum;
                } else if (temp_sum > top2_sum) {
                    top3_sum = top2_sum;
                    top2_sum = temp_sum;
                } else if (temp_sum > top3_sum) {
                    top3_sum = temp_sum;
                }
            temp_sum = 0;
            }
        }
        Console.WriteLine("Result: " + (top1_sum+top2_sum+top3_sum));
    }
}
