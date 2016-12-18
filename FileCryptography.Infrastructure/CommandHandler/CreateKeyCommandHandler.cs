using FileCryptography.Domain.Commands;
using FileCryptography.Domain.Interfaces.Repositories;
using FileCryptography.Domain.Interfaces.Services;
using FileCryptography.Domain.Models;
using FileCryptography.Infrastructure.Interfaces.CommandHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.CommandHandler
{
    public class CreateKeyCommandHandler : ICommandHandler<GenerateKeyPairCommand>
    {
        private readonly IRepository repo;
        private readonly ICryptographyExecutionService cryptoSvc;

        public CreateKeyCommandHandler(IRepository arRepo, ICryptographyExecutionService cryptoSvc)
        {
            this.repo = arRepo;
            this.cryptoSvc = cryptoSvc;
        }

        public void Handle(GenerateKeyPairCommand cmd)
        {
            KeyPair newKeyPair = KeyPair.Create(this.cryptoSvc);
            if(newKeyPair == null || newKeyPair.Id == Guid.Empty)
            {
                throw new Exception("Unable to generate key pair");
            }
        }
    }
}
