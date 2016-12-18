using FileCryptography.Domain.Interfaces.Common;
using FileCryptography.Domain.Interfaces.Services;
using FileCryptography.Domain.Interfaces.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Domain.Tests.Unit
{
    internal class MockCryptographyExecutionService : ICryptographyExecutionService
    {
        public CryptographyResponse Execute(CryptographyRequest request)
        {
            return new CryptographyResponse(new List<FileInfo>
             { 
                 new FileInfo("TestFile.txt", Encoding.ASCII.GetBytes("HelloWorld")),
                 new FileInfo("TestFile.txt", Encoding.ASCII.GetBytes("HelloWorld")),
                 new FileInfo("TestFile.txt", Encoding.ASCII.GetBytes("HelloWorld"))
             });
        }
    }
}
