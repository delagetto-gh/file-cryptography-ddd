using FileCryptography.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FileCryptography.Framework.Services.Contracts
{
    [DataContract]
    public class EncryptionRequest : CryptionRequest
    {
        public EncryptionRequest(File filetoEncrypt, FileCryptionArgs args)
            : base(filetoEncrypt, args)
        { }

        public override string Execute()
        {
            IEnumerable<string> cmdArgs = new List<string>
            { 
              String.Format("gpg --import --always-trust {0}", this.CryptionArgs.PublicKey.Name),
              String.Format("--encrypt --always-trust --recipient {0} {1}", this.CryptionArgs.PublicKey.Email, "\"" + this.File.Name + "\""),
              String.Format("--batch --yes --delete-key {0}", this.CryptionArgs.PublicKey.Email),
            };
            return String.Join(" & gpg ", cmdArgs);
        }
    }
}
