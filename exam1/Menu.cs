using System;

namespace DictionariesApp
{
    public class Menu
    {
        private DictionaryManager dictionaryManager = new DictionaryManager();

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Create a new dictionary");
                Console.WriteLine("2. Add a word and its translation");
                Console.WriteLine("3. Replace a word or translation");
                Console.WriteLine("4. Delete a word or translation");
                Console.WriteLine("5. Find a translation");
                Console.WriteLine("6. Export a word and translations to a file");
                Console.WriteLine("7. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        dictionaryManager.CreateDictionary();
                        break;
                    case "2":
                        dictionaryManager.AddWord();
                        break;
                    case "3":
                        dictionaryManager.ReplaceWordOrTranslation();
                        break;
                    case "4":
                        dictionaryManager.DeleteWordOrTranslation();
                        break;
                    case "5":
                        dictionaryManager.FindTranslation();
                        break;
                    case "6":
                        dictionaryManager.ExportWord();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}