using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Domain.Model
{
    [DataContract]
    public class File
    {
        protected File()
        {}

        public File(string name, byte[] content)
        {
            this.Name = name;
            this.Content = content;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public byte[] Content { get; set; }
    }
}
