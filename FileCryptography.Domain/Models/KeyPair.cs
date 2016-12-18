using FileCryptography.Domain.Events;
using FileCryptography.Domain.Interfaces.Models;
using FileCryptography.Domain.Interfaces.Services;
using FileCryptography.Domain.Interfaces.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileCryptography.Domain.Interfaces.Common;
using FileCryptography.Domain.Commands;

namespace FileCryptography.Domain.Models
{
    public class KeyPair : AggregateRoot
    {
        public static KeyPair Create(ICryptographyExecutionService cryptoCmdService)
        {
            //should be in application service layer??
            //maybe not as theres domainSpecific validation going on here (count != 3)
            CryptographyResponse response;
            try
            {
                response = cryptoCmdService.Execute(new GenerateKeyPairRequest());
                if (response == null || response.Files.Count() != 3)
                    throw new Exception("Unable to generate keypair");
            }
            catch (Exception) { throw; }

            var keyPairFiles = response.Files.ToList();
            var privateKey = new FileInfo(keyPairFiles[0].FileName, keyPairFiles[0].Content);
            var publicKey = new FileInfo(keyPairFiles[1].FileName, keyPairFiles[1].Content);
            var passPhrase = new FileInfo(keyPairFiles[2].FileName, keyPairFiles[2].Content);
            return new KeyPair(privateKey, publicKey, passPhrase);
        }

        private KeyPair(FileInfo privateKey, FileInfo publicKey, FileInfo passPhrase)
        {
            this.PrivateKey = privateKey;
            this.PublicKey = publicKey;
            this.PassPhrase = passPhrase;
            DomainEvents.Publish(new KeyPairGeneratedEvent(this.Id));
        }

        public FileInfo PrivateKey { get; private set; }

        public FileInfo PublicKey { get; private set; }

        public FileInfo PassPhrase { get; private set; }

        public void Decrypt(FileInfo fileToDecrypt, ICryptographyExecutionService cryptoCmdService)
        {
            CryptographyResponse response;
            try
            {
                response = cryptoCmdService.Execute(new DecryptionRequest(fileToDecrypt, this.PublicKey, this.PassPhrase));
                if (response == null || response.Files.Count() != 1)
                    throw new Exception();
            }
            catch (Exception e) { throw; }

            DomainEvents.Publish(new FileDecryptedEvent(this.Id, response.Files.First()));
        }
    }
}
