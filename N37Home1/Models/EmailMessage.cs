using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37Home1.Models
{
    internal class EmailMessage
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverAddress { get; set; }
        
        public EmailMessage(string subject, string body, string senderAddress, string receiverAddress)
        {
            Subject = subject;
            Body = body;
            SenderAddress = senderAddress;
            ReceiverAddress = receiverAddress;
        }
    }
}
