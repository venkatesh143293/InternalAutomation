using System;
using System.IO;

namespace WF.Test.AutomationFramework.Helpers
{
    public class CommonHelpers
    {
        public CommonHelpers()
        {

        }

        /// Get path of this project repository
        public static string GetPath()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            return new Uri(actualPath).LocalPath;
        }


        /// <summary>
        /// Create a folder if Missing at location folderPath
        /// </summary>
        public static void CreateFolderIfMissing(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }
    }
}
