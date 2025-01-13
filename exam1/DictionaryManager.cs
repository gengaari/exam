using System;
using System.Collections.Generic;
using System.IO;

namespace DictionariesApp
{
    public class DictionaryManager
    {
        private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        private string dictionaryFile = "dictionary.txt";

        public void CreateDictionary()
        {
            Console.WriteLine("Creating a new dictionary...");
            dictionary.Clear();
            SaveDictionary();
            Console.WriteLine("Dictionary created and saved.");
            Console.ReadLine();
        }

        public void AddWord()
        {
            Console.Write("Enter the word: ");
            string word = Console.ReadLine();

            Console.Write("Enter its translation: ");
            string translation = Console.ReadLine();

            if (!dictionary.ContainsKey(word))
            {
                dictionary[word] = new List<string>();
            }
            dictionary[word].Add(translation);
            SaveDictionary();
            Console.WriteLine("Word and translation added.");
            Console.ReadLine();
        }

        public void ReplaceWordOrTranslation()
        {
            Console.Write("Enter the word to replace: ");
            string word = Console.ReadLine();

            if (!dictionary.ContainsKey(word))
            {
                Console.WriteLine("Word not found.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter the new word or press Enter to skip: ");
            string newWord = Console.ReadLine();

            if (!string.IsNullOrEmpty(newWord))
            {
                dictionary[newWord] = dictionary[word];
                dictionary.Remove(word);
                word = newWord;
            }

            Console.Write("Enter the translation to replace: ");
            string translation = Console.ReadLine();

            if (dictionary[word].Contains(translation))
            {
                Console.Write("Enter the new translation: ");
                string newTranslation = Console.ReadLine();
                int index = dictionary[word].IndexOf(translation);
                dictionary[word][index] = newTranslation;
            }
            else
            {
                Console.WriteLine("Translation not found.");
            }

            SaveDictionary();
            Console.WriteLine("Replacement complete.");
            Console.ReadLine();
        }

        public void DeleteWordOrTranslation()
        {
            Console.Write("Enter the word to delete: ");
            string word = Console.ReadLine();

            if (dictionary.ContainsKey(word))
            {
                Console.WriteLine("Delete entire word or specific translation? (word/translation): ");
                string choice = Console.ReadLine();

                if (choice.ToLower() == "word")
                {
                    dictionary.Remove(word);
                }
                else if (choice.ToLower() == "translation")
                {
                    Console.Write("Enter the translation to delete: ");
                    string translation = Console.ReadLine();

                    if (dictionary[word].Contains(translation))
                    {
                        if (dictionary[word].Count > 1)
                        {
                            dictionary[word].Remove(translation);
                        }
                        else
                        {
                            Console.WriteLine("Cannot delete the last translation. Delete the word instead.");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Word not found.");
            }

            SaveDictionary();
            Console.WriteLine("Deletion complete.");
            Console.ReadLine();
        }

        public void FindTranslation()
        {
            Console.Write("Enter the word to find: ");
            string word = Console.
ReadLine();

if (dictionary.ContainsKey(word))
{
    Console.WriteLine("Translations: " + string.Join(", ", dictionary[word]));
}
else
{
    Console.WriteLine("Word not found.");
}
Console.ReadLine();
        }

        public void ExportWord()
{
    Console.Write("Enter the word to export: ");
    string word = Console.ReadLine();

    if (dictionary.ContainsKey(word))
    {
        string exportFile = word + "_translations.txt";
        File.WriteAllLines(exportFile, dictionary[word]);
        Console.WriteLine($"Word and translations exported to {exportFile}");
    }
    else
    {
        Console.WriteLine("Word not found.");
    }
    Console.ReadLine();
}

private void SaveDictionary()
{
    List<string> lines = new List<string>();
    foreach (var pair in dictionary)
    {
        lines.Add(pair.Key + ":" + string.Join(",", pair.Value));
    }
    File.WriteAllLines(dictionaryFile, lines);
}
    }
}