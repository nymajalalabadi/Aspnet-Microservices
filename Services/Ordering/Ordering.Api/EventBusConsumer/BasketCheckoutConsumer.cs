using EventBus.Messages.Events;
using MassTransit;
using System.Threading.Tasks;

namespace Ordering.Api.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        public Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
