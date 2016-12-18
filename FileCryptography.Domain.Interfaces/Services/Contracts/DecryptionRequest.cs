using FileCryptography.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Domain.Interfaces.Services.Contracts
{
    public class DecryptionRequest : CryptographyRequest
    {
        public DecryptionRequest(FileInfo encryptedFile, FileInfo publicKeyFile, FileInfo passPhrase)
        {
            this.EncryptedFile = encryptedFile;
            this.PublicKeyFile = publicKeyFile;
            this.PassPhrase = passPhrase;
        }

        public Guid KeyId { get; set; }

        public FileInfo EncryptedFile { get; set; }

        public FileInfo PublicKeyFile { get; set; }

        public FileInfo PassPhrase { get; set; }
    }
}
