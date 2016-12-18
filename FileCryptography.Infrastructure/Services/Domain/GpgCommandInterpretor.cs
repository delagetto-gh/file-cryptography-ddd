using FileCryptography.Domain.Interfaces.Common;
using FileCryptography.Domain.Interfaces.Services.Contracts;
using FileCryptography.Infrastructure.Data.Keys;
using FileCryptography.Infrastruture.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FileCryptography.Infrastructure.Services.Domain
{
    public class GpgCommandInterpretor : IAppCommandInterpretor
    {
        private readonly Dictionary<Type, Tuple<Func<CryptographyRequest, string>, Func<string, CryptographyResponse>>> cmdResponseMap;

        public GpgCommandInterpretor()
        {
            this.cmdResponseMap = new Dictionary<Type, Tuple<Func<CryptographyRequest, string>, Func<string, CryptographyResponse>>>();
            this.cmdResponseMap.Add(typeof(DecryptionRequest), Tuple.Create<Func<CryptographyRequest, string>, Func<string, CryptographyResponse>>(
            #region DecryptionRequest Set-up
cryptoCmd =>
{
    var decryptCmd = cryptoCmd as DecryptionRequest;
    var cmdArgs = new List<string>()
                { String.Format("gpg --import --always-trust {0}.gpg", decryptCmd.PublicKeyFile.FileName),
                  String.Format("--decrypt --passphrase {0} {1}", decryptCmd.PassPhrase.FileName, decryptCmd.EncryptedFile),
                  String.Format("--delete-secret-and-public-key {0}", decryptCmd.KeyId),
                };
    return String.Join(" & ", cmdArgs);
},
            osOutput =>
            {
                var files = new List<FileInfo> { new FileInfo(osOutput.Split('|')[0], Encoding.ASCII.GetBytes(osOutput.Split('|')[1])) };
                return new CryptographyResponse(files);
            }));
            #endregion
            this.cmdResponseMap.Add(typeof(GenerateKeyPairRequest), Tuple.Create<Func<CryptographyRequest, string>, Func<string, CryptographyResponse>>(
            cryptoCmd =>
            {
                return "echo Use pre-generated keyFiles.";
            },
           osOutput =>
           {
               if (osOutput.Contains("Use pre-generated keyFiles."))
               {
                   List<FileInfo> returnFiles = new List<FileInfo>();
                   Assembly keyfileRsc = Assembly.GetAssembly(typeof(KeyFileResource));
                   IEnumerable<string> keyFileResources = keyfileRsc.GetManifestResourceNames();
                   foreach (var keyFile in keyFileResources)
                   {
                       using (var streamReader = new System.IO.StreamReader(keyfileRsc.GetManifestResourceStream(keyFile)))
                       using (var fsW = new System.IO.FileStream(keyFile, System.IO.FileMode.Create))
                       using (var streamWriter = new System.IO.StreamWriter(fsW))
                       {
                           var data = streamReader.ReadToEnd();
                           streamWriter.Write(data);
                           returnFiles.Add(new FileInfo(keyFile, Encoding.ASCII.GetBytes(data)));
                       }
                   }
                   return new CryptographyResponse(returnFiles);
               }
               else
               {
                   throw new NotImplementedException("Cannot support real interactiveless keygen right now!");
               }
           }));
        }

        public string InterporateCommandRequest<T>(T cmd) where T : CryptographyRequest
        {
            if (this.cmdResponseMap.ContainsKey(cmd.GetType()))
                return this.cmdResponseMap[cmd.GetType()].Item1(cmd);
            else
                throw new NotSupportedException(String.Format("Type {0} is not a supported GnuPg Command", typeof(T)));
        }


        public CryptographyResponse InterporateResponse<T>(T cmdType, string response) where T : CryptographyRequest
        {
            if (this.cmdResponseMap.ContainsKey(cmdType.GetType()))
                return this.cmdResponseMap[cmdType.GetType()].Item2(response);
            else
                throw new NotSupportedException(String.Format("Type {0} is not a supported GnuPg Command", typeof(T)));
        }
    }
}
