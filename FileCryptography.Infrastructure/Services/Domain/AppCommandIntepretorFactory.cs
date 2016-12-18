using FileCryptography.Infrastruture.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Services.Domain
{
    public class AppCommandIntepretorFactory : IAppCommandIntepretorFactory
    {
        private readonly Dictionary<CryptographyApp, IAppCommandInterpretor> appCmdMap;

        public AppCommandIntepretorFactory()
        {
            this.appCmdMap = new Dictionary<CryptographyApp, IAppCommandInterpretor>()
            {
                {CryptographyApp.GnuPg, new GpgCommandInterpretor()}
            };
        }

        public IAppCommandInterpretor Create(CryptographyApp appType)
        {
            if (appCmdMap.ContainsKey(appType))
                return this.appCmdMap[appType];
            else
                throw new NotSupportedException(String.Format("No module found for Crytopgrahy App: {0}", appType));
        }
    }
}
