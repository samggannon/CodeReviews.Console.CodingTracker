using System;
using System.Globalization;
using System.Linq;

namespace CodingTracker.SamGannon.Utility;

public class Validation
{
    public bool IsValidTimeFormat(string time)
    {
        bool isValid = TimeSpan.TryParseExact(time, "hh\\:mm", CultureInfo.InvariantCulture, out _);
        if (!isValid)
        {
            return false;
        }

        return isValid;
    }

    public bool IsValidDate(string date)
    {
        bool isValid = DateTime.TryParseExact(date, "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None, out _);
        if (!isValid)
        {
            return false;
        }

        return isValid;
    }

    public bool StartTimeIsBeforeFinishTime(TimeSpan startTime, TimeSpan endTime)
    {
        bool isValid = endTime < startTime;
        if (!isValid)
        {
            return false;
        }

        return isValid;
    }

    public bool IsValidId(string commandInput)
    {
        bool isValid = int.TryParse(commandInput, out _) || string.IsNullOrEmpty(commandInput) || int.Parse(commandInput) < 0;
        if (!isValid)
        {
            return false;
        }

        return isValid;
    }
}
