using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "400-Year Calendar Generator";
        const int startYear = 1625;
        const int endYear = 2025;

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
}