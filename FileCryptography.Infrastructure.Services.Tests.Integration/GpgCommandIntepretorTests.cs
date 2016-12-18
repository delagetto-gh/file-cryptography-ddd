using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileCryptography.Infrastruture.Interfaces.Domain;
using FileCryptography.Infrastructure.Services.Domain;
using FileCryptography.Domain.Interfaces.Services.Contracts;
using FluentAssertions;
using System.Linq;
using FileCryptography.Domain.Interfaces.Common;
using System.Collections.Generic;

namespace FileCryptography.Infrastructure.Services.Tests.Unit
{
    [TestClass]
    public class GpgCommandIntepretorTests
    {
        [TestClass]
        public class TheInterporateMethod
        {
            [TestMethod]
            public void ShouldReturn3FilesFromEmbeddedResourceKeysCompleteWithNameAndByteContent()
            {
                CryptographyRequest sut = new GenerateKeyPairRequest();
                IAppCommandInterpretor inter = new GpgCommandInterpretor();
                inter.InterporateCommandRequest(sut);
                string osResult = "Use pre-generated keyFiles.";
                CryptographyResponse response = inter.InterporateResponse(sut, osResult);
                response.Should().NotBeNull();
                response.Files.Should().HaveCount(3);
                response.Files.Should().AllBeOfType<FileInfo>();
                List<FileInfo> files = response.Files.ToList();
                files[0].FileName.Should().Be("FileCryptography.Infrastructure.Data.Keys.FileCryptographyService.Private.gpg");
                files[1].FileName.Should().Be("FileCryptography.Infrastructure.Data.Keys.FileCryptographyService.Public.gpg");
                files[2].FileName.Should().Be("FileCryptography.Infrastructure.Data.Keys.FileCryptographyService.Private.Passphrase.pass");
            }
        }
    }
}
