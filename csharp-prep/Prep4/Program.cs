using System;

class Program
{
    static void Main(string[] args)
  {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Collect numbers from the user
        while (true)
        {
            Console.Write("Enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 0)
                break;
            numbers.Add(num);
        }

        // Compute the sum of the numbers
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine("The sum is: " + sum);

        // Compute the average of the numbers
        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;
        Console.WriteLine("The average is: " + average);

        // Find the maximum number in the list
        int max = int.MinValue;
        foreach (int number in numbers)
        {
            if (number > max)
                max = number;
        }
        Console.WriteLine("The largest number is: " + max);

          // Finding the smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
                smallestPositive = number;
        }
        if (smallestPositive == int.MaxValue)
            smallestPositive = -1; // or handle case when there's no positive number
        Console.WriteLine("The smallest positive number is: " + smallestPositive);

        // Sorting the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}