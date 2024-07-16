using System;
using System.Globalization;
using System.Linq;

namespace CodingTracker.SamGannon.Utility;

public class Validation
{
    public bool IsValid24HourFormat(string time)
    {
        bool isValid = TimeSpan.TryParseExact(time, "hh\\:mm", CultureInfo.InvariantCulture, out _);
        if (!isValid)
        {
            return false;
        }
        return isValid;
    }
}
