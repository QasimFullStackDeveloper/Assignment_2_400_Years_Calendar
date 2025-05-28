using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a starting year: ");
        if (int.TryParse(Console.ReadLine(), out int startYear))
        {
            for (int year = startYear; year < startYear + 400; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    PrintMonthCalendar(year, month);
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid year.");
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
}
