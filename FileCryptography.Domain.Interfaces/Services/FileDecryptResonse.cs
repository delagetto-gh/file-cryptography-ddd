namespace FileCryptography.Domain.Services
{
    public class FileDecryptResonse : ServiceResponse
    {
        public string FileName { get; set; }

        public byte[] Content { get; set; }
    }
}
