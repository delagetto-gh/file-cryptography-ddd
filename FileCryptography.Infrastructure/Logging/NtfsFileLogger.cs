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
        private readonly string filePath;

        public NtfsFileLogger(string logFileDir)
        {
            if (!Directory.Exists(logFileDir))
            {
                Directory.CreateDirectory(logFileDir);
            }
            this.filePath = String.Format("{0}\\{1}_{2}.txt", logFileDir, "FileCryptographyLog", DateTimeOffset.Now.ToString("ddMMyy"));
            File.Create(this.filePath);
        }

        public async Task Log(string message)
        {
            using (var fsw = new FileStream(this.filePath, FileMode.Append))
            using (var sw = new StreamWriter(fsw))
            {
                message = String.Format("Log-{0}: {1}", DateTimeOffset.Now, message);
                await sw.WriteLineAsync(message);
            }
        }
    }
}
