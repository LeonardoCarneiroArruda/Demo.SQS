using Amazon.SQS.Model;
using Demo.SQS.Models.AWS.Interfaces;
using Demo.SQS.Models.Domain;
using Demo.SQS.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.SQS.Services
{
    public class AWSSQSService : IAWSSQSService
    {
        private readonly IAWSSQSIntegration _AWSSQSIntegration;
        public AWSSQSService(IAWSSQSIntegration AWSSQSIntegration)
        {
            _AWSSQSIntegration = AWSSQSIntegration;
        }
        public async Task<bool> DeleteMessageAsync(DeleteMessage deleteMessage) 
            => await _AWSSQSIntegration.DeleteMessageAsync(deleteMessage.ReceiptHandle);
        

        public async Task<List<AllMessage>> GetAllMessagesAsync()
        {
            List<AllMessage> allMessages = new List<AllMessage>();

            List<Message> messages = await _AWSSQSIntegration.ReceiveMessageAsync();

            if (messages != null && messages.Any())
            {
                allMessages = messages.Select(c => new AllMessage 
                { 
                    MessageId = c.MessageId,
                    ReceiptHandle = c.ReceiptHandle,
                    UserDetail = JsonConvert.DeserializeObject<UserDetail>(c.Body) 
                }).ToList();
            }
                
            return allMessages;
        }

        public async Task<bool> PostMessageAsync(User user)
        {
            UserDetail userDetail = new UserDetail();
            userDetail.Id = new Random().Next(999999999);
            userDetail.FirstName = user.FirstName;
            userDetail.LastName = user.LastName;
            userDetail.UserName = user.UserName;
            userDetail.EmailId = user.EmailId;
            userDetail.CreatedOn = DateTime.UtcNow;
            userDetail.UpdatedOn = DateTime.UtcNow;
            return await _AWSSQSIntegration.SendMessageAsync(userDetail);
        }
    }
}
