using AutoMapper;
using MyCleanProject1.Application.Features.Categories.Commands.CreateCategory;
using MyCleanProject1.Application.Features.Categories.Commands.StoredProcedure;
using MyCleanProject1.Application.Features.Categories.Queries.GetCategoriesList;
using MyCleanProject1.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MyCleanProject1.Application.Features.Events.Commands.CreateEvent;
using MyCleanProject1.Application.Features.Events.Commands.Transaction;
using MyCleanProject1.Application.Features.Events.Commands.UpdateEvent;
using MyCleanProject1.Application.Features.Events.Queries.GetEventDetail;
using MyCleanProject1.Application.Features.Events.Queries.GetEventsExport;
using MyCleanProject1.Application.Features.Events.Queries.GetEventsList;
using MyCleanProject1.Application.Features.Orders.GetOrdersForMonth;
using MyCleanProject1.Domain.Entities;

namespace MyCleanProject1.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {          
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, TransactionCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, StoredProcedureCommand>();
            CreateMap<Category, StoredProcedureDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();
        }
    }
}
