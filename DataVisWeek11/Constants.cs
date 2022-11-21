using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisWeek11
{
    internal class Constants
    {
        private const string folderName = "temp";

        public static string directoryPath => Path.Combine(Directory.GetCurrentDirectory(), folderName);
    }
}
