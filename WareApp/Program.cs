namespace WareApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to [WareApp]!");
            Console.WriteLine("The program allows you to save article price in a file.");
            Console.WriteLine();

            var clothesStatistics = new Statistics();
            var shoesStatistics = new Statistics();
            var othersStatistics = new Statistics();

            while (true)
            {
                Console.WriteLine("Enter the article name or press 'q' to display statistics:");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    Console.WriteLine();
                    Console.WriteLine("Statistics for the 'clothes' category:");
                    Console.WriteLine($"AVR: {clothesStatistics.Avr}");
                    Console.WriteLine($"SUM: {clothesStatistics.Sum}");
                    Console.WriteLine($"MAX: {clothesStatistics.Max}");

                    Console.WriteLine();
                    Console.WriteLine("Statistics for the 'shoes' category:");
                    Console.WriteLine($"AVR: {shoesStatistics.Avr}");
                    Console.WriteLine($"SUM: {shoesStatistics.Sum}");
                    Console.WriteLine($"MAX: {shoesStatistics.Max}");

                    Console.WriteLine();
                    Console.WriteLine("Statistics for the 'others' category:");
                    Console.WriteLine($"AVR: {othersStatistics.Avr}");
                    Console.WriteLine($"SUM: {othersStatistics.Sum}");
                    Console.WriteLine($"MAX: {othersStatistics.Max}");
                    break;
                }

                string name = input;

                Console.WriteLine("Select a category:");
                Console.WriteLine("1 - clothes");
                Console.WriteLine("2 - shoes");
                Console.WriteLine("3 - others");
                Console.Write("Choose category number: ");
                string categoryInput = Console.ReadLine();

                if (!int.TryParse(categoryInput, out int categoryNumber) || categoryNumber < 1 || categoryNumber > 3)
                {
                    Console.WriteLine("Invalid category number. Please choose a value from 1 to 3.");
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

                float price = 0;
                bool isValidPrice = false;

                while (!isValidPrice)
                {
                    Console.WriteLine("Enter article price:");
                    string priceInput = Console.ReadLine();

                    if (float.TryParse(priceInput, out price))
                    {
                        isValidPrice = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Try again.");
                    }
                }

                if (category == "clothes")
                {
                    var wareInFile = new WareInFile(name, category);
                    wareInFile.AddPrice(price);
                    clothesStatistics = wareInFile.GetStatistics();
                }
                else if (category == "shoes")
                {
                    var wareInMemory = new WareInMemory(name, category);
                    wareInMemory.AddPrice(price);
                    shoesStatistics = wareInMemory.GetStatistics();
                }
                else if (category == "others")
                {
                    var wareInMemory = new WareInMemory(name, category);
                    wareInMemory.AddPrice(price);
                    othersStatistics = wareInMemory.GetStatistics();
                }

                Console.WriteLine("The product information has been saved.");

            }
        }
    }
}