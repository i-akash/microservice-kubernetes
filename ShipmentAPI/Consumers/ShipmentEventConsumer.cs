using Contracts;
using MassTransit;

namespace ShipmentAPI.Consumers
{
    public class ShipmentEventConsumer: IConsumer<IShipEvent>

    {
        public Task Consume(ConsumeContext<IShipEvent> context)
        {
            return Task.CompletedTask;
        }
    }
}
