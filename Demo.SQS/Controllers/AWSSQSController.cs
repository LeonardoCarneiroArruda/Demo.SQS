using Demo.SQS.Models.Domain;
using Demo.SQS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.SQS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AWSSQSController : ControllerBase
    {
        private readonly ILogger<AWSSQSController> _logger;
        private readonly IAWSSQSService _AWSSQSService;
        public AWSSQSController(ILogger<AWSSQSController> logger, IAWSSQSService AWSSQSService)
        {
            _logger = logger;
            _AWSSQSService = AWSSQSService;
        }

        [HttpPost]
        public async Task<IActionResult> PostMessageAsync(User user)
        {
            var result = await _AWSSQSService.PostMessageAsync(user);
            return Ok(new { isSucess = result });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessagesAsync()
        {
            var result = await _AWSSQSService.GetAllMessagesAsync();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessageAsync(DeleteMessage deleteMessage)
        {
            var result = await _AWSSQSService.DeleteMessageAsync(deleteMessage);
            return Ok(new { isSucess = result });
        }
    }
}
