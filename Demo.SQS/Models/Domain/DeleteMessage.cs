using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.SQS.Models.Domain
{
    public class DeleteMessage
    {
        public string ReceiptHandle { get; set; }
    }
}
