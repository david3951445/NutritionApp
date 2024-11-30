using System;
using System.ComponentModel;

namespace UtilsLibrary;

public class Utils
{
    public static string SolutionPath
    {
        get
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            for (int i = 0; i < 5; i++)
                folderPath = Path.GetDirectoryName(folderPath);
            return folderPath;
        }
    }
}

public static class EnumExtensions
{
    public static T ParseOrDefault<T>(string? input) where T : struct
    {
        // Try parsing directly by enum name
        if (Enum.TryParse(input, true, out T result))
            return result;

        // Fallback to checking descriptions
        foreach (var field in typeof(T).GetFields())
        {
            var attribute = (DescriptionAttribute?)field
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault();

            if (attribute?.Description == input)
            {
                var fieldValue = field.GetValue(null);
                return fieldValue == null ? default : (T)fieldValue;
            }
        }

        // Return the default value
        return default;
    }

    public static string? GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                              .FirstOrDefault() as DescriptionAttribute;

        return attribute?.Description ?? value.ToString(); // Fallback to enum name if no description
    }
}
