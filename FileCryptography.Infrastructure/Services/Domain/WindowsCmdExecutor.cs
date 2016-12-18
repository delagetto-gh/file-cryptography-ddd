using FileCryptography.Infrastruture.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Services.Domain
{
    public class WindowsCmdExecutor : IOperatingSystemCommandExecutor
    {
        private readonly Process cmdProc;
        private string output;
        private string error;

        public WindowsCmdExecutor()
        {
            this.cmdProc = new Process();
        }

        public string Execute(string command)
        {
            this.error = String.Empty;
            this.output = String.Empty;

            try
            {
                var psi = new ProcessStartInfo();
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardError = true;
                psi.FileName = "cmd.exe";
                this.cmdProc.StartInfo = psi;
                this.cmdProc.Start();
                this.cmdProc.StandardInput.WriteLine(command);
                this.cmdProc.StandardInput.Flush();
                this.cmdProc.StandardInput.Close();
                this.cmdProc.WaitForExit();
                this.error = this.cmdProc.StandardError.ReadToEnd();
                this.output = this.cmdProc.StandardOutput.ReadToEnd();
                if (String.IsNullOrWhiteSpace(this.error))
                {
                    return this.output;
                }
                else
                {
                    throw new Exception(String.Format("Unable to process command. Error: {0}", this.error));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        void OnCmdOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.output = e.Data;
        }

        void OnCmdErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.error = e.Data;
        }
    }
}
