using FileCryptography.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FileCryptography.Framework.Services.Contracts
{
    [DataContract]
    public class DecryptionRequest : CryptionRequest
    {
        public DecryptionRequest(File filetoDecrypt, FileCryptionArgs args)
            : base(filetoDecrypt, args)
        { }

        public override string Execute()
        {
            IEnumerable<string> cmdArgs = new List<string>
            { String.Format("--import --always-trust {0}.gpg", this.CryptionArgs.PrivateKey.Name),
              String.Format("--decrypt --passphrase {0} {1}", this.CryptionArgs.PassPhrase.Name, this.File.Name),
              String.Format("--delete-secret-and-public-key {0}", this.CryptionArgs.PrivateKey.Email),
            };
            return String.Join(" & ", cmdArgs);
        }
    }
}
