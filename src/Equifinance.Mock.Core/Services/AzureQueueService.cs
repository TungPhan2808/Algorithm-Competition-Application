using Azure.Storage.Queues.Models;
using Equifinance.Mock.Core.Interfaces;

namespace Equifinance.Mock.Core.Services
{
    public class AzureQueueService : IAzureQueueService
    {
        private readonly string _connectionString;
        private readonly string _queuename;

        public AzureQueueService(string connectionString, string queuename)
        {
            _connectionString = connectionString;
            _queuename = queuename;
        }

        public Task DeleteMessageAsync(QueueMessage message)
        {
            throw new NotImplementedException();
        }

        public Task<QueueMessage> DequeueMessageAsync(TimeSpan visibilityTimeout)
        {
            throw new NotImplementedException();
        }

        public async Task EnqueueMessageAsync(string messageContent)
        {
            throw new NotImplementedException();
        }
    }
}
