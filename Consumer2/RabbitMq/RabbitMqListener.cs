using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;

namespace Consumer2.RabbitMq
{
    public class RabbitMqListener: BackgroundService
    {
		private IConnection _connection;
		private IModel _channel;

		public RabbitMqListener()
		{
			// Не забудьте вынести значения "localhost" и "MyQueue"
			// в файл конфигурации
			var factory = new ConnectionFactory();
			factory.Uri = new Uri("amqps://mexmhswa:suzrYDFM8qjtbWAW8WXETUUZgcS1SZmR@mustang.rmq.cloudamqp.com/mexmhswa");
			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();
			_channel.QueueDeclare(queue: "MyQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			stoppingToken.ThrowIfCancellationRequested();

			var consumer = new EventingBasicConsumer(_channel);
			consumer.Received += (ch, ea) =>
			{
				var content = Encoding.UTF8.GetString(ea.Body.ToArray());

				// Каким-то образом обрабатываем полученное сообщение
				Console.WriteLine($"Получено сообщение: {content}");

				_channel.BasicAck(ea.DeliveryTag, false);
			};

			_channel.BasicConsume("MyQueue", false, consumer);

			return Task.CompletedTask;
		}

		public override void Dispose()
		{
			_channel.Close();
			_connection.Close();
			base.Dispose();
		}
	}
}
