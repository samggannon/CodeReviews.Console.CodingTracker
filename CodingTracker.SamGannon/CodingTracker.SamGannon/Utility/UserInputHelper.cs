using System.Globalization;

namespace CodingTracker.SamGannon.Utility;

internal class UserInputHelper
{
    public string GetStartTime()
    {
        Console.WriteLine("Please enter the start time of your session in the following format: (HH:mm).");
        Console.WriteLine("Use 24-hour format (e.g., 17:45).\n");

        string startTime = Console.ReadLine();
        startTime = ValidateTimeFormat(startTime);

        return startTime;
    }

    public string GetEndTime()
    {
        Console.WriteLine("Please enter the ending time of your session in the following format: (HH:mm).");
        Console.WriteLine("Use 24-hour format (e.g., 17:45).");

        string endTime = Console.ReadLine();
        endTime = ValidateTimeFormat(endTime);

        return endTime;
    }

    public string GetDateInput()
    {
        Console.WriteLine("Please enter the date in the following format: (dd-mm-yy).");

        string userDateInput = Console.ReadLine();

        while (!DateTime.TryParseExact(userDateInput, "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
        {
            Console.WriteLine("\n\nNot a valid date. Please insert the date with the format: dd-mm-yy.\n\n");
            userDateInput = Console.ReadLine();
        }

        return userDateInput;
    }

    public string CalculateDuration(string startTime, string endTime)
    {
        TimeSpan tsStartTime = TimeSpan.ParseExact(startTime, "h\\:mm", CultureInfo.InvariantCulture);
        TimeSpan tsEndTime = TimeSpan.ParseExact(endTime, "hh\\:mm", CultureInfo.InvariantCulture);

        while (tsEndTime < tsStartTime)
        {
            Console.WriteLine("\nEnd time cannot occur before the start time. Please try again.\n");

            startTime = GetStartTime();
            ValidateTimeFormat(startTime);

            endTime = GetEndTime();
            ValidateTimeFormat(endTime);

            tsStartTime = TimeSpan.ParseExact(startTime, "h\\:mm", CultureInfo.InvariantCulture);
            tsEndTime = TimeSpan.ParseExact(endTime, "hh\\:mm", CultureInfo.InvariantCulture);
        }

        TimeSpan duration = tsEndTime - tsStartTime;
        return $"{(int)duration.TotalHours:D2}:{duration.Minutes:D2}";
    }

    private string ValidateTimeFormat(string time)
    {
        Validation validator = new Validation();
        bool isValidTime = validator.IsValid24HourFormat(time);

        while (!isValidTime)
        {
            Console.WriteLine("\n\nDuration invalid. Please insert the duration in 24-hour format HH:mm: (e.g., 17:45)\n\n");
            time = Console.ReadLine();
        }

        return time;
    }

    public string CalculateSleepType(string duration)
    {
        TimeSpan sleepDuration = TimeSpan.ParseExact(duration, "h\\:mm\\:ss", CultureInfo.InvariantCulture);

        if (sleepDuration.TotalHours > 4)
        {
            return "Long";
        }
        else
        {
            return "Short";
        }
    }

    public int ValidateIdInput(string? commandInput)
    {
        while (!int.TryParse(commandInput, out _) || string.IsNullOrEmpty(commandInput) || int.Parse(commandInput) < 0)
        {
            Console.WriteLine("\n You have to type a valid Id\n");
            commandInput = Console.ReadLine();
        }

        var id = int.Parse(commandInput);

        return id;
    }
}
