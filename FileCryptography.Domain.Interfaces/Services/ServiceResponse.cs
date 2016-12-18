using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCryptography.Domain.Services
{
    public class ServiceResponse
    {
        public Status Status { get; set; }

        public string Message { get; set; }
    }
}
