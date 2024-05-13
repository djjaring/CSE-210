using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) {
        // more choices of scriptures
        var scriptures = new List<Scripture> {
            new Scripture("For God so loved the world that he gave his only Son, that whoever believes in him should not perish but have eternal life.", new ScriptureReference("John", 3, 16)),
            new Scripture("I can do all things through Christ who strengthens me.", new ScriptureReference("Philippians", 4, 13)),
            new Scripture("Trust in the LORD with all your heart and lean not on your own understanding.", new ScriptureReference("Proverbs", 3, 5)),
            new Scripture("O remember my son, and learn wisdom in thy youth yea, learn in thy youth to keep the commandments of God.",new ScriptureReference("Alma",37,35))
        };

        try {
            foreach (var scripture in scriptures) {
                MemorizeScripture(scripture);
                Console.WriteLine("\nDo you want to continue with more scriptures? Type 'yes' to continue or 'no' to quit.");
                if (Console.ReadLine().ToLower() != "yes") {
                    break;
                }
            }
            Console.WriteLine("\nMemorization session complete!");
        } catch (Exception ex) {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static void MemorizeScripture(Scripture scripture) {
        while (!scripture.AllWordsHidden()) {
            ClearConsoleSafely();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;
            scripture.HideWords();
        }
        Console.WriteLine("\nAll words are hidden for this scripture! Memorization complete for " + scripture.Reference);
    }

    static void ClearConsoleSafely() {
        try {
            if (!Console.IsOutputRedirected && !Console.IsInputRedirected && !Console.IsErrorRedirected) {
                Console.Clear();
            }
        } catch (System.IO.IOException) {
            Console.WriteLine("Unable to clear the console. Continuing without clearing.");
        }
    }
}

class Scripture {
    private List<Word> Words;
    public ScriptureReference Reference { get; }

    public Scripture(string text, ScriptureReference reference) {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideWords() {
        var rnd = new Random();
        int wordsToHide = 1 + rnd.Next(3); // Hide between 1 and 3 words at a time
        List<Word> visibleWords = Words.Where(w => !w.IsHidden).ToList();

        for (int i = 0; i < wordsToHide && visibleWords.Count > 0; i++) {
            int index = rnd.Next(visibleWords.Count);
            visibleWords[index].IsHidden = true;
            visibleWords.RemoveAt(index);
        }
    }

    public void Display() {
        Console.WriteLine(Reference);
        Console.WriteLine(string.Join(" ", Words.Select(w => w.IsHidden ? new string('_', w.Text.Length) : w.Text)));
    }

    public bool AllWordsHidden() {
        return Words.All(w => w.IsHidden);
    }
}

class ScriptureReference {
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; } // Nullable for single verse

    public ScriptureReference(string book, int chapter, int startVerse, int? endVerse = null) {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString() {
        return EndVerse == null ? $"{Book} {Chapter}:{StartVerse}" : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

class Word {
    public string Text { get; }
    public bool IsHidden { get; set; }

    public Word(string text) {
        Text = text;
    }
}
