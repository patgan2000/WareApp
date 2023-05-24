Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
Console.WriteLine($"Welcome to the [ExpensesApp] to measure your fashion expenses");
Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
Console.WriteLine("If you want too see an user manual, write help");
var help = Console.ReadLine();
if (help == "help" || help == "Help" || help == "HELP")
{
    Console.WriteLine("You will be asked to enter the article name, category and purchase price.");
    Console.WriteLine("The program will calculate for you the sum and the average amount spent in a given category.");
    Console.WriteLine("If you want to stop typing - type Q.");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
}
else
{
    Console.WriteLine("To stop the app and show the results, - type Q.");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
}
