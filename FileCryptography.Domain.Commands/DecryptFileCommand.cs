using FileCryptography.Domain.Interfaces.Commands;
using FileCryptography.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Domain.Commands
{
    public class DecryptFileCommand : Command
    {
        public DecryptFileCommand(FileInfo encryptedFile, FileInfo publicKeyFile, FileInfo passPhrase)
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
