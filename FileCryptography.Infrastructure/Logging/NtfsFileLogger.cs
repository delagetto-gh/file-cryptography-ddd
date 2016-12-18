using FileCryptography.Infrastructure.Interfaces.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Logging
{
    public class NtfsFileLogger : ILogger
    {
        private readonly FileStream fileStream;
        private readonly string filePath;

        public NtfsFileLogger(string logFileDir)
        {
            if (Directory.Exists(logFileDir))
                Directory.CreateDirectory(logFileDir);
            else
                throw new UnauthorizedAccessException(String.Format("Cannot create folder at {0}", logFileDir));

            this.filePath = String.Format("{0}\\{2}_{3}.txt", logFileDir, "FileCryptographyLog", DateTimeOffset.Now.ToString("d"));
            this.fileStream = File.Create(this.filePath);
        }

        public async Task Log(string message)
        {
            using (var fsw = new StreamWriter(this.fileStream))
            {
                message = String.Format("Log-{0}: {1}", DateTimeOffset.Now, message);
                await fsw.WriteAsync(message);
            }
        }
    }
}
