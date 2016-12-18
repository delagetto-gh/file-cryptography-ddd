using FileCryptography.Domain.Interfaces.Common;
using FileCryptography.Domain.Interfaces.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCryptography.Domain.Interfaces.Services.Contracts
{
    public class CryptographyResponse
    {
        public CryptographyResponse()
            : this(new List<FileInfo>())
        {
        }

        public CryptographyResponse(List<FileInfo> list)
        {
            this.Files = list;
        }

        public IEnumerable<FileInfo> Files { get; set; }
    }
}
