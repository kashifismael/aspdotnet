using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetStarter.Exception
{
    public class NotFoundException : SystemException
    {

        private string message;

        public NotFoundException(string message)
        {
            this.message = message;
        }

        public string Message { get => this.message; set => this.message = value; }

    }
}
