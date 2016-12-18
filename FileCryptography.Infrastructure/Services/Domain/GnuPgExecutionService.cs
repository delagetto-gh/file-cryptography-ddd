using FileCryptography.Domain.Interfaces.Services;
using FileCryptography.Domain.Interfaces.Services.Contracts;
using FileCryptography.Domain.Models;
using FileCryptography.Infrastruture.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Services.Domain
{
    public class GnuPgExecutionService : ICryptographyExecutionService
    {
        private readonly IOperatingSystemCommandExecutor osTerminal;
        private readonly IAppCommandInterpretor cmdInterpretor;

        public GnuPgExecutionService(IOperatingSystemCommandExecutor osTerminal, IAppCommandIntepretorFactory cmdInterpretor)
        {
            this.osTerminal = osTerminal;
            this.cmdInterpretor = cmdInterpretor.Create(CryptographyApp.GnuPg);
        }

        public CryptographyResponse Execute(CryptographyRequest req)
        {
            try
            {
                string gnuCmd = this.cmdInterpretor.InterporateCommandRequest(req);
                string osResult = this.osTerminal.Execute(gnuCmd);
                CryptographyResponse gnuResponse = this.cmdInterpretor.InterporateResponse(req, osResult);
                return gnuResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
