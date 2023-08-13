using Azure.Storage.Queues.Models;
using Newtonsoft.Json;

namespace Equifinance.Mock.Core.Services
{
    public class QueueMessage<T>
    {
        public T Data { get; set; }
        public QueueMessage(T data)
        {
            Data = data;
        }
        public QueueMessage(string message)
        {
            var queueMessage = JsonConvert.DeserializeObject<QueueMessage<T>>(message);
            Data = queueMessage.Data;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static QueueMessage<T> Deserialize(QueueMessage message)
        {
            var data = JsonConvert.DeserializeObject<T>(message.MessageText);
            return new QueueMessage<T>(data);
        }
    }
}
