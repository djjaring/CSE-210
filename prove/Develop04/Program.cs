using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    abstract class MindfulnessActivity
    {
        protected string Name { get; set; }
        protected string Description { get; set; }

        public MindfulnessActivity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Start(int duration)
        {
            DisplayStartingMessage(duration);
            Thread.Sleep(2000);
            PerformActivity(duration);
            DisplayEndingMessage(duration);
        }

        protected void DisplayStartingMessage(int duration)
        {
            Console.WriteLine($"Starting {Name} Activity");
            Console.WriteLine(Description);
            Console.WriteLine($"Duration: {duration} seconds");
            Console.WriteLine("Prepare to begin...");
            Thread.Sleep(2000);
        }

        protected void DisplayEndingMessage(int duration)
        {
            Console.WriteLine("Good job!");
            Console.WriteLine($"You have completed the {Name} activity for {duration} seconds.");
            Thread.Sleep(2000);
        }

        protected abstract void PerformActivity(int duration);
        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }

    class BreathingActivity : MindfulnessActivity 
    {
        public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void PerformActivity(int duration)
        {
            int interval = 5; 
            int elapsedTime = 0;

            while (elapsedTime < duration)
            {
                Console.WriteLine("Breathe in...");
                Countdown(interval);
                elapsedTime += interval;

                if (elapsedTime >= duration)
                    break;

                Console.WriteLine("Breathe out...");
                Countdown(interval);
                elapsedTime += interval;
            }
        }
    }

    class ReflectionActivity : MindfulnessActivity
    {
        private List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else. Closed your eyes and think.",
            "Think of a time when you did something really difficult. Closed your eyes and think.",
            "Think of a time when you helped someone in need. Closed your eyes and think.",
            "Think of a time when you did something truly selfless. Closed your eyes and think."
        };

        private List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
        }

        protected override void PerformActivity(int duration)
        {
            Random rand = new Random();
            string selectedPrompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine(selectedPrompt);
            int elapsedTime = 0;
            int interval = 15;  

            while (elapsedTime < duration)
            {
                string question = questions[rand.Next(questions.Count)];
                Console.WriteLine(question);
                Countdown(interval);
                elapsedTime += interval;
            }
        }
    }

    class ListingActivity : MindfulnessActivity
    {
        private List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        protected override void PerformActivity(int duration)
        {
            Random rand = new Random();
            string selectedPrompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine(selectedPrompt);
            int elapsedTime = 0;
            int interval = 10; 

            while (elapsedTime < duration)
            {
                Console.WriteLine("List an item:");
                string item = Console.ReadLine();
                Countdown(interval);
                elapsedTime += interval;
            }
        }
    }



    class GratitudeActivity : MindfulnessActivity // Aditional Activities Gratitutes
    {
        private List<string> prompts = new List<string>
        {
            "What are three things you are grateful for today?",
            "Who is someone you are thankful for and why?",
            "What is an experience this week that you appreciate?",
            "What is an aspect of your environment (home, nature, etc.) that you're grateful for?",
            "What ability or skill are you most grateful for?"
        };

        public GratitudeActivity() : base("Gratitude", "This activity will help you focus on the aspects of your life that you are grateful for. It aims to enhance your overall appreciation and happiness.")
        {
        }

        protected override void PerformActivity(int duration)
        {
            Random rand = new Random();
            string selectedPrompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine(selectedPrompt);
            int elapsedTime = 0;
            int interval = 10; 

            while (elapsedTime < duration)
            {
                Console.WriteLine("Express your gratitude:");
                string gratitudePoint = Console.ReadLine();
                Countdown(interval);
                elapsedTime += interval;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Mindfulness Program!");
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Gratitude Activity");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                if (choice == "5")
                {
                    break;
                }

                Console.Write("Enter the duration in seconds: ");
                int duration;
                if (!int.TryParse(Console.ReadLine(), out duration))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                MindfulnessActivity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        activity = new GratitudeActivity();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        continue;
                }

                if (activity != null)
                {
                    activity.Start(duration);
                }
            }
        }
    }
}
