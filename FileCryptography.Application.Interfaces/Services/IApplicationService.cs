using FileCryptography.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Application.Interfaces.Services
{
    public interface IApplicationService : ICommandService, IQueryService
    {
    }
}
