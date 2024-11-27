using System;

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
