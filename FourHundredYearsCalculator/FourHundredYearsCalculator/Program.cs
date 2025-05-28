using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Paginated Calendar Viewer\n";

        Console.Write("Enter a starting year: ");
        if (!int.TryParse(Console.ReadLine(), out int startYear))
        {
            Console.WriteLine("Invalid input. Please enter a valid year.");
            return;
        }

        Console.Write("Enter how many years you want to display at a time (e.g., 25, 50, 100): ");
        if (!int.TryParse(Console.ReadLine(), out int chunkSize) || chunkSize <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
            return;
        }

        PaginateCalendarDisplay(startYear, 400, chunkSize);
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

    static void PaginateCalendarDisplay(int startYear, int totalYears, int chunkSize)
    {
        for (int i = 0; i < totalYears; i += chunkSize)
        {
            int currentStartYear = startYear + i;
            int currentEndYear = Math.Min(currentStartYear + chunkSize - 1, startYear + totalYears - 1);

            for (int year = currentStartYear; year <= currentEndYear; year++)
            {
                Console.WriteLine($"\n==== Calendar for Year {year} ====\n");
                for (int month = 1; month <= 12; month++)
                {
                    PrintMonthCalendar(year, month);
                }
            }

            if (i + chunkSize < totalYears)
            {
                Console.WriteLine($"\nDisplayed {chunkSize} years from {currentStartYear} to {currentEndYear}.");
                Console.Write("Press 'Enter' to view the next set or type 'exit' to stop: ");
                string? input = Console.ReadLine();
                if (input?.Trim().ToLower() == "exit")
                    break;
            }
        }
    }

}
