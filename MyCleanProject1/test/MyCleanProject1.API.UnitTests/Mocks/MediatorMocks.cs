﻿using MyCleanProject1.Application.Features.Categories.Commands.CreateCategory;
using MyCleanProject1.Application.Features.Categories.Commands.StoredProcedure;
using MyCleanProject1.Application.Features.Categories.Queries.GetCategoriesList;
using MyCleanProject1.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MyCleanProject1.Application.Features.Events.Commands.CreateEvent;
using MyCleanProject1.Application.Features.Events.Commands.DeleteEvent;
using MyCleanProject1.Application.Features.Events.Commands.Transaction;
using MyCleanProject1.Application.Features.Events.Commands.UpdateEvent;
using MyCleanProject1.Application.Features.Events.Queries.GetEventDetail;
using MyCleanProject1.Application.Features.Events.Queries.GetEventsExport;
using MyCleanProject1.Application.Features.Events.Queries.GetEventsList;
using MyCleanProject1.Application.Features.Orders.GetOrdersForMonth;
using MyCleanProject1.Application.Responses;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyCleanProject1.API.UnitTests.Mocks
{
    public class MediatorMocks
    {
        public static Mock<IMediator> GetMediator()
        {
            var mockMediator = new Mock<IMediator>();

            mockMediator.Setup(m => m.Send(It.IsAny<GetCategoriesListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<IEnumerable<CategoryListVm>>());
            mockMediator.Setup(m => m.Send(It.IsAny<GetCategoriesListWithEventsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<IEnumerable<CategoryEventListVm>>());
            mockMediator.Setup(m => m.Send(It.IsAny<CreateCategoryCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<CreateCategoryDto>());
            mockMediator.Setup(m => m.Send(It.IsAny<StoredProcedureCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<StoredProcedureDto>());

            mockMediator.Setup(m => m.Send(It.IsAny<GetEventsListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<IEnumerable<EventListVm>>());
            mockMediator.Setup(m => m.Send(It.IsAny<GetEventDetailQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<EventDetailVm>());
            mockMediator.Setup(m => m.Send(It.IsAny<GetEventsExportQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new EventExportFileVm() { Data = Encoding.UTF8.GetBytes(new string(' ', 100)), ContentType = "text/csv", EventExportFileName = "Filename"  });
            mockMediator.Setup(m => m.Send(It.IsAny<CreateEventCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<Guid>());
            mockMediator.Setup(m => m.Send(It.IsAny<UpdateEventCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<Guid>());
            mockMediator.Setup(m => m.Send(It.IsAny<DeleteEventCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Unit());
            mockMediator.Setup(m => m.Send(It.IsAny<TransactionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<Guid>());

            mockMediator.Setup(m => m.Send(It.IsAny<GetOrdersForMonthQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new PagedResponse<IEnumerable<OrdersForMonthDto>>(null, 10, 1, 2));
            
            return mockMediator;
        }
    }
}
