using System;
using System.ServiceModel;
namespace FileCryptography.Domain.Services
{
    [ServiceContract]
    public interface ICryptographyService
    {
        [ServiceBehavior]
        FileDecryptResonse Decrypt(FileDecryptRequest req);
    }
}
