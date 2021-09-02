using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using KafkaProducer.Handlers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SharedEvents;

namespace KafkaProducer.Services
{
    public class KafkaProducerService : IHostedService
    {
        private readonly ILogger<KafkaProducerService> _logger;
        private readonly IProducer<Null, string> _producer;

        public KafkaProducerService(ILogger<KafkaProducerService> logger)
        {
            _logger = logger;
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:29092"
            };

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = "http://localhost:8085",
                // optional schema registry client properties:
                RequestTimeoutMs = 5000,
                MaxCachedSchemas = 10
            };

            var jsonSerializerConfig = new JsonSerializerConfig
            {
                BufferBytes = 100
            };

            var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
            _producer = new ProducerBuilder<Null, string>(config)
                //.SetValueSerializer(new JsonSerializer<MessageReceivedEvent>(schemaRegistry, jsonSerializerConfig))
                .Build();
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            for (var i = 0; i < 100; i++)
            {
                var value = $"Hello World {i}";
                _logger.LogInformation(value);

                await _producer.ProduceAsync("collection_account_topic", new Message<Null, string>()
                {
                    Value = value
                }, cancellationToken);
            }            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _producer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
