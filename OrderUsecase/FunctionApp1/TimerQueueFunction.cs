//using System;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Extensions.Logging;

//namespace FunctionApp1
//{
//    public class DemoFunction
//    {
//        private readonly ILogger _logger;

//        public DemoFunction(ILoggerFactory loggerFactory)
//        {
//            _logger = loggerFactory.CreateLogger<DemoFunction>();
//        }

//        [Function("DemoFunction")]
//        public void Run([TimerTrigger("0 */10 * * * *")] TimerInfo myTimer)
//        {
//            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

//            if (myTimer.ScheduleStatus is not null)
//            {
//                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
//            }
//        }
//    }
//}


using System;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class TimerQueueFunction
    {
        private readonly ILogger<TimerQueueFunction> _logger;

        public TimerQueueFunction(ILogger<TimerQueueFunction> logger)
        {
            _logger = logger;
        }

        [Function("TimerQueueFunction")]
        public async Task RunAsync([TimerTrigger("0 */2 * * * *")] TimerInfo timerInfo)
        {
            _logger.LogInformation($"Timer trigger function executed at: {DateTime.Now}");

            string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            string queueName = "demoqueue"; 

            QueueClient queueClient = new QueueClient(connectionString, queueName);
            if (await queueClient.ExistsAsync())
            {
                var peekedMessage = await queueClient.PeekMessagesAsync(1);

                if (peekedMessage.Value.Length > 0)
                {
                    var message = peekedMessage.Value[0]; 
                    _logger.LogInformation($"Message dequeued: {message.MessageText}");
                }
                else
                {
                    _logger.LogInformation("No messages in the queue to dequeue.");
                }
            }
            else
            {
                _logger.LogWarning("Queue not found.");
            }
        }
    }
}
