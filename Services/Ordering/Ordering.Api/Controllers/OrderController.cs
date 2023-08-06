﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Ordering.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region constructor

        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region get all orders

        [HttpGet("{userName}", Name = "GetOrders")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVM>>> GetOrderByUserName(string userName)
        {
            var query = new GetOrdersListQuery(userName);

            var orders = await _mediator.Send(query);

            return Ok(orders);
        }

        #endregion

        #region checkout order

        [HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        #endregion

        #region update order

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        #endregion

        #region delete order

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderCommand { Id = id });

            return NoContent();
        }

        #endregion
    }
}
