using Amazon.SQS;
using Amazon.SQS.Model;
using Demo.SQS.Models.AWS;
using Demo.SQS.Models.AWS.Interfaces;
using Demo.SQS.Models.Domain;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.SQS.Infra.AWSIntegration
{
    public class AWSSQSIntegration : IAWSSQSIntegration
    {
        private readonly IAmazonSQS _sqs;
        private readonly ServiceConfiguration _settings;
        public AWSSQSIntegration(IAmazonSQS sqs)
        {
            this._sqs = sqs;
            this._settings = new ServiceConfiguration(Environment.GetEnvironmentVariable("QUEUEURL") ?? "");
        }
        public async Task<bool> DeleteMessageAsync(string messageReceiptHandle)
        {
            try
            {
                //Deletes the specified message from the specified queue  
                var deleteResult = await _sqs.DeleteMessageAsync(_settings.AWSSQS, messageReceiptHandle);
                
                return deleteResult.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Message>> ReceiveMessageAsync()
        {
            try
            {
                //Create New instance  
                var request = new ReceiveMessageRequest
                {
                    QueueUrl = _settings.AWSSQS,
                    WaitTimeSeconds = 5,
                    MaxNumberOfMessages = 10
                };

                //CheckIs there any new message available to process  
                var result = await _sqs.ReceiveMessageAsync(request);

                return result.Messages.Any() ? result.Messages : new List<Message>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> SendMessageAsync(UserDetail userDetail)
        {
            try
            {
                string message = JsonConvert.SerializeObject(userDetail);
                var sendRequest = new SendMessageRequest(_settings.AWSSQS, message);
                
                // Post message or payload to queue  
                var sendResult = await _sqs.SendMessageAsync(sendRequest);

                return sendResult.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
