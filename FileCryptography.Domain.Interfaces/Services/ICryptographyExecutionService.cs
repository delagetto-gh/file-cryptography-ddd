using FileCryptography.Domain.Interfaces.Services.Contracts;

namespace FileCryptography.Domain.Interfaces.Services
{
    public interface ICryptographyExecutionService
    {
        CryptographyResponse Execute(CryptographyRequest request);
    }
}
