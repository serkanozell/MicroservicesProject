using FreeCourse.Services.Order.Application.Commands;
using FreeCourse.Services.Order.Application.Dtos;
using FreeCourse.Services.Order.Domain.OrderAggregate;
using FreeCourse.Services.Order.Infrastructure;
using FreeCourse.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _dbContext;

        public CreateOrderCommandHandler(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.AddressDto.Province,
                                         request.AddressDto.District,
                                         request.AddressDto.Street,
                                         request.AddressDto.ZipCode,
                                         request.AddressDto.Line);

            var newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);

            request.OrderItemsDto.ForEach(item =>
            {
                newOrder.AddOrderItem(item.ProductId, item.ProductName, item.Price, item.PictureUrl);
            });

            await _dbContext.Orders.AddAsync(newOrder);

            await _dbContext.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 204);
        }
    }
}
