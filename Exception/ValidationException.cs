using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetStarter.Exception
{
    public class ValidationException : SystemException
    {

        private int status;
        private List<String> messages = new List<string>();

        public int Status { get => this.status; set => this.status = value; }

        public List<String> Messages { get => this.messages; set => this.messages = value; }

        public void addMessage(string message)
        {
            this.messages.Add(message);
        }

    }
}
