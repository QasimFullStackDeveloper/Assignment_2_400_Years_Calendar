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

    static List<string> GetMonthCalendarLines(int year, int month)
    {
        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        List<string> lines = new List<string>();

        lines.Add($"{monthName,-20}"); // removed year from here
        lines.Add("Su Mo Tu We Th Fr Sa");

        DateTime firstDay = new DateTime(year, month, 1);
        int startDay = (int)firstDay.DayOfWeek;
        int daysInMonth = DateTime.DaysInMonth(year, month);

        string week = new string(' ', startDay * 3);
        for (int day = 1; day <= daysInMonth; day++)
        {
            week += $"{day,2} ";
            if ((startDay + day) % 7 == 0 || day == daysInMonth)
            {
                lines.Add(week.TrimEnd());
                week = "";
            }
        }

        return lines;
    }



    static void PaginateCalendarDisplay(int startYear, int totalYears, int chunkSize)
    {
        int endYear = startYear + totalYears - 1;

        for (int year = startYear; year <= endYear; year += chunkSize)
        {
            int currentEndYear = Math.Min(year + chunkSize - 1, endYear);

            for (int y = year; y <= currentEndYear; y++)
            {
                Console.WriteLine($"\n============== Year {y} ==============\n");

                for (int m = 1; m <= 12; m += 3)
                {
                    PrintMonthsRow(y, m, 3);
                    Console.WriteLine();
                }
            }

            if (currentEndYear < endYear)
            {
                Console.WriteLine($"\nDisplayed years {year} to {currentEndYear}.");
                Console.Write("Press 'Enter' to view the next set or type 'exit' to stop: ");
                string? input = Console.ReadLine();
                if (input?.Trim().ToLower() == "exit")
                    break;
            }
        }
    }

static void PrintMonthsRow(int year, int startMonth, int monthsPerRow)
    {
        List<List<string>> calendars = new List<List<string>>();

        for (int m = 0; m < monthsPerRow; m++)
        {
            int month = startMonth + m;
            if (month > 12) break;
            calendars.Add(GetMonthCalendarLines(year, month));
        }

        int maxLines = calendars.Max(cal => cal.Count);
        for (int line = 0; line < maxLines; line++)
        {
            foreach (var cal in calendars)
            {
                if (line < cal.Count)
                    Console.Write(cal[line].PadRight(22));
                else
                    Console.Write(new string(' ', 22));
            }
            Console.WriteLine();
        }
    }



}
