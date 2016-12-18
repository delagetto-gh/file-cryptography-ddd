using FileCryptography.Domain.Commands;
using FileCryptography.Domain.Interfaces.Repositories;
using FileCryptography.Domain.Interfaces.Services;
using FileCryptography.Domain.Interfaces.Services.Contracts;
using FileCryptography.Domain.Models;
using FileCryptography.Infrastructure.Interfaces.CommandHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.CommandHandler
{
    public class DecrypeFileCommandHandler : ICommandHandler<DecryptFileCommand>
    {
        private readonly IRepository arRepo;
        private readonly ICryptographyExecutionService cryptoSvc;

        public DecrypeFileCommandHandler(IRepository repo, ICryptographyExecutionService cryptoSvc)
        {
            this.arRepo = repo;
            this.cryptoSvc = cryptoSvc;
        }

        public async void Handle(DecryptFileCommand cmd)
        {
            var keyPair = await this.arRepo.Get<KeyPair>(cmd.KeyId);
            if (keyPair == null)
                throw new Exception(String.Format("Key not found, ensure keypair has been generated. KeyId: {0}", cmd.KeyId));

            keyPair.Decrypt(cmd.EncryptedFile, this.cryptoSvc);
        }
    }
}
