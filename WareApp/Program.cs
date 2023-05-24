using System;

namespace WareApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w programie!");
            Console.WriteLine("Program pozwoli Ci zapisać informacje o produkcie w pliku.");
            Console.WriteLine();

            var wareInFile = new WareInFile("", "");
            var wareInMemory = new WareInMemory("", "");

            while (true)
            {
                Console.WriteLine("Podaj nazwę produktu lub naciśnij 'Q' lub 'q' aby wyświetlić statystyki:");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    Console.WriteLine();
                    Console.WriteLine("Statystyki dla kategorii 'clothes':");
                    var statisticsClothes = wareInFile.GetStatistics();
                    Console.WriteLine($"AVR: {statisticsClothes.Avr}");
                    Console.WriteLine($"Count: {statisticsClothes.Count}");
                    Console.WriteLine($"Max: {statisticsClothes.Max}");

                    Console.WriteLine();
                    Console.WriteLine("Statystyki dla kategorii 'shoes':");
                    var statisticsShoes = wareInMemory.GetStatistics();
                    Console.WriteLine($"AVR: {statisticsShoes.Avr}");
                    Console.WriteLine($"Count: {statisticsShoes.Count}");
                    Console.WriteLine($"Max: {statisticsShoes.Max}");

                    Console.WriteLine();
                    Console.WriteLine("Statystyki dla kategorii 'others':");
                    var statisticsOthers = wareInMemory.GetStatistics();
                    Console.WriteLine($"AVR: {statisticsOthers.Avr}");
                    Console.WriteLine($"Count: {statisticsOthers.Count}");
                    Console.WriteLine($"Max: {statisticsOthers.Max}");
                    break;
                }

                string name = input;

                Console.WriteLine("Wybierz kategorię:");
                Console.WriteLine("1 - clothes");
                Console.WriteLine("2 - shoes");
                Console.WriteLine("3 - others");
                Console.Write("Wybierz numer kategorii: ");
                string categoryInput = Console.ReadLine();

                if (!int.TryParse(categoryInput, out int categoryNumber) || categoryNumber < 1 || categoryNumber > 3)
                {
                    Console.WriteLine("Nieprawidłowy numer kategorii. Wybierz wartość od 1 do 3.");
                    continue;
                }

                string category;
                switch (categoryNumber)
                {
                    case 1:
                        category = "clothes";
                        break;
                    case 2:
                        category = "shoes";
                        break;
                    case 3:
                        category = "others";
                        break;
                    default:
                        category = "others";
                        break;
                }

                Console.WriteLine("Podaj cenę produktu:");
                string priceInput = Console.ReadLine();

                if (float.TryParse(priceInput, out float price))
                {
                    wareInFile = new WareInFile(name, category);
                    wareInFile.AddPrice(price);
                    Console.WriteLine("Informacje o produkcie zostały zapisane w pliku.");
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa cena. Spróbuj ponownie.");
                }
            }
        }   
    }
}