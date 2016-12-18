using FileCryptography.Domain.Model;
using FileCryptography.Framework.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Services.ServiceImplementation
{
    public class PgpFileCryptographyService : IFileCryptographyService
    {
        private readonly IFileCryptographyServiceCallbacks clientCallback;
        private readonly System.IO.FileInfo fullPathToPgpRoot;
        private readonly System.IO.DirectoryInfo workingDir = new System.IO.DirectoryInfo(Assembly.GetExecutingAssembly().Location).Parent;
        private readonly Process cmdProc = new Process();

        public PgpFileCryptographyService()
            : this(@"C:\Program Files (x86)\GNU\GnuPG")
        { }

        public PgpFileCryptographyService(string fullPathToPgp)
        {
            this.clientCallback = OperationContext.Current.GetCallbackChannel<IFileCryptographyServiceCallbacks>();

            if (System.IO.Directory.Exists(fullPathToPgp))
                this.fullPathToPgpRoot = new System.IO.FileInfo(fullPathToPgp);
            else
            {
                throw new ArgumentException("No installation of GnuPgp found", fullPathToPgp);
            }
        }

        public void Decrypt(DecryptionRequest req)
        {
            string cmdArgs;
            try
            {
                cmdArgs = req.Execute();
                using (System.IO.FileStream fsDecryptFile = new System.IO.FileStream(this.fullPathToPgpRoot + "\\" + req.File.Name, System.IO.FileMode.Create))
                using (System.IO.FileStream fsPrivateKeyFile = new System.IO.FileStream(this.fullPathToPgpRoot + "\\" + req.CryptionArgs.PrivateKey.Name, System.IO.FileMode.Create))
                using (System.IO.FileStream fsPassphraseFile = new System.IO.FileStream(this.fullPathToPgpRoot + "\\" + req.CryptionArgs.PassPhrase.Name, System.IO.FileMode.Create))
                {
                    fsDecryptFile.Write(req.File.Content, 0, req.File.Content.Length);
                    fsPrivateKeyFile.Write(req.CryptionArgs.PrivateKey.Content, 0, req.File.Content.Length);
                    fsPassphraseFile.Write(req.CryptionArgs.PassPhrase.Content, 0, req.File.Content.Length);
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (this.ExecuteGnuGpg(cmdArgs))
            {
                System.IO.FileInfo decryptedFile = new System.IO.FileInfo(String.Format("{0}\\{1}", this.workingDir, req.File.Name.Replace(".gpg", "")));
                if (decryptedFile.Exists)
                {
                    var callback = this.clientCallback;
                    if (callback != null)
                    {
                        byte[] fileContent = System.IO.File.ReadAllBytes(decryptedFile.FullName);
                        callback.OnFileDecrypted(new FileCryptionEvent { File = new File(decryptedFile.Name, fileContent), ExecutedCommand = cmdArgs });
                    }
                }
            }
        }

        public void Encrypt(EncryptionRequest req)
        {
            string cmdArgs;
            try
            {
                cmdArgs = req.Execute();
                using (System.IO.FileStream fsEncryptFile = new System.IO.FileStream(this.fullPathToPgpRoot + "\\" + req.File.Name, System.IO.FileMode.Create))
                using (System.IO.FileStream fsPublicKeyFile = new System.IO.FileStream(this.fullPathToPgpRoot + "\\" + req.CryptionArgs.PublicKey.Name, System.IO.FileMode.Create))
                {
                    fsEncryptFile.Write(req.File.Content, 0, req.File.Content.Length);
                    fsPublicKeyFile.Write(req.CryptionArgs.PublicKey.Content, 0, req.CryptionArgs.PublicKey.Content.Length);
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (this.ExecuteGnuGpg(cmdArgs))
            {
                System.IO.FileInfo encryptedFile = new System.IO.FileInfo(String.Format("{0}\\{1}", this.fullPathToPgpRoot, req.File.Name + ".gpg"));
                if (encryptedFile.Exists)
                {
                    var callback = this.clientCallback;
                    if (callback != null)
                    {
                        byte[] fileContent = System.IO.File.ReadAllBytes(encryptedFile.FullName);
                        callback.OnFileEncrypted(new FileCryptionEvent { File = new File(encryptedFile.Name, fileContent), ExecutedCommand = cmdArgs });
                    }
                }
            }
        }

        private bool ExecuteGnuGpg(string commandArgs)
        {
            try
            {
                var psi = new ProcessStartInfo();
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardError = true;
                psi.WorkingDirectory = this.fullPathToPgpRoot.FullName;
                psi.FileName = "cmd.exe";
                this.cmdProc.StartInfo = psi;
                this.cmdProc.Start();
                this.cmdProc.StandardInput.WriteLine(commandArgs);
                this.cmdProc.StandardInput.Flush();
                this.cmdProc.StandardInput.Close();
                this.cmdProc.WaitForExit();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
