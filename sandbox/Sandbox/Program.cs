using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        double grade = double.Parse(Console.ReadLine());
        string letter;
        string sign = "";

        // Determine the letter grade
        if (grade >= 90)
            letter = "A";
        else if (grade >= 80)
            letter = "B";
        else if (grade >= 70)
            letter = "C";
        else if (grade >= 60)
            letter = "D";
        else
            letter = "F";

        // Determine the sign
        int lastDigit = (int)grade % 10;
        if (lastDigit >= 7 && letter != "A" && letter != "F")
            sign = "+";
        else if (lastDigit < 3 && letter != "A" && letter != "F")
            sign = "-";

        Console.WriteLine("Your letter grade is: " + letter + sign);

        // Determine if the user passed
        if (grade >= 70)
            Console.WriteLine("Congratulations! You passed the course.");
        else
            Console.WriteLine("You did not pass the course. Better luck next time!");
    
        
        
        
        
        
    }
}