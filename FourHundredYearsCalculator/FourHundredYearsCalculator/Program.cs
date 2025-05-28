using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "400-Year Calendar Generator";
        const int startYear = 1625;
        const int endYear = 2025;
while (true)
{
    Console.Clear();
    Console.WriteLine("==== 400-Year Calendar Generator ====");
    Console.WriteLine("1. Print all calendars from 1625 to 2025");
    Console.WriteLine("2. Print calendar for a specific year");
    Console.WriteLine("3. Exit");
    Console.Write("\nEnter your choice (1-3): ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            PrintFullCalendar(startYear, endYear);
            PauseAndReturn();
            break;

        case "2":
            HandleSingleYear(startYear, endYear);
            break;

        case "3":
            Console.WriteLine("\nExiting the program. Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid choice. Press any key to try again...");
            Console.ReadKey();
            break;
    }
}
    }

    static void PrintMonthCalendar(int year, int month)
    {
        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        Console.WriteLine($"\n{monthName} {year}");
        Console.WriteLine("Su Mo Tu We Th Fr Sa");

        DateTime firstDay = new DateTime(year, month, 1);
        int startDay = (int)firstDay.DayOfWeek;
        int daysInMonth = DateTime.DaysInMonth(year, month);

        for (int i = 0; i < startDay; i++)
        {
            Console.Write("   ");
        }

        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write($"{day,2} ");
            if ((startDay + day) % 7 == 0)
                Console.WriteLine();
        }

        Console.WriteLine();
    }

    static void PauseAndReturn()
    {
        Console.WriteLine("\n\nPress any key to return to the main menu...");
        Console.ReadKey();
    }
static void PrintFullCalendar(int startYear, int endYear)
{
    for (int year = startYear; year <= endYear; year++)
    {
        Console.WriteLine($"\n\n==== Calendar for Year {year} ====\n");
        for (int month = 1; month <= 12; month++)
        {
            PrintMonthCalendar(year, month);
        }
    }
}

}
