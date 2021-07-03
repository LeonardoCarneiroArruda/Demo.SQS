using Demo.SQS.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.SQS.Services.Interfaces
{
    public interface IAWSSQSService
    {
        Task<bool> PostMessageAsync(User user);
        Task<List<AllMessage>> GetAllMessagesAsync();
        Task<bool> DeleteMessageAsync(DeleteMessage deleteMessage);
    }
}
