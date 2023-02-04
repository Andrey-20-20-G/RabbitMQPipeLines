using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Producer.RabbitMQ
{
	public class RabbitMqService : IRabbitMqService
	{
		public void SendMessage(object obj)
		{
			var message = JsonSerializer.Serialize(obj);
			SendMessage(message);
		}

		public void SendMessage(string message)
		{
			// Не забудьте вынести значения "localhost" и "MyQueue"
			// в файл конфигурации
			var factory = new ConnectionFactory() 
			{ Uri = 
			new Uri("amqps://mexmhswa:suzrYDFM8qjtbWAW8WXETUUZgcS1SZmR@mustang.rmq.cloudamqp.com/mexmhswa") };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "MyQueue",
							   durable: false,
							   exclusive: false,
							   autoDelete: false,
							   arguments: null);

				var body = Encoding.UTF8.GetBytes(message);

				var properties = channel.CreateBasicProperties();properties.Persistent = true;

				channel.BasicPublish(exchange: "",
							   routingKey: "MyQueue",
							   basicProperties: properties,
							   body: body);
			}
		}
	}
}
