using MyCleanProject1.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace MyCleanProject1.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}
