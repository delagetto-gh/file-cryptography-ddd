using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastruture.Interfaces.Domain
{
    public interface IAppCommandIntepretorFactory
    {
        IAppCommandInterpretor Create(CryptographyApp appType);
    }
}
