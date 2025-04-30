//using System;
//using Azure.Storage.Queues.Models;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Extensions.Logging;

//namespace FunctionApp1
//{
//    public class QueueFunction
//    {
//        private readonly ILogger<QueueFunction> _logger;

//        public QueueFunction(ILogger<QueueFunction> logger)
//        {
//            _logger = logger;
//        }

//        [Function(nameof(QueueFunction))]
//        public void Run([QueueTrigger("demoqueue", Connection = "AzureWebJobsStorage")] QueueMessage message)
//        {
//           Console.WriteLine ($"C# Queue trigger function processed: {message.MessageText}");

//        }
//    }
//}

//using System;
//using Azure.Storage.Queues;
//using Azure.Storage.Queues.Models;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Extensions.Logging;

//namespace FunctionApp1
//{
//    public class QueueFunction
//    {
//        private readonly ILogger<QueueFunction> _logger;

//        public QueueFunction(ILogger<QueueFunction> logger)
//        {
//            _logger = logger;
//        }

//        [Function(nameof(QueueFunction))]
//        public async Task RunAsync([QueueTrigger("demoqueue", Connection = "AzureWebJobsStorage")] QueueMessage message)
//        {
//            // Log the received message
//            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");

//            // Retrieve connection string from app settings (you can also use the Connection string passed in [QueueTrigger])
//            string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

//            // Create a QueueClient instance to interact with the Azure Queue
//            QueueClient queueClient = new QueueClient(connectionString, "demoqueue");

//            // Optionally, you could store the message in a different queue
//            // QueueClient queueClient = new QueueClient(connectionString, "newqueue");

//            // Send the message back to the queue without deleting it from the original queue
//            await queueClient.SendMessageAsync(message.MessageText);

//            // Log that the message was re-enqueued
//            _logger.LogInformation($"Message '{message.MessageText}' has been added back to the queue.");
//        }
//    }
//}
