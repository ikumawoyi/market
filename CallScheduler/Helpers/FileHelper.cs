using System;
using System.Collections.Generic;
using System.IO;

namespace CallScheduler.Helpers
{
    public static class FileHelpers
    {
        public static List<string> ReadFile(string path)
        {
            var sr = new StreamReader(new FileStream(path, FileMode.Open));
            var data = new List<string>();
            var line = sr.ReadLine();
            while (line != null)
            {
                data.Add(line);
                line = sr.ReadLine();
            }
            sr.Dispose();
            return data;
        }
    }
}