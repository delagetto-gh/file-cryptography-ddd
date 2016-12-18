using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Domain.Interfaces.Common
{
    public class FileInfo
    {
        public FileInfo()
        {
                
        }

        public FileInfo(string fileName, byte[] content)
        {
            this.FileName = fileName;
            this.Content = content;
        }

        public string FileName { get; set; }

        public byte[] Content { get; set; }
    }
}
