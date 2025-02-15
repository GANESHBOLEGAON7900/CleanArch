﻿using MyCleanProject1.Api.Controllers.v1;
using MyCleanProject1.API.UnitTests.Mocks;
using MyCleanProject1.Application.Features.Orders.GetOrdersForMonth;
using MyCleanProject1.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MyCleanProject1.API.UnitTests.Controllers.v1
{
    public class OrderControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        public OrderControllerTests()
        {
            _mockMediator = MediatorMocks.GetMediator();
        }

        [Fact]
        public async Task Get_PagedOrders_ForMonth()
        {
            var controller = new OrderController(_mockMediator.Object);

            var result = await controller.GetPagedOrdersForMonth(DateTime.Now, 1, 2);

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<PagedResponse<IEnumerable<OrdersForMonthDto>>>();
        }
    }
}
