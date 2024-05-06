
public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToShortDateString();
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response)
    {
        entries.Add(new Entry(prompt, response));
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournal(string filename)
    {
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                file.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadJournal(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                entries.Add(new Entry(parts[1], parts[2]) { Date = parts[0] });
            }
        }
    }
}

class Program
{
    static List<string> prompts = new List<string> {
        "What was the best part of your day?",
        "What did you learn today?",
        "What made you smile today?",
        "Write about a person who made your day better.",
        "what is your personal study today?",
        "what is the blessings you receive today?"

    };

    static void Main()
    {
        Journal journal = new Journal();
        bool running = true;
        while (running)
        {
            Console.WriteLine("Journal Application\n1. Add Entry\n2. Display Journal\n3. Save Journal\n4. Load Journal\n5. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Choose a prompt or enter your own:");
                    int promptIndex = 1;
                    foreach (var prompt in prompts)
                    {
                        Console.WriteLine($"{promptIndex}. {prompt}");
                        promptIndex++;
                    }
                    Console.WriteLine($"{promptIndex}. Enter your own prompt.");

                    string promptChoice = Console.ReadLine();
                    string selectedPrompt;
                    if (int.TryParse(promptChoice, out int index) && index == promptIndex)
                    {
                        Console.Write("Enter your custom prompt: ");
                        selectedPrompt = Console.ReadLine();
                    }
                    else if (int.TryParse(promptChoice, out index) && index > 0 && index <= prompts.Count)
                    {
                        selectedPrompt = prompts[index - 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, using default prompt.");
                        selectedPrompt = prompts[0];
                    }

                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(selectedPrompt, response);
                    break;

                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string filename = Console.ReadLine();
                    journal.SaveJournal(filename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string fileToLoad = Console.ReadLine();
                    journal.LoadJournal(fileToLoad);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
