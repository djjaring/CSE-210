using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // ask the user name for there name.
        Console.Write ("what is your First name?");
        string first= Console.ReadLine();
        Console.Write("What is your last name?");
        string last = Console.ReadLine();
        Console.WriteLine($"Your last name is {last},{first} {last}");




    }

}