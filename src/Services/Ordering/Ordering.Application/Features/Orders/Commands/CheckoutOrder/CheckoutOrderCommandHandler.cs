using MediatR;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = new Order(
                userId: Guid.NewGuid(),
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.EmailAddress,
                address: request.AddressLine,
                country: request.Country,
                zipCode: request.ZipCode,
                totalPrice: request.TotalPrice
            );

            var newOrder = await _orderRepository.AddAsync(orderEntity);

            return newOrder.Id;
        }
    }
}