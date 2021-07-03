using Amazon.SQS.Model;
using Demo.SQS.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.SQS.Models.AWS.Interfaces
{
    public interface IAWSSQSIntegration
    {
        Task<bool> SendMessageAsync(UserDetail userDetail);
        Task<List<Message>> ReceiveMessageAsync();
        Task<bool> DeleteMessageAsync(string messageReceiptHandle);
    }
}
