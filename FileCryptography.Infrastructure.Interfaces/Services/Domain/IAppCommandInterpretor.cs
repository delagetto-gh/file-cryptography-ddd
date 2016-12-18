using FileCryptography.Domain.Interfaces.Services;
using FileCryptography.Domain.Interfaces.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCryptography.Infrastruture.Interfaces.Domain
{
    public interface IAppCommandInterpretor
    {
        string InterporateCommandRequest<T>(T cmdRequest) where T : CryptographyRequest;

        CryptographyResponse InterporateResponse<T>(T cmdType, string appResponse) where T : CryptographyRequest;
    }
}
