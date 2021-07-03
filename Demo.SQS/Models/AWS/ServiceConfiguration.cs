using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.SQS.Models.AWS
{
    public class ServiceConfiguration
    {
        public ServiceConfiguration(string awssqs)
        {
            AWSSQS = awssqs;
        }
        public string AWSSQS { get; set; }
    }
}
