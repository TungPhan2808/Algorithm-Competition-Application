using Azure.Storage.Queues.Models;

namespace Equifinance.Mock.Core.Interfaces
{
    public interface IAzureQueueService
    {
        Task EnqueueMessageAsync(string messageContent);
        Task<QueueMessage> DequeueMessageAsync(TimeSpan visibilityTimeout);
        Task DeleteMessageAsync(QueueMessage message);
    }
}
